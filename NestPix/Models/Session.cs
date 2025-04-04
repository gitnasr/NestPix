namespace NestPix.Models
{
    internal class Session
    {
        public int id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastInteraction { get; set; } = DateTime.Now;
        public DateTime EndedAt { get; set; }
        public string? Folder { get; set; }
        public int FolderCount { get; set; }
        public int AlreadySeenCount { get; set; }


    }
}
