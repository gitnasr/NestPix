namespace NestPix.Models
{
    internal class Cache
    {
        public int id { get; set; }
        public int SessionID { get; set; }
        public Session Session { get; set; }

        public int HashID { get; set; }
        public Hash Hash { get; set; }

        public string FileName { get; set; }
        public string FolderName { get; set; }
        public string FileSize { get; set; }
        public string Extension { get; set; }
        public bool isDeleted { get; set; } = false;
        public bool isSkipped { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
