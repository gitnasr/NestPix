using NestPix.Services.DB_Services;

namespace NestPix.Services
{
    public enum Actions
    {
        Next, Previous, Delete
    }
    internal class ConfigService
    {
        public Dictionary<Actions, Keys> Shortcuts { private set; get; } = new Dictionary<Actions, Keys>();
        public static readonly string DeleteFolderPath = Path.Combine(Application.StartupPath, "DeletedContent");
        public static readonly double IdleTime = 10;
        public static readonly double IdleTimeInSeconds = TimeSpan.FromMinutes(IdleTime).TotalSeconds;

        public ConfigService()
        {
            if (!Directory.Exists(DeleteFolderPath))
            {
                Directory.CreateDirectory(DeleteFolderPath);
            }
            LoadShortcuts();
        }

        public Dictionary<Actions, Keys> LoadShortcuts()
        {
            LoadShortcutsFromDatabase();
            if (Shortcuts.Count == 0)
            {
                LoadDefault();
                SaveShortcuts();
            }
            return Shortcuts;
        }

        private void LoadDefault()
        {
            Shortcuts.Add(Actions.Next, Keys.D);
            Shortcuts.Add(Actions.Previous, Keys.A);
            Shortcuts.Add(Actions.Delete, Keys.W);
        }

        private void LoadShortcutsFromDatabase()
        {
            ShortcutRepo shortcutService = new ShortcutRepo();
            Shortcuts = shortcutService.GetShortcuts();
        }

        public bool AssignShortcut(Keys key, Actions action)
        {

            if (Shortcuts.ContainsValue(key))
            {
                return false;
            }


            Shortcuts[action] = key;

            return true;

        }
        public void SaveShortcuts()
        {
            ShortcutRepo shortcutService = new ShortcutRepo();
            foreach (var item in Shortcuts)
            {
                shortcutService.UpdateShortcut(item.Key.ToString(), item.Value, item.Key);
            }
        }
    }
}
