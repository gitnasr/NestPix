namespace NestPix.Services
{

    internal class FilesService
    {
        SessionService sessionService = new SessionService();
        CacheService cacheService = new CacheService();
        private List<string> ImageExtensions = new List<string> {
                ".jpg", ".jpeg", ".png", ".bmp", ".webp"
            };
        private readonly FileAttributes ToSkip = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Compressed
            | FileAttributes.ReadOnly | FileAttributes.Encrypted;
        private string FolderPath { get; set; }
        protected static Dictionary<string, List<string>> ImageFiles = new();

        public FilesService()
        {
            FolderPath = string.Empty;
        }

        public FilesService(string path)
        {
            FolderPath = path;
        }

        private void AddFile(string dir, string file)
        {
            if (ImageFiles.ContainsKey(dir))
            {
                ImageFiles[dir].Add(file);
            }
            else
            {
                List<string> newImage = new List<string> { file };
                ImageFiles.Add(dir, newImage);
            }
        }

        public async Task GetAllImages(Action<string> updateStatus)
        {
            await Task.Run(() =>
            {
                foreach (var file in Directory.EnumerateFiles(FolderPath, "*.*", new EnumerationOptions
                {
                    RecurseSubdirectories = true,
                    AttributesToSkip = ToSkip
                }))
                {
                    if (ImageExtensions.Contains(Path.GetExtension(file).ToLower()))
                    {
                        string? DirName = Path.GetDirectoryName(file);
                        if (DirName == null)
                        {
                            AddFile("root", file);
                        }
                        else
                        {
                            AddFile(DirName, file);
                        }
                    }
                    updateStatus.Invoke($"{Path.GetDirectoryName(file)}");
                }
                updateStatus.Invoke($"We got {ImageFiles.Count}, Sorting ... ");

                var sorted = ImageFiles.OrderBy(image => image.Key)
                 .ToDictionary(
                     image => image.Key,
                     image => image.Value.OrderBy(value => value).ToList()
                 );

                updateStatus.Invoke($"We got {ImageFiles.Count}");



                var AllDetectedImages = ImageFiles.Values.SelectMany(list => list).ToList();
                var ImageInDatabase = cacheService.GetExistingCacheByParentFolder(FolderPath);
                var ImagePathsInDb = new HashSet<string>(ImageInDatabase.Select(c => Path.Combine(c.FolderPath, c.FileName)));


                var FilteredImages = ImageFiles.ToDictionary(pair => pair.Key,
                    pair => pair.Value
                        .Where(imagePath => !ImagePathsInDb.Contains(imagePath))
                        .ToList()).Where(pair => pair.Value.Any())
                        .ToDictionary(pair => pair.Key, pair => pair.Value);


                ImageFiles = FilteredImages;


                int CountAlreadySeen = AllDetectedImages.Count - ImageFiles.Values
                    .SelectMany(list => list)
                    .Count();

                sessionService.CreateSession(FolderPath, CountAlreadySeen, AllDetectedImages.Count);
            });
        }
    }
}
