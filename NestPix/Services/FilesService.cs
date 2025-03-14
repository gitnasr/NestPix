namespace NestPix.Services
{
    internal class FilesService
    {
        private List<string> ImageExtensions = new List<string> {

     ".jpg", ".jpeg", ".png", ".bmp", ".gif"
        };


        private string FolderPath { get; set; }

        public List<string> Files { private set; get; }

        public FilesService(string path)
        {

            FolderPath = path;


        }


        public void GetAllImages()
        {
            List<string> files = Directory.GetFiles(FolderPath, "*.*", new EnumerationOptions { RecurseSubdirectories = true, AttributesToSkip = FileAttributes.Hidden | FileAttributes.System })
                .Where(file => ImageExtensions.Contains(Path.GetExtension(file).ToLower())).ToList();
            Files = files;

        }
    }
}
