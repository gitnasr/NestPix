namespace NestPix.Types
{
    sealed internal class Pix
    {
        public string? ImagePath { get; private set; } = null;
        public string? ImageName { get; private set; } = null;
        public bool IsValid
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
            ImageName = Path.GetFileName(imagePath);


        }
        public Pix(string imagePath, string currentDir, string previewImage)
        {
            CurrentDir = currentDir;
            ImagePath = imagePath;
            Preview = previewImage;
            ImageName = Path.GetFileName(imagePath);


        }


        public Pix()
        {
            CurrentDir = null;
            ImagePath = null;
        }
    }
}
