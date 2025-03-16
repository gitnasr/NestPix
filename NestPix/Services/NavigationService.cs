using NestPix.Types;

namespace NestPix.Services
{

    internal class NavigationService : FilesService
    {
        int CurrentDirIndex = 0;
        int CurrentImageIndex = -1;

        KeyValuePair<string, List<string>> CurrentDir = new KeyValuePair<string, List<string>>();

        string? PreviewImage = null;


        public int GetDirsCount()
        {
            if (ImageFiles.Count == 0)
            {
                throw new Exception("No Images Found");
            }

            return ImageFiles.Keys.Count;
        }

        private KeyValuePair<string, List<string>> GetDirByIndex(int index)
        {
            return ImageFiles.ElementAt(index);
        }

        private string FindInDirByIndex(string dir, int index)
        {

            return ImageFiles[dir].ElementAt(index);

        }
        private NextDir GetPreviousDir()
        {
            int previousFolderIndex = CurrentDirIndex - 1;
            if (previousFolderIndex < 0)
            {
                return new NextDir();
            }
            var previousDir = GetDirByIndex(previousFolderIndex);
            return new NextDir(CurrentDir.Key, previousDir);
        }
        private NextDir GetNextDir()
        {
            int NextFolderIndex = CurrentDirIndex + 1;
            if (NextFolderIndex > ImageFiles.Count - 1)
            {
                return new NextDir();
            }
            var NextDir = GetDirByIndex(NextFolderIndex);
            if (NextDir.Key == null)
            {

                return new NextDir();

            }

            return new NextDir(CurrentDir.Key, NextDir);
        }
        private void GetPreview()
        {
            int nextPreviewImage = CurrentImageIndex + 1;

            if (nextPreviewImage < CurrentDir.Value.Count)
            {
                PreviewImage = FindInDirByIndex(CurrentDir.Key, nextPreviewImage);
            }
            else
            {
                var nextDir = GetNextDir();
                if (nextDir.IsHasNext)
                {
                    PreviewImage = FindInDirByIndex(nextDir.Next.Key, 0);
                }
                else
                {
                    PreviewImage = null;
                }
            }
        }
        public NextImage GetPrevious()
        {
            if (ImageFiles.Count == 0)
            {
                return new NextImage();
            }

            CurrentDir = GetDirByIndex(CurrentDirIndex);

            if (CurrentImageIndex > 0)
            {
                CurrentImageIndex--;
            }
            else
            {
                NextDir previousDir = GetPreviousDir();
                if (previousDir.IsHasNext)
                {
                    CurrentDirIndex -= 1;
                    CurrentDir = previousDir.Next;
                    CurrentImageIndex = CurrentDir.Value.Count - 1;
                }
                else
                {
                    return new NextImage();
                }
            }

            GetPreview();

            if (PreviewImage != null)
            {
                return new NextImage(FindInDirByIndex(CurrentDir.Key, CurrentImageIndex), CurrentDir.Key, PreviewImage);
            }
            return new NextImage(FindInDirByIndex(CurrentDir.Key, CurrentImageIndex), CurrentDir.Key);
        }
        public NextImage GetNext()
        {
            if (ImageFiles.Count == 0)
            {
                return new NextImage();
            }

            CurrentDir = GetDirByIndex(CurrentDirIndex);

            if (CurrentDir.Key == null)
            {
                return new NextImage();
            }


            var DirContent = CurrentDir.Value;

            int NextImageIndex = CurrentImageIndex + 1;

            if (NextImageIndex > DirContent.Count - 1)
            {
                CurrentImageIndex = -1;

                NextDir nextDir = GetNextDir();

                if (nextDir.IsHasNext)
                {
                    CurrentDirIndex += 1;
                    CurrentDir = nextDir.Next;

                }
                else
                {


                    return new NextImage();
                }



            }

            CurrentImageIndex++;

            GetPreview();

            if (PreviewImage != null)
            {
                return new NextImage(FindInDirByIndex(CurrentDir.Key, CurrentImageIndex), CurrentDir.Key, PreviewImage);

            }
            return new NextImage(FindInDirByIndex(CurrentDir.Key, CurrentImageIndex), CurrentDir.Key);



        }

        internal string GetCurrentDir()
        {
            return CurrentDir.Key;
        }
    }
}
