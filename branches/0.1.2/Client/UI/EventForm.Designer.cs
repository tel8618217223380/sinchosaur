namespace Client
{
    partial class EventForm
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
            System.Windows.Forms.ColumnHeader Created;
            System.Windows.Forms.ColumnHeader Size;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventForm));
            this.listUserEvents = new System.Windows.Forms.ListView();
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Directory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDownload = new System.Windows.Forms.Button();
            this.backgroundDownloader = new System.ComponentModel.BackgroundWorker();
            Created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listUserEvents
            // 
            this.listUserEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listUserEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Description,
            this.FileName,
            this.Directory,
            this.FileSize,
            Created,
            Size,
            this.FileId});
            this.listUserEvents.FullRowSelect = true;
            this.listUserEvents.GridLines = true;
            this.listUserEvents.Location = new System.Drawing.Point(12, 12);
            this.listUserEvents.Name = "listUserEvents";
            this.listUserEvents.Size = new System.Drawing.Size(694, 313);
            this.listUserEvents.TabIndex = 0;
            this.listUserEvents.UseCompatibleStateImageBehavior = false;
            this.listUserEvents.View = System.Windows.Forms.View.Details;
            this.listUserEvents.DoubleClick += new System.EventHandler(this.buttonDownload_Click);
            // 
            // Description
            // 
            this.Description.Text = "Действие";
            this.Description.Width = 68;
            // 
            // FileName
            // 
            this.FileName.Text = "Файл";
            this.FileName.Width = 218;
            // 
            // Directory
            // 
            this.Directory.Text = "Директория";
            this.Directory.Width = 218;
            // 
            // FileSize
            // 
            this.FileSize.Text = "Размер";
            this.FileSize.Width = 73;
            // 
            // Created
            // 
            Created.Text = "Синхронизирован";
            Created.Width = 111;
            // 
            // Size
            // 
            Size.Width = 0;
            // 
            // FileId
            // 
            this.FileId.Text = "id";
            this.FileId.Width = 0;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDownload.Location = new System.Drawing.Point(263, 331);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(179, 33);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Скачать файл";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // backgroundDownloader
            // 
            this.backgroundDownloader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundDownloader_DoWork);
            this.backgroundDownloader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundDownloader_RunWorkerCompleted);
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 375);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.listUserEvents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "События";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listUserEvents;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Directory;
        private System.Windows.Forms.ColumnHeader FileSize;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ColumnHeader FileId;
        private System.ComponentModel.BackgroundWorker backgroundDownloader;
        private System.Windows.Forms.ColumnHeader Description;

    }
}