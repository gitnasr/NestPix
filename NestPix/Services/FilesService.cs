namespace NestPix.Services
{

    internal class FilesService
    {
        private List<string> ImageExtensions = new List<string> {

         ".jpg", ".jpeg", ".png", ".bmp", ".webp"
            };


        private string FolderPath { get; set; }
        Dictionary<string, List<string>> ImageFiles = new Dictionary<string, List<string>>();


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

                List<string> newImage = new List<string>()
                {

                    file
                };
                ImageFiles.Add(dir, newImage);
            }

        }
        public async Task<Dictionary<string, List<string>>> GetAllImages(Action<string> updateStatus)
        {
            return await Task.Run(() =>
            {

                foreach (var file in Directory.EnumerateFiles(FolderPath, "*.*", new EnumerationOptions
                {
                    RecurseSubdirectories = true,
                    AttributesToSkip = FileAttributes.Hidden | FileAttributes.System
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
                    updateStatus?.Invoke($"{Path.GetDirectoryName(file)}");

                }
                updateStatus?.Invoke($"We got {ImageFiles.Count}, Sorting ... ");

                var sorted = ImageFiles.OrderBy(image => image.Key)
                       .ToDictionary(
                           image => image.Key,
                           image => image.Value.OrderBy(value => value).ToList()
                       );


                updateStatus?.Invoke($"We got {ImageFiles.Count}");

                return sorted;

            });


        }
    }
}
