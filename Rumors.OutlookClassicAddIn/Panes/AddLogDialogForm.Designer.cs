namespace Rumors.OutlookClassicAddIn.Panes
{
    partial class AddLogDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLogDialogForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.grp_Version = new System.Windows.Forms.GroupBox();
            this.btn_clearImage = new System.Windows.Forms.Button();
            this.btn_InsertImage = new System.Windows.Forms.Button();
            this.img_Screenshot = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_VersionName = new System.Windows.Forms.TextBox();
            this.cbx_CreateVersion = new System.Windows.Forms.CheckBox();
            this.grp_Log = new System.Windows.Forms.GroupBox();
            this.btn_addPerson = new System.Windows.Forms.Button();
            this.pbx_Status = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Message = new System.Windows.Forms.TextBox();
            this.cmb_Persons = new System.Windows.Forms.ComboBox();
            this.cmb_Statuses = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Category = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Projects = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.grp_Version.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Screenshot)).BeginInit();
            this.grp_Log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Status)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.grp_Version);
            this.panel1.Controls.Add(this.grp_Log);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_Category);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_Projects);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 488);
            this.panel1.TabIndex = 2;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(461, 450);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 28);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // grp_Version
            // 
            this.grp_Version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_Version.Controls.Add(this.btn_clearImage);
            this.grp_Version.Controls.Add(this.btn_InsertImage);
            this.grp_Version.Controls.Add(this.img_Screenshot);
            this.grp_Version.Controls.Add(this.label3);
            this.grp_Version.Controls.Add(this.txt_VersionName);
            this.grp_Version.Controls.Add(this.cbx_CreateVersion);
            this.grp_Version.Location = new System.Drawing.Point(4, 221);
            this.grp_Version.Margin = new System.Windows.Forms.Padding(4);
            this.grp_Version.Name = "grp_Version";
            this.grp_Version.Padding = new System.Windows.Forms.Padding(4);
            this.grp_Version.Size = new System.Drawing.Size(565, 221);
            this.grp_Version.TabIndex = 5;
            this.grp_Version.TabStop = false;
            this.grp_Version.Text = "New Version";
            // 
            // btn_clearImage
            // 
            this.btn_clearImage.Enabled = false;
            this.btn_clearImage.Location = new System.Drawing.Point(8, 128);
            this.btn_clearImage.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clearImage.Name = "btn_clearImage";
            this.btn_clearImage.Size = new System.Drawing.Size(62, 28);
            this.btn_clearImage.TabIndex = 9;
            this.btn_clearImage.Text = "Clear";
            this.btn_clearImage.UseVisualStyleBackColor = true;
            this.btn_clearImage.Click += new System.EventHandler(this.btn_clearImage_Click);
            // 
            // btn_InsertImage
            // 
            this.btn_InsertImage.Enabled = false;
            this.btn_InsertImage.Location = new System.Drawing.Point(8, 92);
            this.btn_InsertImage.Margin = new System.Windows.Forms.Padding(4);
            this.btn_InsertImage.Name = "btn_InsertImage";
            this.btn_InsertImage.Size = new System.Drawing.Size(62, 28);
            this.btn_InsertImage.TabIndex = 8;
            this.btn_InsertImage.Text = "Insert";
            this.btn_InsertImage.UseVisualStyleBackColor = true;
            this.btn_InsertImage.Click += new System.EventHandler(this.btn_InsertImage_Click);
            // 
            // img_Screenshot
            // 
            this.img_Screenshot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img_Screenshot.Location = new System.Drawing.Point(77, 88);
            this.img_Screenshot.Margin = new System.Windows.Forms.Padding(4);
            this.img_Screenshot.Name = "img_Screenshot";
            this.img_Screenshot.Size = new System.Drawing.Size(480, 119);
            this.img_Screenshot.TabIndex = 7;
            this.img_Screenshot.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // txt_VersionName
            // 
            this.txt_VersionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_VersionName.Enabled = false;
            this.txt_VersionName.Location = new System.Drawing.Point(77, 46);
            this.txt_VersionName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_VersionName.Name = "txt_VersionName";
            this.txt_VersionName.Size = new System.Drawing.Size(480, 22);
            this.txt_VersionName.TabIndex = 1;
            this.txt_VersionName.TextChanged += new System.EventHandler(this.txt_Message_TextChanged);
            // 
            // cbx_CreateVersion
            // 
            this.cbx_CreateVersion.AutoSize = true;
            this.cbx_CreateVersion.Location = new System.Drawing.Point(8, 23);
            this.cbx_CreateVersion.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_CreateVersion.Name = "cbx_CreateVersion";
            this.cbx_CreateVersion.Size = new System.Drawing.Size(118, 20);
            this.cbx_CreateVersion.TabIndex = 0;
            this.cbx_CreateVersion.Text = "Create Version";
            this.cbx_CreateVersion.UseVisualStyleBackColor = true;
            this.cbx_CreateVersion.CheckedChanged += new System.EventHandler(this.cbx_CreateVersion_CheckedChanged);
            // 
            // grp_Log
            // 
            this.grp_Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_Log.Controls.Add(this.btn_addPerson);
            this.grp_Log.Controls.Add(this.pbx_Status);
            this.grp_Log.Controls.Add(this.label4);
            this.grp_Log.Controls.Add(this.txt_Message);
            this.grp_Log.Controls.Add(this.cmb_Persons);
            this.grp_Log.Controls.Add(this.cmb_Statuses);
            this.grp_Log.Controls.Add(this.label5);
            this.grp_Log.Location = new System.Drawing.Point(4, 71);
            this.grp_Log.Margin = new System.Windows.Forms.Padding(4);
            this.grp_Log.Name = "grp_Log";
            this.grp_Log.Padding = new System.Windows.Forms.Padding(4);
            this.grp_Log.Size = new System.Drawing.Size(565, 153);
            this.grp_Log.TabIndex = 4;
            this.grp_Log.TabStop = false;
            this.grp_Log.Text = "Log";
            // 
            // btn_addPerson
            // 
            this.btn_addPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addPerson.Location = new System.Drawing.Point(513, 109);
            this.btn_addPerson.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addPerson.Name = "btn_addPerson";
            this.btn_addPerson.Size = new System.Drawing.Size(45, 28);
            this.btn_addPerson.TabIndex = 11;
            this.btn_addPerson.Text = "+";
            this.btn_addPerson.UseVisualStyleBackColor = true;
            this.btn_addPerson.Click += new System.EventHandler(this.btn_addPerson_Click);
            // 
            // pbx_Status
            // 
            this.pbx_Status.Location = new System.Drawing.Point(316, 80);
            this.pbx_Status.Margin = new System.Windows.Forms.Padding(4);
            this.pbx_Status.Name = "pbx_Status";
            this.pbx_Status.Size = new System.Drawing.Size(53, 25);
            this.pbx_Status.TabIndex = 10;
            this.pbx_Status.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Set By";
            // 
            // txt_Message
            // 
            this.txt_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Message.Location = new System.Drawing.Point(5, 23);
            this.txt_Message.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Message.Multiline = true;
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.Size = new System.Drawing.Size(552, 48);
            this.txt_Message.TabIndex = 10;
            this.txt_Message.TextChanged += new System.EventHandler(this.txt_Message_TextChanged);
            // 
            // cmb_Persons
            // 
            this.cmb_Persons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Persons.FormattingEnabled = true;
            this.cmb_Persons.Location = new System.Drawing.Point(77, 112);
            this.cmb_Persons.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Persons.Name = "cmb_Persons";
            this.cmb_Persons.Size = new System.Drawing.Size(427, 24);
            this.cmb_Persons.TabIndex = 8;
            // 
            // cmb_Statuses
            // 
            this.cmb_Statuses.FormattingEnabled = true;
            this.cmb_Statuses.Location = new System.Drawing.Point(77, 79);
            this.cmb_Statuses.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Statuses.Name = "cmb_Statuses";
            this.cmb_Statuses.Size = new System.Drawing.Size(229, 24);
            this.cmb_Statuses.TabIndex = 6;
            this.cmb_Statuses.SelectionChangeCommitted += new System.EventHandler(this.cmb_Statuses_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Category";
            // 
            // cmb_Category
            // 
            this.cmb_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Category.FormattingEnabled = true;
            this.cmb_Category.Location = new System.Drawing.Point(81, 40);
            this.cmb_Category.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Category.Name = "cmb_Category";
            this.cmb_Category.Size = new System.Drawing.Size(487, 24);
            this.cmb_Category.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project";
            // 
            // cmb_Projects
            // 
            this.cmb_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Projects.FormattingEnabled = true;
            this.cmb_Projects.Location = new System.Drawing.Point(81, 7);
            this.cmb_Projects.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Projects.Name = "cmb_Projects";
            this.cmb_Projects.Size = new System.Drawing.Size(487, 24);
            this.cmb_Projects.TabIndex = 0;
            // 
            // AddLogDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 510);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddLogDialogForm";
            this.Text = "Check In Email";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grp_Version.ResumeLayout(false);
            this.grp_Version.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Screenshot)).EndInit();
            this.grp_Log.ResumeLayout(false);
            this.grp_Log.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Status)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox grp_Version;
        private System.Windows.Forms.Button btn_clearImage;
        private System.Windows.Forms.Button btn_InsertImage;
        private System.Windows.Forms.PictureBox img_Screenshot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_VersionName;
        private System.Windows.Forms.CheckBox cbx_CreateVersion;
        private System.Windows.Forms.GroupBox grp_Log;
        private System.Windows.Forms.Button btn_addPerson;
        private System.Windows.Forms.PictureBox pbx_Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Message;
        private System.Windows.Forms.ComboBox cmb_Persons;
        private System.Windows.Forms.ComboBox cmb_Statuses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Projects;
    }
}