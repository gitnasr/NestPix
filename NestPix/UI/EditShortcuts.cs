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
            KeyPreview = true;
            KeyDown += EditShortcuts_KeyDown;

        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AssignShortcut(Keys key, Actions action)
        {
            bool isAdded = config.AssignShortcut(key, action);

            if (!isAdded)
            {
                throw new Exception("Key already assigned");
            }
            switch (action)
            {
                case Actions.Next:
                    GoNextButton.Text = key.ToString();
                    break;
                case Actions.Previous:
                    GoBackButton.Text = key.ToString();
                    break;
                case Actions.Delete:
                    DeleteButton.Text = key.ToString();
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
        private void Assign(KeyEventArgs Key)
        {
            try
            {
                if (currentAction.HasValue)
                {
                    AssignShortcut(Key.KeyCode, currentAction.Value);
                    StautsBarLabel.Text = $"Shortcut of {currentAction.Value.ToString()} assigned to Key {Key.KeyCode}";
                    currentAction = null;
                    Key.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void EditShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            Assign(e);
        }
        private void GoNextButton_Click(object sender, EventArgs e)
        {
            currentAction = Actions.Next;
            StautsBarLabel.Text = "Press any key to assign to the Next action";

        }

        private void EditShortcuts_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void EditShortcuts_FormClosed(object sender, FormClosedEventArgs e)
        {
            config.SaveShortcuts();

        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            currentAction = Actions.Previous;
            StautsBarLabel.Text = "Press any key to assign to the Previous action";

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            currentAction = Actions.Delete;
            StautsBarLabel.Text = "Press any key to assign to the Delete action";

        }
    }
}
