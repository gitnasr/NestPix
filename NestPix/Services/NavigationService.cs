using NestPix.Models;
using NestPix.Services.DB_Services;
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
        private Dir GetPreviousDir()
        {
            int previousFolderIndex = CurrentDirIndex - 1;
            if (previousFolderIndex < 0)
            {
                return new Dir();
            }
            var previousDir = GetDirByIndex(previousFolderIndex);
            return new Dir(CurrentDir.Key, previousDir);
        }
        private Dir GetNextDir()
        {
            int NextFolderIndex = CurrentDirIndex + 1;
            if (NextFolderIndex > ImageFiles.Count - 1)
            {
                return new Dir();
            }
            var NextDir = GetDirByIndex(NextFolderIndex);
            if (NextDir.Key == null)
            {

                return new Dir();

            }

            return new Dir(CurrentDir.Key, NextDir);
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
        public Pix GetPrevious()
        {
            if (ImageFiles.Count == 0)
            {
                return new Pix();
            }

            CurrentDir = GetDirByIndex(CurrentDirIndex);

            if (CurrentImageIndex > 0)
            {
                CurrentImageIndex--;
            }
            else
            {
                Dir previousDir = GetPreviousDir();
                if (previousDir.IsHasNext)
                {
                    CurrentDirIndex -= 1;
                    CurrentDir = previousDir.Next;
                    CurrentImageIndex = CurrentDir.Value.Count - 1;
                }
                else
                {
                    return new Pix();
                }
            }

            GetPreview();

            if (PreviewImage != null)
            {
                return new Pix(FindInDirByIndex(CurrentDir.Key, CurrentImageIndex), CurrentDir.Key, PreviewImage);
            }
            return new Pix(FindInDirByIndex(CurrentDir.Key, CurrentImageIndex), CurrentDir.Key);
        }
        public Pix GetNext()
        {
            if (ImageFiles.Count == 0)
            {
                return new Pix();
            }

            CurrentDir = GetDirByIndex(CurrentDirIndex);

            if (CurrentDir.Key == null)
            {
                return new Pix();
            }


            var DirContent = CurrentDir.Value;

            int NextImageIndex = CurrentImageIndex + 1;

            if (NextImageIndex > DirContent.Count - 1)
            {
                CurrentImageIndex = -1;

                Dir nextDir = GetNextDir();

                if (nextDir.IsHasNext)
                {
                    CurrentDirIndex += 1;
                    CurrentDir = nextDir.Next;

                }
                else
                {


                    return new Pix();
                }



            }

            CurrentImageIndex++;

            GetPreview();
            var CurrentImage = FindInDirByIndex(CurrentDir.Key, CurrentImageIndex);
            if (PreviewImage != null)
            {
                return new Pix(CurrentImage, CurrentDir.Key, PreviewImage);

            }

            return new Pix(CurrentImage, CurrentDir.Key);



        }



        public void AddToCache(Pix pixy, Actions action)
        {
            HashService hashService = new HashService();
            // get session
            SessionService sessionService = new SessionService();
            var session = sessionService.GetLastSessionByFolder(pixy.CurrentDir);
            // Add the current image to the cache
            Cache cache = new Cache()
            {
                FileName = Path.GetFileName(pixy.ImagePath),
                FolderName = pixy.CurrentDir,
                FileSize = new FileInfo(pixy.ImagePath).Length.ToString(),
                isDeleted = action == Actions.Delete ? true : false,
                isSkipped = action == Actions.Next ? true : false,
                Extension = Path.GetExtension(pixy.ImagePath),
                CreatedAt = DateTime.Now,
                HashID = hashService.GetHashByFileName(pixy.ImagePath).id,
                SessionID = session.id,
            };
            CacheService cacheService = new CacheService();
            cacheService.Add(cache);
        }

    }
}
