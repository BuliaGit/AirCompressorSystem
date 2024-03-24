namespace UI
{
    partial class FrmReportQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportQuery));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ReportSet = new System.Windows.Forms.Button();
            this.cmb_Zone = new System.Windows.Forms.ComboBox();
            this.rdo_default = new System.Windows.Forms.RadioButton();
            this.rdo_SelfSet = new System.Windows.Forms.RadioButton();
            this.rdo_ZoneSel = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ReportSet);
            this.groupBox1.Controls.Add(this.cmb_Zone);
            this.groupBox1.Controls.Add(this.rdo_default);
            this.groupBox1.Controls.Add(this.rdo_SelfSet);
            this.groupBox1.Controls.Add(this.rdo_ZoneSel);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(35, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 209);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择查询条件";
            // 
            // btn_ReportSet
            // 
            this.btn_ReportSet.Enabled = false;
            this.btn_ReportSet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ReportSet.Location = new System.Drawing.Point(161, 156);
            this.btn_ReportSet.Name = "btn_ReportSet";
            this.btn_ReportSet.Size = new System.Drawing.Size(103, 28);
            this.btn_ReportSet.TabIndex = 30;
            this.btn_ReportSet.Text = "报表配置";
            this.btn_ReportSet.UseVisualStyleBackColor = true;
            this.btn_ReportSet.Click += new System.EventHandler(this.btn_ReportSet_Click);
            // 
            // cmb_Zone
            // 
            this.cmb_Zone.FormattingEnabled = true;
            this.cmb_Zone.Location = new System.Drawing.Point(161, 43);
            this.cmb_Zone.Name = "cmb_Zone";
            this.cmb_Zone.Size = new System.Drawing.Size(103, 28);
            this.cmb_Zone.TabIndex = 29;
            // 
            // rdo_default
            // 
            this.rdo_default.AutoSize = true;
            this.rdo_default.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_default.Location = new System.Drawing.Point(38, 101);
            this.rdo_default.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo_default.Name = "rdo_default";
            this.rdo_default.Size = new System.Drawing.Size(92, 23);
            this.rdo_default.TabIndex = 28;
            this.rdo_default.TabStop = true;
            this.rdo_default.Text = "按默认配置";
            this.rdo_default.UseVisualStyleBackColor = true;
            // 
            // rdo_SelfSet
            // 
            this.rdo_SelfSet.AutoSize = true;
            this.rdo_SelfSet.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_SelfSet.Location = new System.Drawing.Point(38, 158);
            this.rdo_SelfSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo_SelfSet.Name = "rdo_SelfSet";
            this.rdo_SelfSet.Size = new System.Drawing.Size(92, 23);
            this.rdo_SelfSet.TabIndex = 27;
            this.rdo_SelfSet.TabStop = true;
            this.rdo_SelfSet.Text = "自定义配置";
            this.rdo_SelfSet.UseVisualStyleBackColor = true;
            this.rdo_SelfSet.CheckedChanged += new System.EventHandler(this.rdo_SelfSet_CheckedChanged);
            // 
            // rdo_ZoneSel
            // 
            this.rdo_ZoneSel.AutoSize = true;
            this.rdo_ZoneSel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_ZoneSel.Location = new System.Drawing.Point(38, 46);
            this.rdo_ZoneSel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo_ZoneSel.Name = "rdo_ZoneSel";
            this.rdo_ZoneSel.Size = new System.Drawing.Size(92, 23);
            this.rdo_ZoneSel.TabIndex = 26;
            this.rdo_ZoneSel.TabStop = true;
            this.rdo_ZoneSel.Text = "按区域选择";
            this.rdo_ZoneSel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(81, 261);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 36;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(209, 261);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmReportQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 319);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmReportQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询条件";
            this.Load += new System.EventHandler(this.FrmReportQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ReportSet;
        private System.Windows.Forms.ComboBox cmb_Zone;
        internal System.Windows.Forms.RadioButton rdo_default;
        internal System.Windows.Forms.RadioButton rdo_SelfSet;
        internal System.Windows.Forms.RadioButton rdo_ZoneSel;
        protected System.Windows.Forms.Button btnOK;
        protected System.Windows.Forms.Button btnCancel;
    }
}