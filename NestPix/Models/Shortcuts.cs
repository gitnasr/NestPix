using NestPix.Services;

namespace NestPix.Models
{
    internal class Shortcuts
    {
        public int Id { get; set; }
        public Keys Key { get; set; }
        public Actions Action { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

    }
}
