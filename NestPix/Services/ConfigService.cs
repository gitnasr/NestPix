namespace NestPix.Services
{
    internal class ConfigService
    {
        public Dictionary<string, Keys> Shortcuts { private set; get; } = new Dictionary<string, Keys>();

        public ConfigService()
        {
            LoadDefault();

        }

        private void LoadDefault()
        {
            Shortcuts.Add("Next", Keys.Right);
            Shortcuts.Add("Previous", Keys.Left);
            Shortcuts.Add("Delete", Keys.Delete);
        }

    }
}
