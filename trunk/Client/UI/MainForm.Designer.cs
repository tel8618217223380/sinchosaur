namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader Number;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listServerFiles = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Folder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSettings = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerSinchronize = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonRefresh = new System.Windows.Forms.Button();
            Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Number
            // 
            Number.Text = "#";
            Number.Width = 23;
            // 
            // listServerFiles
            // 
            this.listServerFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listServerFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Number,
            this.FileName,
            this.Folder,
            this.Size,
            this.Status});
            this.listServerFiles.Location = new System.Drawing.Point(12, 12);
            this.listServerFiles.Name = "listServerFiles";
            this.listServerFiles.Size = new System.Drawing.Size(503, 322);
            this.listServerFiles.TabIndex = 0;
            this.listServerFiles.UseCompatibleStateImageBehavior = false;
            this.listServerFiles.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "Файл";
            this.FileName.Width = 130;
            // 
            // Folder
            // 
            this.Folder.Text = "Каталог";
            this.Folder.Width = 160;
            // 
            // Size
            // 
            this.Size.Text = "Размер";
            this.Size.Width = 90;
            // 
            // Status
            // 
            this.Status.Text = "Статус";
            this.Status.Width = 90;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Location = new System.Drawing.Point(521, 94);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(119, 31);
            this.buttonSettings.TabIndex = 4;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Sinchronizer\\n Подключение к серверу";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.eventsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.trayContextMenu.Name = "contextMenuStrip1";
            this.trayContextMenu.Size = new System.Drawing.Size(165, 136);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem1.Text = "Открыть папку";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // eventsToolStripMenuItem
            // 
            this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
            this.eventsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.eventsToolStripMenuItem.Text = "События";
            this.eventsToolStripMenuItem.Click += new System.EventHandler(this.eventsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem2.Text = "Настройки";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timerSinchronize
            // 
            this.timerSinchronize.Enabled = true;
            this.timerSinchronize.Interval = 7000;
            this.timerSinchronize.Tick += new System.EventHandler(this.timerSinchronize_Tick);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(521, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(119, 31);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 349);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listServerFiles);
            this.Controls.Add(this.buttonSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(575, 380);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listServerFiles;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Folder;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timerSinchronize;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
    }
}

