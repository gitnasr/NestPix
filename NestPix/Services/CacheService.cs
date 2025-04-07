using NestPix.Models;
using NestPix.Types;

namespace NestPix.Services
{
    internal class CacheService
    {
        public CacheService() { }
        public void Add(Cache cache)
        {
            // Add a new cache to the database
            using (var db = new AppDB())
            {
                db.Caches.Add(cache);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// This method retrieves a list of Cache objects from the database that match the specified parent folder and are marked as skipped.
        /// </summary>
        /// <param name="ParentFolder"></param>
        /// <returns>
        /// List of Cache objects that match the specified parent folder and are marked as skipped.
        /// </returns>
        public List<Cache> GetExistingCacheByParentFolder(string ParentFolder)
        {
            using (var db = new AppDB())
            {
                List<Cache> ParentRecords = db.Caches.Where(c => c.ParentFolder == ParentFolder && c.IsSkipped == true).ToList();
                return ParentRecords;

            }
        }
        public List<Cache> GetMarkedAsDeletedBySession(Session session)
        {
            using (var db = new AppDB())
            {
                List<Cache> MarkedAsRemoved = db.Caches.Where(c => c.SessionId == session.id && c.IsDeleted == true).ToList();
                return MarkedAsRemoved;
            }
        }

        public Cache? GetImageFromCacheBySessionId(int sessionId, Pix Image)
        {

            using (var db = new AppDB())
            {

                Cache? cached = db.Caches
                    .FirstOrDefault(c => c.SessionId == sessionId
                    && c.FileName == Image.ImageName
                    && c.FolderPath == Image.CurrentDir);

                return cached;

            }

        }

        public void UpdateImageAction(Cache Image, Actions action)
        {
            using (var db = new AppDB())
            {

                switch (action)
                {
                    case Actions.Next:
                        Image.IsSkipped = true;
                        Image.IsDeleted = false;
                        break;
                    case Actions.Delete:
                        Image.IsDeleted = true;
                        Image.IsSkipped = false;
                        break;
                    default:
                        break;
                }

                db.Caches.Update(Image);
                db.SaveChanges();


            }
        }

    }
}
