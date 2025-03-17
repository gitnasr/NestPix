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
            LoadShortcutsFromDatabase();
            if (Shortcuts.Count == 0)
            {
                LoadDefault();
                MessageBox.Show("Using Default");
            }
            else
            {
                MessageBox.Show("Using Database");
            }


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


    }
}
