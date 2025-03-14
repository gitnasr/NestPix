namespace NestPix.Services
{
    internal class FilesService
    {
        private List<string> ImageExtensions = new List<string> {

     ".jpg", ".jpeg", ".png", ".bmp", ".webp"
        };


        private string FolderPath { get; set; }

        public string CurrentStatus { private set; get; }


        public FilesService(string path)
        {
            FolderPath = path;
        }


        public async Task<List<string>> GetAllImages(Action<string> updateStatus)
        {
            return await Task.Run(() =>
            {


                var ImageFiles = new List<string>();

                foreach (var file in Directory.EnumerateFiles(FolderPath, "*.*", new EnumerationOptions
                {
                    RecurseSubdirectories = true,
                    AttributesToSkip = FileAttributes.Hidden | FileAttributes.System
                }))
                {

                    if (ImageExtensions.Contains(Path.GetExtension(file).ToLower()))
                    {
                        ImageFiles.Add(file);
                    }
                    updateStatus?.Invoke($"{Path.GetDirectoryName(file)}");

                }
                updateStatus?.Invoke($"We got {ImageFiles.Count}, Sorting ... ");

                ImageFiles.Sort();

                updateStatus?.Invoke($"We got {ImageFiles.Count}");

                return ImageFiles;

            });


        }
    }
}
