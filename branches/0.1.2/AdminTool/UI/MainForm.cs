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
    public partial class MainForm : Form
    {
        //текущая страница просмотра пользователей
        private int currentUserPage = 1;

        //всего страниц пользователей
        private int countUserPages=1;

        //количество записей на странице
        private int rowsPerPage=2;

        public MainForm()
        {
            InitializeComponent();
            FillUsersList(1);
            countUserPages = GetUserPages();

            pageNumberUpDown.Minimum = 0;
            pageNumberUpDown.Maximum = countUserPages;


        }


        //возвращает количество страниц
        private int GetUserPages()
        {
            int usersCount = Account.Instance.GetCountUsers();
            if (usersCount > rowsPerPage)
                return usersCount / rowsPerPage;
            return 1;
        }
        

        //заполянет список пользователей
        private void FillUsersList(int page)
        {
            pageNumberUpDown.Value = page;
            Enabled = false;
            Cursor = Cursors.WaitCursor;
            User[] userList = Account.Instance.GetUsers(page, rowsPerPage);
            UsersList.Items.Clear();
            foreach (var user in userList)
            {
                ListViewItem item = new ListViewItem(user.UserId.ToString());

                item.SubItems.Add(user.Email);
                float spaceLimit = (float)user.SpaceLimit / 1024.0f;
                string suffix =  "KByte";

                if (spaceLimit > 1000.0f)
                {
                    spaceLimit /= 1024.0f;
                    suffix = "MByte";
                }
                item.SubItems.Add(string.Format("{0:0.0} {1}", spaceLimit, suffix));
                
                item.SubItems.Add("5%");
                item.SubItems.Add("12.08.2010 12:35");
                UsersList.Items.Add(item);
            }
            Cursor = Cursors.Default;
            Enabled = true;
        }

        //форма закрыта
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //первая страница списка пользователей
        private void FirstPageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            currentUserPage=1;
            FillUsersList(currentUserPage);

        }


        //следующая страница списка пользователей
        private void NextPageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentUserPage < countUserPages)
            {
                currentUserPage += 1;
                FillUsersList(currentUserPage);
            }
        }


        //предыдущая страница списка пользователей
        private void PrevPageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentUserPage > 1)
            {
                currentUserPage -= 1;
                FillUsersList(currentUserPage);
            }
        }


        //последняя страница списка пользователей
        private void LastPageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillUsersList(countUserPages);
        }



        private void pageNumberUpDown_ValueChanged(object sender, EventArgs e)
        {
             int viewPage=(int)pageNumberUpDown.Value;
            if (viewPage > 0 && viewPage < countUserPages)
            {
                FillUsersList(viewPage);
                currentUserPage = viewPage;
            }
        }
    }
}
