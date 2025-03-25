namespace NestPix.Models
{
    internal class SessionShortcut
    {
        public int SessionID { get; set; }
        public int ShortcutID { get; set; }
        public Session Session { get; set; }
        public Shortcuts Shortcut { get; set; }
    }
}
