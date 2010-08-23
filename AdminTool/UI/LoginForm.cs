using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace AdminTool
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            FillFormFields();
        }

        //заполняет поля сохраненными значениями
        public void FillFormFields()
        {
            ServerIpTextBox.Text = Properties.Settings.Default.ServerRemoteAddress;
            LoginTextBox.Text = Properties.Settings.Default.OperatorLogin;
            PasswordTextBox.Text = Properties.Settings.Default.OperatorPass;
            StorePassCheckBox.Checked = Properties.Settings.Default.StoreOperatorPass;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ServerIpTextBox.Text == "")
            {
                MessageBox.Show("Please type field Server IP", "warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ServerIpTextBox.Focus();
            }
            
            else
                if (LoginTextBox.Text == "")
                {
                    MessageBox.Show("Please type field login", "warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoginTextBox.Focus();
                }
                
                else
                {


                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        if (!Account.Instance.ExistOperator(LoginTextBox.Text, PasswordTextBox.Text, ServerIpTextBox.Text))
                            MessageBox.Show("Operator not exist", "error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            Account.Instance.SaveConnectionData(LoginTextBox.Text, PasswordTextBox.Text, ServerIpTextBox.Text, StorePassCheckBox.Checked);
                            new MainForm().Show();
                            Hide();
                        }
                    }
                    catch (EndpointNotFoundException)
                    {
                        MessageBox.Show("Can't connect to server", "error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (UriFormatException)
                    {
                        MessageBox.Show("Server ip not correct", "error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ServerIpTextBox.Focus();
                    }
                    this.Cursor = Cursors.Default;
                }

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
