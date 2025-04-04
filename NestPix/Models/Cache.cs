using NestPix.Models;

internal class Cache
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public Session Session { get; set; }

    public string FileName { get; set; } = string.Empty;
    public string FolderPath { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string Extension { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public bool IsSkipped { get; set; } = false;
    public string? ParentFolder { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
