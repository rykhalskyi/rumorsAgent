namespace Rumors.OutlookClassicAddIn.Panes
{
    partial class AutoRecognizePane
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
            this.btn_one = new System.Windows.Forms.Button();
            this.btn_two = new System.Windows.Forms.Button();
            this.txb_out = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_one
            // 
            this.btn_one.Location = new System.Drawing.Point(4, 4);
            this.btn_one.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_one.Name = "btn_one";
            this.btn_one.Size = new System.Drawing.Size(100, 28);
            this.btn_one.TabIndex = 0;
            this.btn_one.Text = "Func One";
            this.btn_one.UseVisualStyleBackColor = true;
            this.btn_one.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_two
            // 
            this.btn_two.Location = new System.Drawing.Point(112, 4);
            this.btn_two.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_two.Name = "btn_two";
            this.btn_two.Size = new System.Drawing.Size(100, 28);
            this.btn_two.TabIndex = 1;
            this.btn_two.Text = "Func Two";
            this.btn_two.UseVisualStyleBackColor = true;
            this.btn_two.Click += new System.EventHandler(this.button2_Click);
            // 
            // txb_out
            // 
            this.txb_out.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_out.Location = new System.Drawing.Point(4, 39);
            this.txb_out.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_out.Multiline = true;
            this.txb_out.Name = "txb_out";
            this.txb_out.ReadOnly = true;
            this.txb_out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_out.Size = new System.Drawing.Size(423, 651);
            this.txb_out.TabIndex = 2;
            // 
            // AutoRecognizePane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txb_out);
            this.Controls.Add(this.btn_two);
            this.Controls.Add(this.btn_one);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AutoRecognizePane";
            this.Size = new System.Drawing.Size(432, 706);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_one;
        private System.Windows.Forms.Button btn_two;
        private System.Windows.Forms.TextBox txb_out;
    }
}
