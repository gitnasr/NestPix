namespace NestPix.Types
{
    sealed internal class NImage
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
        public NImage(string imagePath, string currentDir)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;


        }
        public NImage(string imagePath, string currentDir, string previewImage)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;
            NextPreview = previewImage;


        }


        public NImage()
        {
            CurrentDir = null;
            ImagePath = null;
        }
    }
}
