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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_Chat = new System.Windows.Forms.TextBox();
            this.btn_SendMessage = new System.Windows.Forms.Button();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txt_Chat);
            this.groupBox3.Controls.Add(this.btn_SendMessage);
            this.groupBox3.Controls.Add(this.txt_Input);
            this.groupBox3.Location = new System.Drawing.Point(4, 41);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(339, 705);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Agent";
            // 
            // txt_Chat
            // 
            this.txt_Chat.AcceptsReturn = true;
            this.txt_Chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Chat.Location = new System.Drawing.Point(9, 119);
            this.txt_Chat.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Chat.Multiline = true;
            this.txt_Chat.Name = "txt_Chat";
            this.txt_Chat.ReadOnly = true;
            this.txt_Chat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Chat.Size = new System.Drawing.Size(313, 544);
            this.txt_Chat.TabIndex = 3;
            // 
            // btn_SendMessage
            // 
            this.btn_SendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SendMessage.Enabled = false;
            this.btn_SendMessage.Location = new System.Drawing.Point(267, 669);
            this.btn_SendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SendMessage.Name = "btn_SendMessage";
            this.btn_SendMessage.Size = new System.Drawing.Size(55, 34);
            this.btn_SendMessage.TabIndex = 2;
            this.btn_SendMessage.Text = "Clear";
            this.btn_SendMessage.UseVisualStyleBackColor = true;
            this.btn_SendMessage.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // txt_Input
            // 
            this.txt_Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Input.Location = new System.Drawing.Point(8, 30);
            this.txt_Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Input.Multiline = true;
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(314, 83);
            this.txt_Input.TabIndex = 0;
            this.txt_Input.TextChanged += new System.EventHandler(this.txt_Input_TextChanged);
            this.txt_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Input_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(4, 7);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(339, 28);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // GetStatusPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GetStatusPane";
            this.Size = new System.Drawing.Size(355, 750);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_SendMessage;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.TextBox txt_Chat;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
