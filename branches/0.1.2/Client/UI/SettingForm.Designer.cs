namespace Client
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelServerIp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonChoiseFolder = new System.Windows.Forms.Button();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.textBoxPasswd = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.textBoxStorageFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.labelLang = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxLang = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelServerIp
            // 
            resources.ApplyResources(this.labelServerIp, "labelServerIp");
            this.labelServerIp.Name = "labelServerIp";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonChoiseFolder);
            this.groupBox1.Controls.Add(this.textBoxServerIP);
            this.groupBox1.Controls.Add(this.textBoxPasswd);
            this.groupBox1.Controls.Add(this.labelPass);
            this.groupBox1.Controls.Add(this.labelEmail);
            this.groupBox1.Controls.Add(this.textBoxLogin);
            this.groupBox1.Controls.Add(this.labelDirectory);
            this.groupBox1.Controls.Add(this.textBoxStorageFolder);
            this.groupBox1.Controls.Add(this.labelServerIp);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // buttonChoiseFolder
            // 
            resources.ApplyResources(this.buttonChoiseFolder, "buttonChoiseFolder");
            this.buttonChoiseFolder.Name = "buttonChoiseFolder";
            this.buttonChoiseFolder.UseVisualStyleBackColor = true;
            this.buttonChoiseFolder.Click += new System.EventHandler(this.buttonChoiseFolder_Click);
            // 
            // textBoxServerIP
            // 
            resources.ApplyResources(this.textBoxServerIP, "textBoxServerIP");
            this.textBoxServerIP.Name = "textBoxServerIP";
            // 
            // textBoxPasswd
            // 
            resources.ApplyResources(this.textBoxPasswd, "textBoxPasswd");
            this.textBoxPasswd.Name = "textBoxPasswd";
            // 
            // labelPass
            // 
            resources.ApplyResources(this.labelPass, "labelPass");
            this.labelPass.Name = "labelPass";
            // 
            // labelEmail
            // 
            resources.ApplyResources(this.labelEmail, "labelEmail");
            this.labelEmail.Name = "labelEmail";
            // 
            // textBoxLogin
            // 
            resources.ApplyResources(this.textBoxLogin, "textBoxLogin");
            this.textBoxLogin.Name = "textBoxLogin";
            // 
            // labelDirectory
            // 
            resources.ApplyResources(this.labelDirectory, "labelDirectory");
            this.labelDirectory.Name = "labelDirectory";
            // 
            // textBoxStorageFolder
            // 
            this.textBoxStorageFolder.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBoxStorageFolder, "textBoxStorageFolder");
            this.textBoxStorageFolder.Name = "textBoxStorageFolder";
            this.textBoxStorageFolder.ReadOnly = true;
            // 
            // checkBoxAutoStart
            // 
            resources.ApplyResources(this.checkBoxAutoStart, "checkBoxAutoStart");
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // labelLang
            // 
            resources.ApplyResources(this.labelLang, "labelLang");
            this.labelLang.Name = "labelLang";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxLang);
            this.groupBox2.Controls.Add(this.checkBoxAutoStart);
            this.groupBox2.Controls.Add(this.labelLang);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // comboBoxLang
            // 
            this.comboBoxLang.AllowDrop = true;
            this.comboBoxLang.Items.AddRange(new object[] {
            resources.GetString("comboBoxLang.Items"),
            resources.GetString("comboBoxLang.Items1")});
            resources.ApplyResources(this.comboBoxLang, "comboBoxLang");
            this.comboBoxLang.Name = "comboBoxLang";
            // 
            // SettingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSave);
            this.Name = "SettingForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelServerIp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.TextBox textBoxStorageFolder;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxPasswd;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Button buttonChoiseFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.Label labelLang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxLang;
    }
}