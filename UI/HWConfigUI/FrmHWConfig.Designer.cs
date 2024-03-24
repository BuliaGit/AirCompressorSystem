namespace UI.HWConfigUI
{
    partial class FrmHWConfig
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnTrend = new System.Windows.Forms.Button();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.btnParam = new System.Windows.Forms.Button();
            this.btnIO = new System.Windows.Forms.Button();
            this.btnProtocol = new System.Windows.Forms.Button();
            this.rightPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.leftPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rightPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1366, 618);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(165)))));
            this.leftPanel.Controls.Add(this.btnUser);
            this.leftPanel.Controls.Add(this.btnReport);
            this.leftPanel.Controls.Add(this.btnTrend);
            this.leftPanel.Controls.Add(this.btnAlarm);
            this.leftPanel.Controls.Add(this.btnParam);
            this.leftPanel.Controls.Add(this.btnIO);
            this.leftPanel.Controls.Add(this.btnProtocol);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(215, 618);
            this.leftPanel.TabIndex = 0;
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.LightBlue;
            this.btnUser.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUser.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnUser.Location = new System.Drawing.Point(28, 478);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(162, 39);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "用户权限配置";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.LightBlue;
            this.btnReport.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReport.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnReport.Location = new System.Drawing.Point(28, 405);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(162, 39);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "报表配置";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnTrend
            // 
            this.btnTrend.BackColor = System.Drawing.Color.LightBlue;
            this.btnTrend.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTrend.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnTrend.Location = new System.Drawing.Point(28, 332);
            this.btnTrend.Name = "btnTrend";
            this.btnTrend.Size = new System.Drawing.Size(162, 39);
            this.btnTrend.TabIndex = 0;
            this.btnTrend.Text = "趋势信息配置";
            this.btnTrend.UseVisualStyleBackColor = false;
            this.btnTrend.Click += new System.EventHandler(this.btnTrend_Click);
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.LightBlue;
            this.btnAlarm.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAlarm.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAlarm.Location = new System.Drawing.Point(28, 259);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(162, 39);
            this.btnAlarm.TabIndex = 0;
            this.btnAlarm.Text = "报警信息配置";
            this.btnAlarm.UseVisualStyleBackColor = false;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // btnParam
            // 
            this.btnParam.BackColor = System.Drawing.Color.LightBlue;
            this.btnParam.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnParam.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnParam.Location = new System.Drawing.Point(28, 186);
            this.btnParam.Name = "btnParam";
            this.btnParam.Size = new System.Drawing.Size(162, 39);
            this.btnParam.TabIndex = 0;
            this.btnParam.Text = "参数配置";
            this.btnParam.UseVisualStyleBackColor = false;
            this.btnParam.Click += new System.EventHandler(this.btnParam_Click);
            // 
            // btnIO
            // 
            this.btnIO.BackColor = System.Drawing.Color.LightBlue;
            this.btnIO.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIO.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnIO.Location = new System.Drawing.Point(28, 113);
            this.btnIO.Name = "btnIO";
            this.btnIO.Size = new System.Drawing.Size(162, 39);
            this.btnIO.TabIndex = 0;
            this.btnIO.Text = "IO变量配置";
            this.btnIO.UseVisualStyleBackColor = false;
            this.btnIO.Click += new System.EventHandler(this.btnIO_Click);
            // 
            // btnProtocol
            // 
            this.btnProtocol.BackColor = System.Drawing.Color.LightBlue;
            this.btnProtocol.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProtocol.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnProtocol.Location = new System.Drawing.Point(28, 40);
            this.btnProtocol.Name = "btnProtocol";
            this.btnProtocol.Size = new System.Drawing.Size(162, 39);
            this.btnProtocol.TabIndex = 0;
            this.btnProtocol.Text = "协议信息配置";
            this.btnProtocol.UseVisualStyleBackColor = false;
            this.btnProtocol.Click += new System.EventHandler(this.btnProtocol_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rightPanel.Location = new System.Drawing.Point(0, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(1150, 618);
            this.rightPanel.TabIndex = 0;
            // 
            // FrmHWConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 618);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "FrmHWConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHWConfig";
            this.Load += new System.EventHandler(this.FrmHWConfig_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Button btnProtocol;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnTrend;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.Button btnParam;
        private System.Windows.Forms.Button btnIO;
    }
}