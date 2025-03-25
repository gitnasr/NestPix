using CoenM.ImageHash;
using CoenM.ImageHash.HashAlgorithms;
using NestPix.Services.DB_Services;

namespace NestPix.Services
{
    internal class HashLayer
    {
        readonly AverageHash hashAlgorithm = new AverageHash();
        readonly HashService hashService = new HashService();
        List<string> Files = new List<string>();
        public HashLayer(List<string> files)
        {
            Files = files;
        }
        public void Start()
        {
            Task.Run(() =>
            {
                var existingHashes = hashService.GetHashes();
                // exclude files that have already been hashed
                Files = Files.Where(file => !existingHashes.Any(hash => hash.FileName == file)).ToList();
                foreach (var file in Files)
                {

                    var hash = ComputeHash(file);

                    hashService.AddHash(hash, file);
                    //Debug.WriteLine($"[HashingService] File: {file}, Hash: {hash}");
                }

                return Task.CompletedTask;
            });
        }

        private string ComputeHash(string filePath)
        {
            using var ImageStream = File.OpenRead(filePath);
            ulong hash = hashAlgorithm.Hash(ImageStream);
            return hash.ToString();
        }
    }
}
