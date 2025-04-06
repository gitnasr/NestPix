namespace NestPix.Types
{
    sealed internal class Pix
    {
        public string? ImagePath { get; } = null;
        public string? ImageName { get; } = null;
        public bool IsHasNext
        {
            get
            {
                return !string.IsNullOrEmpty(ImagePath);
            }
        }
        public string? CurrentDir { get; }
        public string? Preview { get; }
        public Pix(string imagePath, string currentDir)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;


        }
        public Pix(string imagePath, string currentDir, string previewImage, string imageName)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;
            Preview = previewImage;
            ImageName = imageName;


        }


        public Pix()
        {
            CurrentDir = null;
            ImagePath = null;
        }
    }
}
