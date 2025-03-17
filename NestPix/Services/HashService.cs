using CoenM.ImageHash;
using CoenM.ImageHash.HashAlgorithms;

namespace NestPix.Services
{
    internal class HashService
    {
        readonly AverageHash hashAlgorithm = new AverageHash();
        List<string> Files = new List<string>();
        public HashService(List<string> files)
        {

            Files = files;
        }
        public void Start()
        {
            Task.Run(() =>
            {
                foreach (var file in Files)
                {

                    var hash = ComputeHash(file);
                    System.Diagnostics.Debug.WriteLine($"[HashingService] File: {file}, Hash: {hash}");
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
