using NestPix.Services;

namespace NestPix.UI
{

    public partial class EditShortcuts : Form
    {
        private Actions? currentAction = null;

        ConfigService config = new ConfigService();
        public EditShortcuts()
        {
            InitializeComponent();
            this.KeyPreview = true; // Enable form to receive keyboard events
            this.KeyDown += EditShortcuts_KeyDown; // Subscribe to KeyDown event once

        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AssignShortcut(Keys key, Actions action)
        {
            switch (action)
            {
                case Actions.Next:
                    GoNextButton.Text = key.ToString();
                    config.AssignShortcut(key, action);
                    break;
                case Actions.Previous:
                    GoBackButton.Text = key.ToString();
                    config.AssignShortcut(key, action);

                    break;
                case Actions.Delete:
                    DeleteButton.Text = key.ToString();
                    config.AssignShortcut(key, action);
                    break;
            }
        }
        private void RenderShortcuts()
        {
            var shortcuts = config.LoadShortcuts();

            foreach (var shortcut in shortcuts)
            {
                switch (shortcut.Key)
                {
                    case Actions.Next:
                        GoNextButton.Text = shortcut.Value.ToString();
                        break;
                    case Actions.Previous:
                        GoBackButton.Text = shortcut.Value.ToString();
                        break;
                    case Actions.Delete:
                        DeleteButton.Text = shortcut.Value.ToString();
                        break;
                }
            }
        }
        private void EditShortcuts_Load(object sender, EventArgs e)
        {
            RenderShortcuts();
        }
        private void EditShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentAction.HasValue)
            {
                AssignShortcut(e.KeyCode, currentAction.Value);
                StautsBarLabel.Text = $"Shortcut of {currentAction.Value.ToString()} assigned to Key {e.KeyCode}";
                currentAction = null;
                e.Handled = true;
            }
        }
        private void GoNextButton_Click(object sender, EventArgs e)
        {
            currentAction = Actions.Next;
            StautsBarLabel.Text = "Press any key to assign to the Next action";

        }
    }
}
