namespace NestPix.Services
{

    internal class FilesService
    {
        private List<string> ImageExtensions = new List<string> {
                ".jpg", ".jpeg", ".png", ".bmp", ".webp"
            };
        private FileAttributes Skip = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Compressed
            | FileAttributes.ReadOnly | FileAttributes.Encrypted;
        private string FolderPath { get; set; }
        protected static Dictionary<string, List<string>> ImageFiles = new Dictionary<string, List<string>>();

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
                    AttributesToSkip = Skip
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

                updateStatus?.Invoke($"We got {ImageFiles.Count}");

                ImageFiles = sorted;
                // Create a Session
                SessionService sessionService = new SessionService();
                var OnlyImages = ImageFiles.Values.SelectMany(list => list).ToList();
                sessionService.CreateSession(FolderPath, 0, OnlyImages.Count);

                HashLayer hashService = new HashLayer(OnlyImages);
                hashService.Start();
            });
        }
    }
}
