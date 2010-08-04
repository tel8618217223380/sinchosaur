using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace Client
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            ShowSettings();
        }

        void ShowSettings()
        {
            textBoxServerIP.Text = Properties.Settings.Default.ServerRemoteAddress;
            textBoxStorageFolder.Text = Properties.Settings.Default.StorageFolder;
            textBoxLogin.Text = Properties.Settings.Default.UserLogin;
            textBoxPasswd.Text = Properties.Settings.Default.UserPasswd;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerRemoteAddress=textBoxServerIP.Text ;
            CreateNewStorageFolder();
                
            Properties.Settings.Default.UserLogin = textBoxLogin.Text;
            Properties.Settings.Default.UserPasswd = textBoxPasswd.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private bool CreateNewStorageFolder()
        {
            if (textBoxStorageFolder.Text == "")
            {
                MessageBox.Show("Укажите папку для синхронизации");
                return false;
            }
            if (!Directory.Exists(textBoxStorageFolder.Text))
                Directory.CreateDirectory(textBoxStorageFolder.Text);
            if (textBoxStorageFolder.Text != Properties.Settings.Default.StorageFolder)
            {
                Properties.Settings.Default.StorageFolder = textBoxStorageFolder.Text;
                ClientFileSystem.Instance.DeleteLastSinronizateFilesList();
            }
            return true;
        }

        private void buttonChoiseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog()
            {
               ShowNewFolderButton=true
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxStorageFolder.Text = dlg.SelectedPath;
            }
        }


    }
}
