using NestPix.Models;

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

        public void GetExistingCacheByParentFolder(string ParentFolder)
        {
            using (var db = new AppDB())
            {

            }
        }
    }
}
