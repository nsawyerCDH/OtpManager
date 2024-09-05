using OtpManager2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtpManager2
{
    public partial class AddEdit : Form
    {
        #region properties
        public bool IsAdd { get; }
        public bool IsEdit => !IsAdd;
        public ConfigItem configItem { get; set; }
        #endregion

        public AddEdit()
        {
            InitializeComponent();
            this.configItem = new ConfigItem();
            IsAdd = true;

            //Set the form icon to the Safe icon in resources
            this.Icon = Properties.Resources.safe1;
        }

        public AddEdit(ConfigItem configItem) : this()
        {
            //When the configItem is provided, then we are in edit mode
            this.configItem = configItem;
            this.IsAdd = false;
        }

        private void AddEdit_Load(object sender, EventArgs e)
        {
            //Set the form title
            if (IsEdit)
            {
                this.Text = "Edit Configuration Item";
            }
            else
            {
                this.Text = "Add Configuration Item";
            }

            //Add all the KeyModifiers to the ComboBox
            foreach (var item in Enum.GetValues(typeof(KeyModifiers)))
            {
                hotKeyModifierComboBox.Items.Add(item);
            }

            //Populate the form fields
            nameTextBox.Text = configItem.name;
            hotKeyModifierComboBox.SelectedItem = (KeyModifiers)configItem.modifier;
            hotKeyKeyTextBox.Text = ((Keys)configItem.key).ToString();
            valueTextBox.Text = configItem.value;
            valueTypeOTPRadioButton.Checked = configItem.isOTP;
            valueTypeStringRadioButton.Checked = !configItem.isOTP;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            //Build the configItem
            this.configItem.name = nameTextBox.Text;
            this.configItem.modifier = (int)Enum.Parse(typeof(KeyModifiers), hotKeyModifierComboBox.SelectedItem.ToString());
            this.configItem.key = (int)Enum.Parse(typeof(Keys), hotKeyKeyTextBox.Text);
            this.configItem.value = valueTextBox.Text;
            this.configItem.isOTP = valueTypeOTPRadioButton.Checked;
            //HotKey

            if (IsAdd)
            {
                //Add
                //Set the id to the next available id
                this.configItem.id = Startup.config.Items.Count > 0 ? Startup.config.Items.Max(x => x.id) + 1 : 1;

                Startup.config.Items.Add(this.configItem);
                ConfigReader.Write(ConfigReader.configPath, Startup.config);
            }
            else
            {
                //Edit
                var i = Startup.config.Items.FindIndex(x => x.id == this.configItem.id);

                if (i >= 0)
                {
                    Startup.config.Items.RemoveAt(i);
                    Startup.config.Items.Insert(i, this.configItem);
                    ConfigReader.Write(ConfigReader.configPath, Startup.config);
                }

            }

            this.Close();
        }
    }
}
