using NestPix.Models;
using NestPix.Services.Repos;
using NestPix.Types;

namespace NestPix.Services
{

    internal class NavigationService : FilesService
    {
        int CurrentDirIndex = 0;
        int CurrentImageIndex = -1;
        public bool isEndOfList { get; private set; } = false;
        KeyValuePair<string, List<string>> CurrentDir = new KeyValuePair<string, List<string>>();

        string? PreviewImage = null;
        SessionRepo sessionService = new SessionRepo();

        CacheRepo cacheService = new CacheRepo();
        public NavigationService()
        {



        }
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

        private string? FindInDirByIndex(string dir, int index)
        {

            try
            {
                return ImageFiles[dir].ElementAt(index);

            }
            catch (Exception)
            {
                return null;

            }


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
            string? ImagePath = FindInDirByIndex(CurrentDir.Key, CurrentImageIndex);
            if (PreviewImage is not null && ImagePath is not null)
            {
                return new Pix(ImagePath, CurrentDir.Key, PreviewImage);
            }
            if (ImagePath is not null)
            {
                return new Pix(ImagePath, CurrentDir.Key);
            }
            return new Pix();
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
                    isEndOfList = true;
                    return new Pix();
                }



            }

            CurrentImageIndex++;

            GetPreview();
            var CurrentImage = FindInDirByIndex(CurrentDir.Key, CurrentImageIndex);
            if (PreviewImage is not null && CurrentImage is not null)
            {
                return new Pix(CurrentImage, CurrentDir.Key, PreviewImage);

            }
            if (CurrentImage is not null)
            {
                return new Pix(CurrentImage, CurrentDir.Key);
            }
            return new Pix();

        }



        public void AddToCache(Pix pixy, Actions action)
        {

            var session = sessionService.GetCurrentSession();

            if (pixy.ImagePath is null || pixy.CurrentDir is null)
            {
                return;
            }


            Cache? CachedImage = cacheService.GetImageFromCacheBySessionId(session.id, pixy);

            if (CachedImage == null)
            {
                Cache cache = new Cache()
                {
                    FileName = pixy.ImageName,
                    FolderPath = pixy.CurrentDir,
                    FileSize = new FileInfo(pixy.ImagePath).Length,
                    IsDeleted = action == Actions.Delete,
                    IsSkipped = action == Actions.Next,
                    Extension = Path.GetExtension(pixy.ImagePath),
                    CreatedAt = DateTime.Now,
                    SessionId = session.id,
                    ParentFolder = session?.Folder,
                };
                cacheService.Add(cache);
            }
            else
            {
                cacheService.UpdateImageAction(CachedImage, action);

            }




        }
        public List<Cache> GetMarkedAsDeleted()
        {
            Session session = sessionService.GetCurrentSession();
            List<Cache> ImagesMarkedAsDeleted = cacheService.GetMarkedAsDeletedBySession(session);
            return ImagesMarkedAsDeleted;
        }
        public async Task DeleteAll()
        {
            List<Cache> ImagesMarkedAsDeleted = GetMarkedAsDeleted();
            foreach (var image in ImagesMarkedAsDeleted)
            {
                string ImagePath = Path.Combine(image.FolderPath, image.FileName);

                bool isDeleted = ImageFiles[image.FolderPath].Remove(ImagePath);
                if (!isDeleted)
                {
                    throw new FileNotFoundException($"Image {image.FileName} not found in the list");
                }
                if (image.IsDeleted)
                {
                    if (File.Exists(ImagePath))
                    {
                        await Task.Run(() =>
                            {
                                string DestinationPath = Path.Combine(ConfigService.DeleteFolderPath, image.FileName);
                                File.Move(ImagePath, DestinationPath);
                            });
                    }

                }


            }




        }
    }
}
