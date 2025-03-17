using NestPix.Services.DB_Services;

namespace NestPix.Services
{
    public enum Actions
    {
        Next, Previous, Delete
    }
    internal class ConfigService
    {
        private Dictionary<Actions, Keys> Shortcuts { set; get; } = new Dictionary<Actions, Keys>();

        public ConfigService()
        {



        }

        public Dictionary<Actions, Keys> LoadShortcuts()
        {
            LoadShortcutsFromDatabase();
            if (Shortcuts.Count < Enum.GetValues(typeof(Actions)).Length)
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

        internal void AssignShortcut(Keys key, Actions action)
        {

            Shortcuts[action] = key;
        }
    }
}
