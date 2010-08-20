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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Folder1_1");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Folder1_2");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Folder1", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Folder2");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.ColumnHeader File;
            this.listView1 = new System.Windows.Forms.ListView();
            this.SpaceLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nextLabel = new System.Windows.Forms.LinkLabel();
            this.prevLabel = new System.Windows.Forms.LinkLabel();
            this.firstLabel = new System.Windows.Forms.LinkLabel();
            this.lastLabel = new System.Windows.Forms.LinkLabel();
            this.pageNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FoldersTree = new System.Windows.Forms.TreeView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Synchronized = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.HistorySpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Id,
            Email,
            this.SpaceLimit,
            this.HistorySpace,
            this.Created});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(15, 37);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(577, 224);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // SpaceLimit
            // 
            this.SpaceLimit.Text = "Space limit";
            this.SpaceLimit.Width = 96;
            // 
            // Created
            // 
            this.Created.Text = "Created";
            this.Created.Width = 91;
            // 
            // nextLabel
            // 
            this.nextLabel.AutoSize = true;
            this.nextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextLabel.Location = new System.Drawing.Point(344, 272);
            this.nextLabel.Name = "nextLabel";
            this.nextLabel.Size = new System.Drawing.Size(15, 16);
            this.nextLabel.TabIndex = 2;
            this.nextLabel.TabStop = true;
            this.nextLabel.Text = ">";
            // 
            // prevLabel
            // 
            this.prevLabel.AutoSize = true;
            this.prevLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prevLabel.Location = new System.Drawing.Point(255, 272);
            this.prevLabel.Name = "prevLabel";
            this.prevLabel.Size = new System.Drawing.Size(15, 16);
            this.prevLabel.TabIndex = 3;
            this.prevLabel.TabStop = true;
            this.prevLabel.Text = "<";
            // 
            // firstLabel
            // 
            this.firstLabel.AutoSize = true;
            this.firstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstLabel.Location = new System.Drawing.Point(230, 272);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(22, 16);
            this.firstLabel.TabIndex = 5;
            this.firstLabel.TabStop = true;
            this.firstLabel.Text = "<<";
            // 
            // lastLabel
            // 
            this.lastLabel.AutoSize = true;
            this.lastLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastLabel.Location = new System.Drawing.Point(361, 272);
            this.lastLabel.Name = "lastLabel";
            this.lastLabel.Size = new System.Drawing.Size(22, 16);
            this.lastLabel.TabIndex = 4;
            this.lastLabel.TabStop = true;
            this.lastLabel.Text = ">>";
            // 
            // pageNumberUpDown
            // 
            this.pageNumberUpDown.Location = new System.Drawing.Point(273, 270);
            this.pageNumberUpDown.Name = "pageNumberUpDown";
            this.pageNumberUpDown.Size = new System.Drawing.Size(65, 20);
            this.pageNumberUpDown.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(598, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.nextLabel);
            this.groupBox1.Controls.Add(this.prevLabel);
            this.groupBox1.Controls.Add(this.pageNumberUpDown);
            this.groupBox1.Controls.Add(this.lastLabel);
            this.groupBox1.Controls.Add(this.firstLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 303);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(598, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Download";
            this.button3.UseVisualStyleBackColor = true;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(598, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FoldersTree
            // 
            this.FoldersTree.Location = new System.Drawing.Point(15, 42);
            this.FoldersTree.Name = "FoldersTree";
            treeNode11.Name = "Folder1_1";
            treeNode11.Text = "Folder1_1";
            treeNode12.Name = "Folder1_2";
            treeNode12.Text = "Folder1_2";
            treeNode13.Name = "Folder1";
            treeNode13.Text = "Folder1";
            treeNode14.Name = "Folder2";
            treeNode14.Text = "Folder2";
            treeNode15.Name = "Root";
            treeNode15.Text = "Root";
            this.FoldersTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.FoldersTree.Size = new System.Drawing.Size(144, 240);
            this.FoldersTree.TabIndex = 11;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            File,
            this.Size,
            this.Synchronized});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(165, 42);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(427, 240);
            this.listView2.TabIndex = 12;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.listView2);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.FoldersTree);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(12, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 295);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // File
            // 
            File.Text = "File";
            File.Width = 211;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(598, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(598, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Find";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(598, 153);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "Edit";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // HistorySpace
            // 
            this.HistorySpace.Text = "History Space";
            this.HistorySpace.Width = 97;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(598, 37);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Find";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(598, 80);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(90, 23);
            this.button9.TabIndex = 13;
            this.button9.Text = "History";
            this.button9.UseVisualStyleBackColor = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 622);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Admin Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader SpaceLimit;
        private System.Windows.Forms.ColumnHeader Created;
        private System.Windows.Forms.LinkLabel nextLabel;
        private System.Windows.Forms.LinkLabel prevLabel;
        private System.Windows.Forms.LinkLabel firstLabel;
        private System.Windows.Forms.LinkLabel lastLabel;
        private System.Windows.Forms.NumericUpDown pageNumberUpDown;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView FoldersTree;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader Synchronized;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader HistorySpace;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
    }
}

