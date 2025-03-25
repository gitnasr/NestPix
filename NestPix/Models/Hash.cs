namespace NestPix.Models
{
    internal class Hash
    {
        public int id { get; set; }
        public string HashValue { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string FileName { get; set; }
    }
}
