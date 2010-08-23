namespace AdminTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader Id;
            System.Windows.Forms.ColumnHeader Email;
            System.Windows.Forms.ColumnHeader File;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Folder1_1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Folder1_2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Folder1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Folder2");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.UsersList = new System.Windows.Forms.ListView();
            this.SpaceLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HistorySpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextPageLabel = new System.Windows.Forms.LinkLabel();
            this.PrevPageLabel = new System.Windows.Forms.LinkLabel();
            this.FirstPageLabel = new System.Windows.Forms.LinkLabel();
            this.LastPageLabel = new System.Windows.Forms.LinkLabel();
            this.pageNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.DeleteUserButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FindUserButton = new System.Windows.Forms.Button();
            this.EditUserButton = new System.Windows.Forms.Button();
            this.HistoryUserButton = new System.Windows.Forms.Button();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DownloadUserFileButton = new System.Windows.Forms.Button();
            this.UserFoldersTree = new System.Windows.Forms.TreeView();
            this.UserFilesList = new System.Windows.Forms.ListView();
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Synchronized = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FindUserFileButton = new System.Windows.Forms.Button();
            this.DeleteUserFileButton = new System.Windows.Forms.Button();
            Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Id
            // 
            Id.Text = "Id";
            Id.Width = 57;
            // 
            // Email
            // 
            Email.Text = "Email";
            Email.Width = 151;
            // 
            // File
            // 
            File.Text = "File";
            File.Width = 211;
            // 
            // UsersList
            // 
            this.UsersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Id,
            Email,
            this.SpaceLimit,
            this.HistorySpace,
            this.Created});
            this.UsersList.GridLines = true;
            this.UsersList.Location = new System.Drawing.Point(15, 37);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(577, 224);
            this.UsersList.TabIndex = 0;
            this.UsersList.UseCompatibleStateImageBehavior = false;
            this.UsersList.View = System.Windows.Forms.View.Details;
            // 
            // SpaceLimit
            // 
            this.SpaceLimit.Text = "Space limit";
            this.SpaceLimit.Width = 96;
            // 
            // HistorySpace
            // 
            this.HistorySpace.Text = "History Space";
            this.HistorySpace.Width = 97;
            // 
            // Created
            // 
            this.Created.Text = "Created";
            this.Created.Width = 91;
            // 
            // NextPageLabel
            // 
            this.NextPageLabel.AutoSize = true;
            this.NextPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextPageLabel.Location = new System.Drawing.Point(344, 272);
            this.NextPageLabel.Name = "NextPageLabel";
            this.NextPageLabel.Size = new System.Drawing.Size(15, 16);
            this.NextPageLabel.TabIndex = 2;
            this.NextPageLabel.TabStop = true;
            this.NextPageLabel.Text = ">";
            // 
            // PrevPageLabel
            // 
            this.PrevPageLabel.AutoSize = true;
            this.PrevPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrevPageLabel.Location = new System.Drawing.Point(255, 272);
            this.PrevPageLabel.Name = "PrevPageLabel";
            this.PrevPageLabel.Size = new System.Drawing.Size(15, 16);
            this.PrevPageLabel.TabIndex = 3;
            this.PrevPageLabel.TabStop = true;
            this.PrevPageLabel.Text = "<";
            // 
            // FirstPageLabel
            // 
            this.FirstPageLabel.AutoSize = true;
            this.FirstPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstPageLabel.Location = new System.Drawing.Point(230, 272);
            this.FirstPageLabel.Name = "FirstPageLabel";
            this.FirstPageLabel.Size = new System.Drawing.Size(22, 16);
            this.FirstPageLabel.TabIndex = 5;
            this.FirstPageLabel.TabStop = true;
            this.FirstPageLabel.Text = "<<";
            // 
            // LastPageLabel
            // 
            this.LastPageLabel.AutoSize = true;
            this.LastPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastPageLabel.Location = new System.Drawing.Point(361, 272);
            this.LastPageLabel.Name = "LastPageLabel";
            this.LastPageLabel.Size = new System.Drawing.Size(22, 16);
            this.LastPageLabel.TabIndex = 4;
            this.LastPageLabel.TabStop = true;
            this.LastPageLabel.Text = ">>";
            // 
            // pageNumberUpDown
            // 
            this.pageNumberUpDown.Location = new System.Drawing.Point(273, 270);
            this.pageNumberUpDown.Name = "pageNumberUpDown";
            this.pageNumberUpDown.Size = new System.Drawing.Size(65, 20);
            this.pageNumberUpDown.TabIndex = 6;
            // 
            // DeleteUserButton
            // 
            this.DeleteUserButton.Location = new System.Drawing.Point(598, 182);
            this.DeleteUserButton.Name = "DeleteUserButton";
            this.DeleteUserButton.Size = new System.Drawing.Size(90, 23);
            this.DeleteUserButton.TabIndex = 8;
            this.DeleteUserButton.Text = "Delete";
            this.DeleteUserButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FindUserButton);
            this.groupBox1.Controls.Add(this.EditUserButton);
            this.groupBox1.Controls.Add(this.HistoryUserButton);
            this.groupBox1.Controls.Add(this.AddUserButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.UsersList);
            this.groupBox1.Controls.Add(this.DeleteUserButton);
            this.groupBox1.Controls.Add(this.NextPageLabel);
            this.groupBox1.Controls.Add(this.PrevPageLabel);
            this.groupBox1.Controls.Add(this.pageNumberUpDown);
            this.groupBox1.Controls.Add(this.LastPageLabel);
            this.groupBox1.Controls.Add(this.FirstPageLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 303);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // FindUserButton
            // 
            this.FindUserButton.Location = new System.Drawing.Point(598, 37);
            this.FindUserButton.Name = "FindUserButton";
            this.FindUserButton.Size = new System.Drawing.Size(90, 23);
            this.FindUserButton.TabIndex = 15;
            this.FindUserButton.Text = "Find";
            this.FindUserButton.UseVisualStyleBackColor = true;
            // 
            // EditUserButton
            // 
            this.EditUserButton.Location = new System.Drawing.Point(598, 153);
            this.EditUserButton.Name = "EditUserButton";
            this.EditUserButton.Size = new System.Drawing.Size(90, 23);
            this.EditUserButton.TabIndex = 13;
            this.EditUserButton.Text = "Edit";
            this.EditUserButton.UseVisualStyleBackColor = true;
            // 
            // HistoryUserButton
            // 
            this.HistoryUserButton.Location = new System.Drawing.Point(598, 80);
            this.HistoryUserButton.Name = "HistoryUserButton";
            this.HistoryUserButton.Size = new System.Drawing.Size(90, 23);
            this.HistoryUserButton.TabIndex = 13;
            this.HistoryUserButton.Text = "History";
            this.HistoryUserButton.UseVisualStyleBackColor = true;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(598, 124);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(90, 23);
            this.AddUserButton.TabIndex = 8;
            this.AddUserButton.Text = "Add";
            this.AddUserButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Users list";
            // 
            // DownloadUserFileButton
            // 
            this.DownloadUserFileButton.Location = new System.Drawing.Point(598, 71);
            this.DownloadUserFileButton.Name = "DownloadUserFileButton";
            this.DownloadUserFileButton.Size = new System.Drawing.Size(90, 23);
            this.DownloadUserFileButton.TabIndex = 10;
            this.DownloadUserFileButton.Text = "Download";
            this.DownloadUserFileButton.UseVisualStyleBackColor = true;
            // 
            // UserFoldersTree
            // 
            this.UserFoldersTree.Location = new System.Drawing.Point(15, 42);
            this.UserFoldersTree.Name = "UserFoldersTree";
            treeNode1.Name = "Folder1_1";
            treeNode1.Text = "Folder1_1";
            treeNode2.Name = "Folder1_2";
            treeNode2.Text = "Folder1_2";
            treeNode3.Name = "Folder1";
            treeNode3.Text = "Folder1";
            treeNode4.Name = "Folder2";
            treeNode4.Text = "Folder2";
            treeNode5.Name = "Root";
            treeNode5.Text = "Root";
            this.UserFoldersTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.UserFoldersTree.Size = new System.Drawing.Size(144, 240);
            this.UserFoldersTree.TabIndex = 11;
            // 
            // UserFilesList
            // 
            this.UserFilesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            File,
            this.Size,
            this.Synchronized});
            this.UserFilesList.GridLines = true;
            this.UserFilesList.Location = new System.Drawing.Point(165, 42);
            this.UserFilesList.Name = "UserFilesList";
            this.UserFilesList.Size = new System.Drawing.Size(427, 240);
            this.UserFilesList.TabIndex = 12;
            this.UserFilesList.UseCompatibleStateImageBehavior = false;
            this.UserFilesList.View = System.Windows.Forms.View.Details;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Size.Width = 97;
            // 
            // Synchronized
            // 
            this.Synchronized.Text = "Synchronized";
            this.Synchronized.Width = 92;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.UserFilesList);
            this.groupBox3.Controls.Add(this.FindUserFileButton);
            this.groupBox3.Controls.Add(this.UserFoldersTree);
            this.groupBox3.Controls.Add(this.DeleteUserFileButton);
            this.groupBox3.Controls.Add(this.DownloadUserFileButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 295);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "User files";
            // 
            // FindUserFileButton
            // 
            this.FindUserFileButton.Location = new System.Drawing.Point(598, 42);
            this.FindUserFileButton.Name = "FindUserFileButton";
            this.FindUserFileButton.Size = new System.Drawing.Size(90, 23);
            this.FindUserFileButton.TabIndex = 12;
            this.FindUserFileButton.Text = "Find";
            this.FindUserFileButton.UseVisualStyleBackColor = true;
            // 
            // DeleteUserFileButton
            // 
            this.DeleteUserFileButton.Location = new System.Drawing.Point(598, 100);
            this.DeleteUserFileButton.Name = "DeleteUserFileButton";
            this.DeleteUserFileButton.Size = new System.Drawing.Size(90, 23);
            this.DeleteUserFileButton.TabIndex = 11;
            this.DeleteUserFileButton.Text = "Delete";
            this.DeleteUserFileButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 622);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Admin Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView UsersList;
        private System.Windows.Forms.ColumnHeader SpaceLimit;
        private System.Windows.Forms.ColumnHeader Created;
        private System.Windows.Forms.LinkLabel NextPageLabel;
        private System.Windows.Forms.LinkLabel PrevPageLabel;
        private System.Windows.Forms.LinkLabel FirstPageLabel;
        private System.Windows.Forms.LinkLabel LastPageLabel;
        private System.Windows.Forms.NumericUpDown pageNumberUpDown;
        private System.Windows.Forms.Button DeleteUserButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DownloadUserFileButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.TreeView UserFoldersTree;
        private System.Windows.Forms.Button FindUserFileButton;
        private System.Windows.Forms.Button DeleteUserFileButton;
        private System.Windows.Forms.ListView UserFilesList;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader Synchronized;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader HistorySpace;
        private System.Windows.Forms.Button FindUserButton;
        private System.Windows.Forms.Button EditUserButton;
        private System.Windows.Forms.Button HistoryUserButton;
        private System.Windows.Forms.Label label1;
    }
}

