using NestPix.Models;

namespace NestPix.Services.DB_Services
{
    internal class HashService
    {
        public HashService() { }

        public void AddHash(string hash, string fileName)
        {
            using (var db = new AppDB())
            {
                Hash hashObj = new Hash
                {
                    FileName = fileName,
                    HashValue = hash
                };
                db.Hashes.Add(hashObj);
                db.SaveChanges();
            }
        }

        public List<Hash> GetHashes()
        {
            using (var db = new AppDB())
            {
                List<Hash> hashes = db.Hashes.ToList();
                return hashes;
            }
        }
        public List<Hash> GetHashesByListOfFiles(List<string> files)
        {
            using (var db = new AppDB())
            {
                List<Hash> hashes = db.Hashes.Where(hash => files.Contains(hash.FileName)).ToList();
                return hashes;
            }
        }
        public Hash? GetHashByFileName(string fileName)
        {
            using (var db = new AppDB())
            {
                Hash? hash = db.Hashes.FirstOrDefault(Hash => Hash.FileName == fileName);
                return hash;
            }
        }
    }
}
