namespace NestPix.Types
{
    sealed internal class Pix
    {
        public string? ImagePath { get; } = null;
        public bool IsHasNext
        {
            get
            {
                return !string.IsNullOrEmpty(ImagePath);
            }
        }
        public string? CurrentDir { get; }
        public string? NextPreview { get; }
        public Pix(string imagePath, string currentDir)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;


        }
        public Pix(string imagePath, string currentDir, string previewImage)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;
            NextPreview = previewImage;


        }


        public Pix()
        {
            CurrentDir = null;
            ImagePath = null;
        }
    }
}
