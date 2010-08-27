using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdminTool.AccountServiceReference;
using AdminTool.FileSystemServiceReference;

namespace AdminTool
{
    public partial class MainForm : Form
    {
        //всего страниц пользователей
        private int countUserPages=0;

        //количество записей на странице
        private int rowsPerPage=2;


        public MainForm()
        {
            InitializeComponent();
          
            countUserPages = GetUserPages();

            for (int i = 0; i <= countUserPages; i++)
                NumberPageComboBox.Items.Add((i+1).ToString());

            FillUsersList(0);
        }


        //возвращает количество страниц
        private int GetUserPages()
        {
            int usersCount = Account.Instance.GetCountUsers();
            if (usersCount > rowsPerPage)
                return usersCount / rowsPerPage-1;
            return 0;
        }
        

        //заполянет список пользователей
        private void FillUsersList(int page)
        {
            NumberPageComboBox.SelectedIndex = page;
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


        //заполянет список пользователей
        private void FillUserFilesList(MyFile[] files)
        {
            Enabled = false;
            Cursor = Cursors.WaitCursor;
            
            UserFilesList.Items.Clear();
            foreach (var file in files)
            {
                if (file.IsDirectory)
                    continue;
                ListViewItem item = new ListViewItem(file.Name);

                float spaceLimit = (float)file.Size / 1024.0f;
                string suffix =  "KByte";

                if (spaceLimit > 1000.0f)
                {
                    spaceLimit /= 1024.0f;
                    suffix = "MByte";
                }
                item.SubItems.Add(string.Format("{0:0.0} {1}", spaceLimit, suffix));
                
                item.SubItems.Add(file.LastWriteTime.ToString());
                UserFilesList.Items.Add(item);
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
            NumberPageComboBox.SelectedIndex = 0;
            FillUsersList(NumberPageComboBox.SelectedIndex);

        }


        //следующая страница списка пользователей
        private void NextPageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NumberPageComboBox.SelectedIndex < countUserPages)
            {
                NumberPageComboBox.SelectedIndex += 1;
                FillUsersList(NumberPageComboBox.SelectedIndex);
            }
        }


        //предыдущая страница списка пользователей
        private void PrevPageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NumberPageComboBox.SelectedIndex > 0)
            {
                NumberPageComboBox.SelectedIndex -= 1;
                FillUsersList(NumberPageComboBox.SelectedIndex);
            }
        }


        //последняя страница списка пользователей
        private void LastPageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillUsersList(countUserPages);
        }


        //выбран номер страницы для перехода
        private void NumberPageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
             FillUsersList(NumberPageComboBox.SelectedIndex);
        }


        //выбран пользователь для просмотра
        private void UsersList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (UsersList.SelectedItems.Count > 0)
            {
                Cursor = Cursors.WaitCursor;

                UserFoldersTree.Nodes.Clear();
                UserFoldersTree.Nodes.Add(new TreeNode { Name = "1", Text = "Root" });
                TreeNode rootNode = UserFoldersTree.Nodes.Find("1", false).First();
                
                FillUserDirectoryTree(FileSystem.Instance.GetUserDirectories(Int32.Parse(UsersList.SelectedItems[0].Text)), rootNode);
                rootNode.Expand();

                Cursor = Cursors.Default;
            }
        }
        

        //рекурсивно заполняет дерево директорий пользователя
        private void FillUserDirectoryTree(DirectoryTree directoryTree, TreeNode node)
        {
            foreach (DirectoryTree directoryNode in directoryTree.ChildTree)
            {
                node.Nodes.Add(new TreeNode { Name = directoryNode.DirectoryId.ToString(), Text = directoryNode.Name });
                if (directoryNode.ChildTree.Count<DirectoryTree>() > 0)
                {
                    TreeNode nodeInfo = node.Nodes.Find(directoryNode.DirectoryId.ToString(), false).First();
                    FillUserDirectoryTree(directoryNode, nodeInfo);
                }
            }
        }


        //отображает список файлов каталога
        private void UserFoldersTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FillUserFilesList( FileSystem.Instance.GetUserDirectyFiles(Int32.Parse(UsersList.SelectedItems[0].Text), Int32.Parse(e.Node.Name)));
        }


        private void FindUserButton_Click(object sender, EventArgs e)
        {

        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            new UserForm().Show();
        }



    }
}
