using Base32;
using OtpManager2.Models;
using OtpSharp;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OtpManager2
{
    public partial class Startup : Form
    {
        #region properties
        public static ConfigHead config { get; set; }

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        #endregion

        #region Constructor and Load
        public Startup()
        {
            InitializeComponent();

            //Create the tray icon
            CreateTrayItem();

            //Set the form icon to the Safe icon in resources
            this.Icon = Properties.Resources.safe1;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Constructor that takes an array of strings as arguments, which are the command line arguments.
        /// </summary>
        /// <param name="args">1 Argument is expected, the configuration file path</param>
        public Startup(string[] args) : this()
        {
            //Only 1 arg is expected, the path to the configuration file
            if (args.Length == 0)
            {
                //This is OK, it just means the user will have to manually select the configuration file
                //Do Nothing
            }
            else if (args.Length == 1)
            {
                //Check if the arg is a valid file path
                if (System.IO.File.Exists(args[0].Trim().ToLower()))
                {
                    ConfigReader.configPath = args[0].Trim().ToLower();
                }
                else
                {
                    //Do nothing, the file does not exist
                }
            }
            else
            {
                //Show an error message that too many arguments were provided
                MessageBox.Show("Too many arguments were provided!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            //Set the form text to be the Application name and version
            this.Text = Application.ProductName + " -- v" + Application.ProductVersion;

            //Load the configuration file
            LoadConfigFile();
        }
        #endregion

        #region Typing/Scripting
        static string GetOtp(string base32Secret)
        {
            // Decode the base32 secret and create a TOTP object
            var bytes = Base32Encoder.Decode(base32Secret);
            var totp = new Totp(bytes);

            // Generate the OTP and return
            return totp.ComputeTotp();
        }

        static void TypeStr(string value)
        {
            foreach (char c in value)
            {
                //type the character.
                SendKeys.SendWait(c.ToString());

                //sleep for the config duration
                System.Threading.Thread.Sleep(Startup.config.TypeCharDelayMs);
            }
        }
        #endregion

        #region hotkey handlers
        /// <summary>
        /// Method to register all the hotkeys in the configuration file
        /// </summary>
        public void RegisterHotKeys()
        {
            //For each item in the configration file, unregister any existing hotkeys and register the new hotkeys
            foreach (var configItem in config.Items)
            {
                UnregisterHotKey(this.Handle, configItem.id);
            }

            int i = 1;
            foreach (var configItem in config.Items)
            {
                configItem.id = i++;
                RegisterHotKey(this.Handle, configItem.id, (uint)configItem.modifier, (uint)configItem.key);
            }
        }

        /// <summary>
        /// Method to register a hotkey using the RegisterHotKey method from user32.dll
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        /// <summary>
        /// Method to unregister a hotkey using the UnregisterHotKey method from user32.dll
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// This is a low-level method that processes Windows messages.  It is fired essentially when any input is provided from the user via the keyboard or mouse.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            //Check if the message is a hotkey message
            if (m.Msg == 0x0312) // WM_HOTKEY
            {
                int id = m.WParam.ToInt32();

                //A HotKey was pressed, find if the id matches a registered hotkey and perform the action
                foreach (var configItem in Startup.config.Items)
                {
                    if (configItem.id == id)
                    {
                        //Delay for the specified duration ms, so that the user has time to release the keys before we start typing
                        //If a key is held down, such as a modifier key, it will combine with the programatic typing and may cause unintended results
                        System.Threading.Thread.Sleep(Startup.config.TypeBeforeDelayMs);

                        //Hotkey was found, type the value
                        if (configItem.valueType == ConfigItem.ValueTypes.otp)
                            TypeStr(GetOtp(configItem.value));

                        else
                            TypeStr(configItem.value);
                    }
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        #region UI Events
        //Create an event for textboxes to not allow the user to add or delete any characters
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void addNewItemButton_Click(object sender, EventArgs e)
        {
            //Show the AddEdit form as a dialog
            AddEdit addEditForm = new AddEdit();
            addEditForm.Owner = this;

            //Set the form to open in the center of the Startup form
            addEditForm.StartPosition = FormStartPosition.CenterParent;

            addEditForm.ShowDialog();

            //When the form is closed, reload the configuration file
            LoadConfigFile();
        }

        //Create an event that fires when the user clicks on the second to last column in the datagridview
        private void configViewerGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check if the user clicked on the second to last column -- edit
            if (e.ColumnIndex == 5)
            {
                //Get the row index
                int rowIndex = e.RowIndex;

                //Get the configItem
                ConfigItem configItem = Startup.config.Items[rowIndex];

                //Shoe the AddEdit for as a dialog
                AddEdit addEditForm = new AddEdit(configItem);

                //Set the form to open in the center of the Startup form
                addEditForm.StartPosition = FormStartPosition.CenterParent;

                addEditForm.ShowDialog();

                //When the form is closed, reload the configuration file
                LoadConfigFile();
            }

            //Check if the user clicked on the last column -- delete
            else if (e.ColumnIndex == 6)
            {
                //Get the row index
                int rowIndex = e.RowIndex;

                //Get the Id from the first invisible column in the row
                int id = int.Parse(configViewerGridView.Rows[rowIndex].Cells[0].Value.ToString());

                //Show a MessageBox for confirmation the user want's to delete the file
                if (MessageBox.Show("Are you sure you want to delete this configuration item?", "Delete Configuration Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Startup.config.Items.Remove(config.Items.Find(x => x.id == id));
                    ConfigReader.Write(ConfigReader.configPath, Startup.config);
                }

                //Reload the configuration file
                LoadConfigFile();
            }
        }

        /// <summary>
        /// Event handler for the FormClosing event.  We don't actually close, and instead minimize to the System Tray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Startup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //If it's the user pressing the red 'X' on the window, minimize to the system tray and do not exit app
                e.Cancel = true;
                this.Hide();
                return;
            }

            //If it's any other reason for closing the form, then exit the application (ex. windows shut down or task manager)
            Application.Exit();
        }

        /// <summary>
        /// Method to close the application fully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExit(object sender, EventArgs e)
        {
            //remove the event handler for form closing
            this.FormClosing -= Startup_FormClosing;

            //Release the mutex
            Program.mutex.ReleaseMutex();

            // Exit the application.
            Application.Exit();
        }

        //Method to restore the form when the tray icon is double-clicked
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Restore the form when the tray icon is double-clicked.
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region Tray Icon
        public void CreateTrayItem()
        {
            // Create a simple tray menu with one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon.
            trayIcon = new NotifyIcon();
            trayIcon.Text = Application.ProductName + " -- v" + Application.ProductVersion;
            trayIcon.Icon = Properties.Resources.safe1;

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            // Handle double-click event to restore the form.
            trayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;
        }
        #endregion

        #region helpers
        public void LoadConfigFile(bool PopulateUI = true, bool RegisterHotKeys = true)
        {
            //Check if the configuration path is the default path, and a config file does not exists there.  If so, ask the user to select a path to create a new configuration file
            if (!System.IO.File.Exists(ConfigReader.configPath))
            {
                //Show a dialog to select the configuration file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select Configuration File";
                openFileDialog.Filter = "JSON Files|*.json";
                openFileDialog.InitialDirectory = ConfigReader.defaultConfigDir;
                openFileDialog.FileName = ConfigReader.defaultConfigName;

                //If the user selects a file, set the configuration path
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ConfigReader.configPath = openFileDialog.FileName;
                }
                else
                {
                    //If the user cancels, ask if they want to create a new configuration file in the default location
                    if (MessageBox.Show("No configuration file was selected.  Would you like to create a new configuration file in the default location?", "Create New Configuration File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Create a new configuration file
                        ConfigReader.Write(ConfigReader.defaultConfigPath, ConfigReader.CreateSample(ConfigReader.defaultConfigPath));

                        //Set the configuration path to the default path
                        ConfigReader.configPath = ConfigReader.defaultConfigPath;

                        //Tell the user that the file was created, and where it was create at
                        MessageBox.Show("A new configuration file was created at " + ConfigReader.defaultConfigPath, "Configuration File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Exit the application and tell the user that the application will not work without a configuration file
                        MessageBox.Show("The application will not work without a configuration file.  Application Exiting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        OnExit(null, null);
                    }
                }
            }

            //Read the configuration file
            Startup.config = ConfigReader.Read(ConfigReader.configPath);

            //Populate the UI
            if (PopulateUI)
                this.PopulateUI();

            //Register all the hot keys
            if (RegisterHotKeys)
                this.RegisterHotKeys();
        }

        public void PopulateUI()
        {
            //Populate the Startup page with the configuration items
            this.filePathTextBox.Text = ConfigReader.configPath;
            this.fileVersionTextBox.Text = "v" + Startup.config.Version;
            this.numRegisteredItemsTextBox.Text = Startup.config.Items.Count.ToString();
            this.typeBeforeDelayMsTextBox.Text = Startup.config.TypeBeforeDelayMs.ToString();
            this.typeCharDelayMsTextBox.Text = Startup.config.TypeCharDelayMs.ToString();

            configViewerGridView.Rows.Clear();
            foreach (var configItem in Startup.config.Items)
            {
                //Build the string which will be shown as the Hot Key Combo
                string hotKeyCombo = "";
                if (configItem.modifier != 0)
                {
                    hotKeyCombo += ((KeyModifiers)configItem.modifier).ToString() + " + ";
                }
                hotKeyCombo += ((Keys)configItem.key).ToString();

                //Build the safe value, as we don't want to openly display sensitive OTP secrets or passwords
                string safeValue = configItem.valueType == ConfigItem.ValueTypes.plainText ? configItem.value : "********************";

                //Add the row to the GridView
                configViewerGridView.Rows.Add(configItem.id, configItem.name, hotKeyCombo, safeValue, configItem.valueType == ConfigItem.ValueTypes.otp);
            }
        }
        #endregion
    }
}

