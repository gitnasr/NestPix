namespace NestPix.Types
{
    sealed internal class NextImage
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
        public NextImage(string imagePath, string currentDir)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;


        }
        public NextImage(string imagePath, string currentDir, string previewImage)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;
            NextPreview = previewImage;


        }


        public NextImage()
        {
            CurrentDir = null;
            ImagePath = null;
        }
    }
}
