using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdminTool.AccountServiceReference;

namespace AdminTool
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Account.Instance.AddUser(EmailTextBox.Text, PasswordTextBox.Text, Int32.Parse(SpaceTextBox.Text));
            Close();
        }
    }
}
