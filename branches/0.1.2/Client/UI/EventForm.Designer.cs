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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventForm));
            System.Windows.Forms.ColumnHeader Size;
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
            // Created
            // 
            resources.ApplyResources(Created, "Created");
            // 
            // Size
            // 
            resources.ApplyResources(Size, "Size");
            // 
            // listUserEvents
            // 
            resources.ApplyResources(this.listUserEvents, "listUserEvents");
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
            this.listUserEvents.Name = "listUserEvents";
            this.listUserEvents.UseCompatibleStateImageBehavior = false;
            this.listUserEvents.View = System.Windows.Forms.View.Details;
            this.listUserEvents.DoubleClick += new System.EventHandler(this.buttonDownload_Click);
            // 
            // Description
            // 
            resources.ApplyResources(this.Description, "Description");
            // 
            // FileName
            // 
            resources.ApplyResources(this.FileName, "FileName");
            // 
            // Directory
            // 
            resources.ApplyResources(this.Directory, "Directory");
            // 
            // FileSize
            // 
            resources.ApplyResources(this.FileSize, "FileSize");
            // 
            // FileId
            // 
            resources.ApplyResources(this.FileId, "FileId");
            // 
            // buttonDownload
            // 
            resources.ApplyResources(this.buttonDownload, "buttonDownload");
            this.buttonDownload.Name = "buttonDownload";
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
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.listUserEvents);
            this.Name = "EventForm";
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