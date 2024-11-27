namespace Rumors.OutlookClassicAddIn.Panes
{
    partial class GetStatusPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_GetStory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Category = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Projects = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtStory = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_Chat = new System.Windows.Forms.TextBox();
            this.btn_AskAi = new System.Windows.Forms.Button();
            this.txt_Question = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_GetStory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_Category);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_Projects);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btn_GetStory
            // 
            this.btn_GetStory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetStory.Location = new System.Drawing.Point(150, 64);
            this.btn_GetStory.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GetStory.Name = "btn_GetStory";
            this.btn_GetStory.Size = new System.Drawing.Size(98, 30);
            this.btn_GetStory.TabIndex = 15;
            this.btn_GetStory.Text = "Make Story";
            this.btn_GetStory.UseVisualStyleBackColor = true;
            this.btn_GetStory.Click += new System.EventHandler(this.btn_FindEmail_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Category";
            // 
            // cmb_Category
            // 
            this.cmb_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Category.FormattingEnabled = true;
            this.cmb_Category.Location = new System.Drawing.Point(53, 39);
            this.cmb_Category.Name = "cmb_Category";
            this.cmb_Category.Size = new System.Drawing.Size(195, 21);
            this.cmb_Category.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Project";
            // 
            // cmb_Projects
            // 
            this.cmb_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Projects.FormattingEnabled = true;
            this.cmb_Projects.Location = new System.Drawing.Point(53, 13);
            this.cmb_Projects.Name = "cmb_Projects";
            this.cmb_Projects.Size = new System.Drawing.Size(195, 21);
            this.cmb_Projects.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtStory);
            this.groupBox2.Location = new System.Drawing.Point(3, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 151);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Story";
            // 
            // txtStory
            // 
            this.txtStory.AcceptsReturn = true;
            this.txtStory.AcceptsTab = true;
            this.txtStory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStory.Location = new System.Drawing.Point(3, 16);
            this.txtStory.Multiline = true;
            this.txtStory.Name = "txtStory";
            this.txtStory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStory.Size = new System.Drawing.Size(251, 132);
            this.txtStory.TabIndex = 0;
            this.txtStory.TextChanged += new System.EventHandler(this.txtStory_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txt_Chat);
            this.groupBox3.Controls.Add(this.btn_AskAi);
            this.groupBox3.Controls.Add(this.txt_Question);
            this.groupBox3.Location = new System.Drawing.Point(3, 296);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(254, 310);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ask AI";
            // 
            // txt_Chat
            // 
            this.txt_Chat.AcceptsReturn = true;
            this.txt_Chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Chat.Location = new System.Drawing.Point(7, 58);
            this.txt_Chat.Multiline = true;
            this.txt_Chat.Name = "txt_Chat";
            this.txt_Chat.ReadOnly = true;
            this.txt_Chat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Chat.Size = new System.Drawing.Size(236, 247);
            this.txt_Chat.TabIndex = 3;
            // 
            // btn_AskAi
            // 
            this.btn_AskAi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AskAi.Enabled = false;
            this.btn_AskAi.Location = new System.Drawing.Point(202, 16);
            this.btn_AskAi.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AskAi.Name = "btn_AskAi";
            this.btn_AskAi.Size = new System.Drawing.Size(41, 28);
            this.btn_AskAi.TabIndex = 2;
            this.btn_AskAi.Text = "Send";
            this.btn_AskAi.UseVisualStyleBackColor = true;
            this.btn_AskAi.Click += new System.EventHandler(this.btn_AskAi_Click);
            // 
            // txt_Question
            // 
            this.txt_Question.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Question.Location = new System.Drawing.Point(6, 24);
            this.txt_Question.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Question.Name = "txt_Question";
            this.txt_Question.Size = new System.Drawing.Size(192, 20);
            this.txt_Question.TabIndex = 0;
            this.txt_Question.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(3, 6);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(254, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 7;
            // 
            // GetStatusPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GetStatusPane";
            this.Size = new System.Drawing.Size(266, 609);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_GetStory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Projects;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtStory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_AskAi;
        private System.Windows.Forms.TextBox txt_Question;
        private System.Windows.Forms.TextBox txt_Chat;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
