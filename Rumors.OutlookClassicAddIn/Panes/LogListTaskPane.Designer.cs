namespace Rumors.OutlookClassicAddIn.Panes
{
    partial class LogListTaskPane
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_Log = new System.Windows.Forms.GroupBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.panel_logStatus = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Category = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Projects = new System.Windows.Forms.ComboBox();
            this.btn_ActionBtn = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lbl_status = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_LogDetails = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox_Log.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox_Log);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Search);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_Category);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_Projects);
            this.panel1.Location = new System.Drawing.Point(11, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 169);
            this.panel1.TabIndex = 2;
            // 
            // groupBox_Log
            // 
            this.groupBox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Log.Controls.Add(this.label_Status);
            this.groupBox_Log.Controls.Add(this.panel_logStatus);
            this.groupBox_Log.Location = new System.Drawing.Point(7, 76);
            this.groupBox_Log.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_Log.Name = "groupBox_Log";
            this.groupBox_Log.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_Log.Size = new System.Drawing.Size(343, 54);
            this.groupBox_Log.TabIndex = 7;
            this.groupBox_Log.TabStop = false;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(49, 14);
            this.label_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(44, 16);
            this.label_Status.TabIndex = 0;
            this.label_Status.Text = "label4";
            // 
            // panel_logStatus
            // 
            this.panel_logStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_logStatus.Location = new System.Drawing.Point(8, 14);
            this.panel_logStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_logStatus.Name = "panel_logStatus";
            this.panel_logStatus.Size = new System.Drawing.Size(33, 33);
            this.panel_logStatus.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Search";
            // 
            // txt_Search
            // 
            this.txt_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Search.Location = new System.Drawing.Point(69, 139);
            this.txt_Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(279, 22);
            this.txt_Search.TabIndex = 7;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(5, 1);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(345, 12);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(241, 615);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 28);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product:";
            // 
            // cmb_Category
            // 
            this.cmb_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Category.FormattingEnabled = true;
            this.cmb_Category.Location = new System.Drawing.Point(69, 49);
            this.cmb_Category.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_Category.Name = "cmb_Category";
            this.cmb_Category.Size = new System.Drawing.Size(279, 24);
            this.cmb_Category.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project:";
            // 
            // cmb_Projects
            // 
            this.cmb_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Projects.FormattingEnabled = true;
            this.cmb_Projects.Location = new System.Drawing.Point(69, 18);
            this.cmb_Projects.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_Projects.Name = "cmb_Projects";
            this.cmb_Projects.Size = new System.Drawing.Size(279, 24);
            this.cmb_Projects.TabIndex = 0;
            // 
            // btn_ActionBtn
            // 
            this.btn_ActionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ActionBtn.Location = new System.Drawing.Point(237, 7);
            this.btn_ActionBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ActionBtn.Name = "btn_ActionBtn";
            this.btn_ActionBtn.Size = new System.Drawing.Size(88, 28);
            this.btn_ActionBtn.TabIndex = 5;
            this.btn_ActionBtn.Text = "Sync";
            this.btn_ActionBtn.UseVisualStyleBackColor = true;
            this.btn_ActionBtn.Click += new System.EventHandler(this.RerunButton_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelStatus.Controls.Add(this.lbl_status);
            this.panelStatus.Location = new System.Drawing.Point(8, 7);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(223, 28);
            this.panelStatus.TabIndex = 6;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(4, 6);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(44, 16);
            this.lbl_status.TabIndex = 6;
            this.lbl_status.Text = "label4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_ActionBtn);
            this.panel2.Controls.Add(this.btn_Reload);
            this.panel2.Controls.Add(this.panelStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 44);
            this.panel2.TabIndex = 3;
            // 
            // btn_Reload
            // 
            this.btn_Reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reload.Image = global::Rumors.OutlookClassicAddIn.Properties.Resources.reload;
            this.btn_Reload.Location = new System.Drawing.Point(333, 7);
            this.btn_Reload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(31, 28);
            this.btn_Reload.TabIndex = 4;
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 225);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(353, 238);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_LogDetails);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 470);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(383, 142);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // txt_LogDetails
            // 
            this.txt_LogDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_LogDetails.Location = new System.Drawing.Point(4, 19);
            this.txt_LogDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_LogDetails.Multiline = true;
            this.txt_LogDetails.Name = "txt_LogDetails";
            this.txt_LogDetails.ReadOnly = true;
            this.txt_LogDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_LogDetails.Size = new System.Drawing.Size(375, 119);
            this.txt_LogDetails.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findEmailToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 28);
            // 
            // findEmailToolStripMenuItem
            // 
            this.findEmailToolStripMenuItem.Name = "findEmailToolStripMenuItem";
            this.findEmailToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.findEmailToolStripMenuItem.Text = "Open Email";
            this.findEmailToolStripMenuItem.Click += new System.EventHandler(this.findEmailToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // LogListTaskPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogListTaskPane";
            this.Size = new System.Drawing.Size(383, 612);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_Log.ResumeLayout(false);
            this.groupBox_Log.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Projects;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btn_ActionBtn;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_LogDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem findEmailToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_Log;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Panel panel_logStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
