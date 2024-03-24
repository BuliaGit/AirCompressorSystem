namespace UI
{
    partial class FrmReportConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportConfig));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.btn_DelAll = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selectList = new System.Windows.Forms.ListBox();
            this.btn_AddAll = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.unSelectList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.Location = new System.Drawing.Point(262, 338);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Cancel.Size = new System.Drawing.Size(79, 31);
            this.btn_Cancel.TabIndex = 61;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Sure
            // 
            this.btn_Sure.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Sure.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Sure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Sure.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_Sure.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Sure.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sure.Image")));
            this.btn_Sure.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sure.Location = new System.Drawing.Point(152, 338);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Sure.Size = new System.Drawing.Size(79, 31);
            this.btn_Sure.TabIndex = 60;
            this.btn_Sure.Text = "确认";
            this.btn_Sure.UseVisualStyleBackColor = false;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // btn_DelAll
            // 
            this.btn_DelAll.BackColor = System.Drawing.SystemColors.Control;
            this.btn_DelAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_DelAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_DelAll.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btn_DelAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_DelAll.Image = ((System.Drawing.Image)(resources.GetObject("btn_DelAll.Image")));
            this.btn_DelAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_DelAll.Location = new System.Drawing.Point(211, 250);
            this.btn_DelAll.Name = "btn_DelAll";
            this.btn_DelAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_DelAll.Size = new System.Drawing.Size(64, 35);
            this.btn_DelAll.TabIndex = 59;
            this.btn_DelAll.Text = "<<";
            this.btn_DelAll.UseVisualStyleBackColor = false;
            this.btn_DelAll.Click += new System.EventHandler(this.btn_DelAll_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Del.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Del.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Del.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Del.Image = ((System.Drawing.Image)(resources.GetObject("btn_Del.Image")));
            this.btn_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Del.Location = new System.Drawing.Point(211, 209);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Del.Size = new System.Drawing.Size(64, 35);
            this.btn_Del.TabIndex = 58;
            this.btn_Del.Text = "<";
            this.btn_Del.UseVisualStyleBackColor = false;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(291, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 57;
            this.label2.Text = "已选择参数";
            // 
            // selectList
            // 
            this.selectList.BackColor = System.Drawing.SystemColors.Control;
            this.selectList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectList.FormattingEnabled = true;
            this.selectList.ItemHeight = 20;
            this.selectList.Location = new System.Drawing.Point(288, 55);
            this.selectList.Name = "selectList";
            this.selectList.Size = new System.Drawing.Size(166, 264);
            this.selectList.TabIndex = 56;
            // 
            // btn_AddAll
            // 
            this.btn_AddAll.BackColor = System.Drawing.SystemColors.Control;
            this.btn_AddAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_AddAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_AddAll.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btn_AddAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_AddAll.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddAll.Image")));
            this.btn_AddAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_AddAll.Location = new System.Drawing.Point(211, 135);
            this.btn_AddAll.Name = "btn_AddAll";
            this.btn_AddAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_AddAll.Size = new System.Drawing.Size(64, 35);
            this.btn_AddAll.TabIndex = 55;
            this.btn_AddAll.Text = ">>";
            this.btn_AddAll.UseVisualStyleBackColor = false;
            this.btn_AddAll.Click += new System.EventHandler(this.btn_AddAll_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.Location = new System.Drawing.Point(211, 94);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Add.Size = new System.Drawing.Size(64, 35);
            this.btn_Add.TabIndex = 54;
            this.btn_Add.Text = ">";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 53;
            this.label1.Text = "未选择参数";
            // 
            // unSelectList
            // 
            this.unSelectList.BackColor = System.Drawing.SystemColors.Control;
            this.unSelectList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unSelectList.FormattingEnabled = true;
            this.unSelectList.ItemHeight = 20;
            this.unSelectList.Location = new System.Drawing.Point(30, 55);
            this.unSelectList.Name = "unSelectList";
            this.unSelectList.Size = new System.Drawing.Size(166, 264);
            this.unSelectList.TabIndex = 52;
            // 
            // FrmReportConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 394);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.btn_DelAll);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectList);
            this.Controls.Add(this.btn_AddAll);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unSelectList);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmReportConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数选择";
            this.Load += new System.EventHandler(this.FrmReportConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btn_Cancel;
        protected System.Windows.Forms.Button btn_Sure;
        protected System.Windows.Forms.Button btn_DelAll;
        protected System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox selectList;
        protected System.Windows.Forms.Button btn_AddAll;
        protected System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox unSelectList;
    }
}