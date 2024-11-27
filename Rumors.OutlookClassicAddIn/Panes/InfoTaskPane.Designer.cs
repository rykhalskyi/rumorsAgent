namespace Rumors.OutlookClassicAddIn.Panes
{
    partial class InfoTaskPane
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
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_Conversation = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Info
            // 
            this.txt_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Info.Location = new System.Drawing.Point(3, 3);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Info.Size = new System.Drawing.Size(286, 504);
            this.txt_Info.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 539);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_Info);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(292, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Email";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_Conversation);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(292, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Conversation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_Conversation
            // 
            this.txt_Conversation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Conversation.Location = new System.Drawing.Point(3, 3);
            this.txt_Conversation.Multiline = true;
            this.txt_Conversation.Name = "txt_Conversation";
            this.txt_Conversation.ReadOnly = true;
            this.txt_Conversation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Conversation.Size = new System.Drawing.Size(286, 504);
            this.txt_Conversation.TabIndex = 3;
            // 
            // InfoTaskPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "InfoTaskPane";
            this.Size = new System.Drawing.Size(300, 539);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_Conversation;
    }
}
