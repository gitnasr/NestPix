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

        public ConfigService()
        {

            LoadShortcuts();

        }

        public Dictionary<Actions, Keys> LoadShortcuts()
        {
            LoadShortcutsFromDatabase();
            if (Shortcuts.Count == 0)
            {
                LoadDefault();
            }
            return Shortcuts;
        }

        private void LoadDefault()
        {
            Shortcuts.Add(Actions.Next, Keys.Right);
            Shortcuts.Add(Actions.Previous, Keys.Left);
            Shortcuts.Add(Actions.Delete, Keys.Delete);
        }

        private void LoadShortcutsFromDatabase()
        {
            ShortcutService shortcutService = new ShortcutService();
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
            ShortcutService shortcutService = new ShortcutService();
            foreach (var item in Shortcuts)
            {
                shortcutService.UpdateShortcut(item.Key.ToString(), item.Value, item.Key);
            }
        }
    }
}
