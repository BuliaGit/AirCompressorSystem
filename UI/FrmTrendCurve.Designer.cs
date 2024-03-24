namespace UI
{
    partial class FrmTrendCurve
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Chk6_2 = new System.Windows.Forms.CheckBox();
            this.cmb_TrendType = new System.Windows.Forms.ComboBox();
            this.Chk2_2 = new System.Windows.Forms.CheckBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.Chk1_2 = new System.Windows.Forms.CheckBox();
            this.Chk4_2 = new System.Windows.Forms.CheckBox();
            this.Chk9_1 = new System.Windows.Forms.CheckBox();
            this.Chk9_2 = new System.Windows.Forms.CheckBox();
            this.btn_sure = new System.Windows.Forms.Button();
            this.Chk3_2 = new System.Windows.Forms.CheckBox();
            this.Chk8_1 = new System.Windows.Forms.CheckBox();
            this.Chk7_2 = new System.Windows.Forms.CheckBox();
            this.Chk6_1 = new System.Windows.Forms.CheckBox();
            this.Chk5_2 = new System.Windows.Forms.CheckBox();
            this.Chk5_1 = new System.Windows.Forms.CheckBox();
            this.Chk8_2 = new System.Windows.Forms.CheckBox();
            this.Chk4_1 = new System.Windows.Forms.CheckBox();
            this.Chk7_1 = new System.Windows.Forms.CheckBox();
            this.Chk10_1 = new System.Windows.Forms.CheckBox();
            this.Chk3_1 = new System.Windows.Forms.CheckBox();
            this.Chk2_1 = new System.Windows.Forms.CheckBox();
            this.Chk1_1 = new System.Windows.Forms.CheckBox();
            this.cmb_ZoneSel = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txt_count = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_lblNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.dt_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LeftPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1366, 600);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 3;
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(44)))), ((int)(((byte)(75)))));
            this.LeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftPanel.Controls.Add(this.Chk6_2);
            this.LeftPanel.Controls.Add(this.cmb_TrendType);
            this.LeftPanel.Controls.Add(this.Chk2_2);
            this.LeftPanel.Controls.Add(this.btn_cancel);
            this.LeftPanel.Controls.Add(this.Chk1_2);
            this.LeftPanel.Controls.Add(this.Chk4_2);
            this.LeftPanel.Controls.Add(this.Chk9_1);
            this.LeftPanel.Controls.Add(this.Chk9_2);
            this.LeftPanel.Controls.Add(this.btn_sure);
            this.LeftPanel.Controls.Add(this.Chk3_2);
            this.LeftPanel.Controls.Add(this.Chk8_1);
            this.LeftPanel.Controls.Add(this.Chk7_2);
            this.LeftPanel.Controls.Add(this.Chk6_1);
            this.LeftPanel.Controls.Add(this.Chk5_2);
            this.LeftPanel.Controls.Add(this.Chk5_1);
            this.LeftPanel.Controls.Add(this.Chk8_2);
            this.LeftPanel.Controls.Add(this.Chk4_1);
            this.LeftPanel.Controls.Add(this.Chk7_1);
            this.LeftPanel.Controls.Add(this.Chk10_1);
            this.LeftPanel.Controls.Add(this.Chk3_1);
            this.LeftPanel.Controls.Add(this.Chk2_1);
            this.LeftPanel.Controls.Add(this.Chk1_1);
            this.LeftPanel.Controls.Add(this.cmb_ZoneSel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(165, 600);
            this.LeftPanel.TabIndex = 0;
            // 
            // Chk6_2
            // 
            this.Chk6_2.AutoSize = true;
            this.Chk6_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk6_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk6_2.ForeColor = System.Drawing.Color.White;
            this.Chk6_2.Location = new System.Drawing.Point(9, 334);
            this.Chk6_2.Name = "Chk6_2";
            this.Chk6_2.Size = new System.Drawing.Size(143, 24);
            this.Chk6_2.TabIndex = 18;
            this.Chk6_2.Tag = "CQG3_OutPre";
            this.Chk6_2.Text = "3#储气罐出口压力";
            this.Chk6_2.UseVisualStyleBackColor = false;
            this.Chk6_2.Visible = false;
            // 
            // cmb_TrendType
            // 
            this.cmb_TrendType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(44)))), ((int)(((byte)(75)))));
            this.cmb_TrendType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmb_TrendType.ForeColor = System.Drawing.SystemColors.Info;
            this.cmb_TrendType.FormattingEnabled = true;
            this.cmb_TrendType.Location = new System.Drawing.Point(11, 16);
            this.cmb_TrendType.Name = "cmb_TrendType";
            this.cmb_TrendType.Size = new System.Drawing.Size(142, 27);
            this.cmb_TrendType.TabIndex = 24;
            this.cmb_TrendType.SelectedIndexChanged += new System.EventHandler(this.cmb_TrendType_SelectedIndexChanged);
            // 
            // Chk2_2
            // 
            this.Chk2_2.AutoSize = true;
            this.Chk2_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk2_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk2_2.ForeColor = System.Drawing.Color.White;
            this.Chk2_2.Location = new System.Drawing.Point(9, 158);
            this.Chk2_2.Name = "Chk2_2";
            this.Chk2_2.Size = new System.Drawing.Size(143, 24);
            this.Chk2_2.TabIndex = 14;
            this.Chk2_2.Tag = "KYJ2_OutTemp";
            this.Chk2_2.Text = "2#空压机回水温度";
            this.Chk2_2.UseVisualStyleBackColor = false;
            this.Chk2_2.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(115)))), ((int)(((byte)(163)))));
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_cancel.Location = new System.Drawing.Point(84, 561);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(71, 34);
            this.btn_cancel.TabIndex = 23;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Chk1_2
            // 
            this.Chk1_2.AutoSize = true;
            this.Chk1_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk1_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk1_2.ForeColor = System.Drawing.Color.White;
            this.Chk1_2.Location = new System.Drawing.Point(9, 114);
            this.Chk1_2.Name = "Chk1_2";
            this.Chk1_2.Size = new System.Drawing.Size(143, 24);
            this.Chk1_2.TabIndex = 13;
            this.Chk1_2.Tag = "KYJ1_OutTemp";
            this.Chk1_2.Text = "1#空压机回水温度";
            this.Chk1_2.UseVisualStyleBackColor = false;
            this.Chk1_2.Visible = false;
            // 
            // Chk4_2
            // 
            this.Chk4_2.AutoSize = true;
            this.Chk4_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk4_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk4_2.ForeColor = System.Drawing.Color.White;
            this.Chk4_2.Location = new System.Drawing.Point(9, 246);
            this.Chk4_2.Name = "Chk4_2";
            this.Chk4_2.Size = new System.Drawing.Size(143, 24);
            this.Chk4_2.TabIndex = 16;
            this.Chk4_2.Tag = "CQG1_OutPre";
            this.Chk4_2.Text = "1#储气罐出口压力";
            this.Chk4_2.UseVisualStyleBackColor = false;
            this.Chk4_2.Visible = false;
            // 
            // Chk9_1
            // 
            this.Chk9_1.AutoSize = true;
            this.Chk9_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk9_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk9_1.ForeColor = System.Drawing.Color.White;
            this.Chk9_1.Location = new System.Drawing.Point(13, 466);
            this.Chk9_1.Name = "Chk9_1";
            this.Chk9_1.Size = new System.Drawing.Size(115, 24);
            this.Chk9_1.TabIndex = 9;
            this.Chk9_1.Tag = "LQB2_Current";
            this.Chk9_1.Text = "2#冷却泵电流";
            this.Chk9_1.UseVisualStyleBackColor = false;
            // 
            // Chk9_2
            // 
            this.Chk9_2.AutoSize = true;
            this.Chk9_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk9_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk9_2.ForeColor = System.Drawing.Color.White;
            this.Chk9_2.Location = new System.Drawing.Point(9, 466);
            this.Chk9_2.Name = "Chk9_2";
            this.Chk9_2.Size = new System.Drawing.Size(98, 24);
            this.Chk9_2.TabIndex = 21;
            this.Chk9_2.Tag = "FQG_Temp";
            this.Chk9_2.Text = "分气缸温度";
            this.Chk9_2.UseVisualStyleBackColor = false;
            this.Chk9_2.Visible = false;
            // 
            // btn_sure
            // 
            this.btn_sure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(115)))), ((int)(((byte)(163)))));
            this.btn_sure.FlatAppearance.BorderSize = 0;
            this.btn_sure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_sure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_sure.Location = new System.Drawing.Point(7, 561);
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(71, 34);
            this.btn_sure.TabIndex = 22;
            this.btn_sure.Text = "确认";
            this.btn_sure.UseVisualStyleBackColor = false;
            this.btn_sure.Click += new System.EventHandler(this.btn_sure_Click);
            // 
            // Chk3_2
            // 
            this.Chk3_2.AutoSize = true;
            this.Chk3_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk3_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk3_2.ForeColor = System.Drawing.Color.White;
            this.Chk3_2.Location = new System.Drawing.Point(9, 202);
            this.Chk3_2.Name = "Chk3_2";
            this.Chk3_2.Size = new System.Drawing.Size(143, 24);
            this.Chk3_2.TabIndex = 15;
            this.Chk3_2.Tag = "KYJ3_OutTemp";
            this.Chk3_2.Text = "3#空压机回水温度";
            this.Chk3_2.UseVisualStyleBackColor = false;
            this.Chk3_2.Visible = false;
            // 
            // Chk8_1
            // 
            this.Chk8_1.AutoSize = true;
            this.Chk8_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk8_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk8_1.ForeColor = System.Drawing.Color.White;
            this.Chk8_1.Location = new System.Drawing.Point(13, 422);
            this.Chk8_1.Name = "Chk8_1";
            this.Chk8_1.Size = new System.Drawing.Size(115, 24);
            this.Chk8_1.TabIndex = 8;
            this.Chk8_1.Tag = "LQB1_Fre";
            this.Chk8_1.Text = "1#冷却泵频率";
            this.Chk8_1.UseVisualStyleBackColor = false;
            // 
            // Chk7_2
            // 
            this.Chk7_2.AutoSize = true;
            this.Chk7_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk7_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk7_2.ForeColor = System.Drawing.Color.White;
            this.Chk7_2.Location = new System.Drawing.Point(9, 378);
            this.Chk7_2.Name = "Chk7_2";
            this.Chk7_2.Size = new System.Drawing.Size(84, 24);
            this.Chk7_2.TabIndex = 19;
            this.Chk7_2.Tag = "Env_Temp";
            this.Chk7_2.Text = "露点温度";
            this.Chk7_2.UseVisualStyleBackColor = false;
            this.Chk7_2.Visible = false;
            // 
            // Chk6_1
            // 
            this.Chk6_1.AutoSize = true;
            this.Chk6_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk6_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk6_1.ForeColor = System.Drawing.Color.White;
            this.Chk6_1.Location = new System.Drawing.Point(13, 334);
            this.Chk6_1.Name = "Chk6_1";
            this.Chk6_1.Size = new System.Drawing.Size(126, 24);
            this.Chk6_1.TabIndex = 6;
            this.Chk6_1.Tag = "LQT_InTemp";
            this.Chk6_1.Text = "冷却塔回水温度";
            this.Chk6_1.UseVisualStyleBackColor = false;
            // 
            // Chk5_2
            // 
            this.Chk5_2.AutoSize = true;
            this.Chk5_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk5_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk5_2.ForeColor = System.Drawing.Color.White;
            this.Chk5_2.Location = new System.Drawing.Point(9, 290);
            this.Chk5_2.Name = "Chk5_2";
            this.Chk5_2.Size = new System.Drawing.Size(143, 24);
            this.Chk5_2.TabIndex = 17;
            this.Chk5_2.Tag = "CQG2_OutPre";
            this.Chk5_2.Text = "2#储气罐出口压力";
            this.Chk5_2.UseVisualStyleBackColor = false;
            this.Chk5_2.Visible = false;
            // 
            // Chk5_1
            // 
            this.Chk5_1.AutoSize = true;
            this.Chk5_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk5_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk5_1.ForeColor = System.Drawing.Color.White;
            this.Chk5_1.Location = new System.Drawing.Point(13, 290);
            this.Chk5_1.Name = "Chk5_1";
            this.Chk5_1.Size = new System.Drawing.Size(126, 24);
            this.Chk5_1.TabIndex = 5;
            this.Chk5_1.Tag = "LQT_InPre";
            this.Chk5_1.Text = "冷却塔回水压力";
            this.Chk5_1.UseVisualStyleBackColor = false;
            // 
            // Chk8_2
            // 
            this.Chk8_2.AutoSize = true;
            this.Chk8_2.BackColor = System.Drawing.Color.Transparent;
            this.Chk8_2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk8_2.ForeColor = System.Drawing.Color.White;
            this.Chk8_2.Location = new System.Drawing.Point(9, 422);
            this.Chk8_2.Name = "Chk8_2";
            this.Chk8_2.Size = new System.Drawing.Size(98, 24);
            this.Chk8_2.TabIndex = 20;
            this.Chk8_2.Tag = "FQG_Pre";
            this.Chk8_2.Text = "分汽缸压力";
            this.Chk8_2.UseVisualStyleBackColor = false;
            this.Chk8_2.Visible = false;
            // 
            // Chk4_1
            // 
            this.Chk4_1.AutoSize = true;
            this.Chk4_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk4_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk4_1.ForeColor = System.Drawing.Color.White;
            this.Chk4_1.Location = new System.Drawing.Point(13, 246);
            this.Chk4_1.Name = "Chk4_1";
            this.Chk4_1.Size = new System.Drawing.Size(126, 24);
            this.Chk4_1.TabIndex = 4;
            this.Chk4_1.Tag = "LQT_OutTemp";
            this.Chk4_1.Text = "冷却塔供水温度";
            this.Chk4_1.UseVisualStyleBackColor = false;
            // 
            // Chk7_1
            // 
            this.Chk7_1.AutoSize = true;
            this.Chk7_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk7_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk7_1.ForeColor = System.Drawing.Color.White;
            this.Chk7_1.Location = new System.Drawing.Point(13, 378);
            this.Chk7_1.Name = "Chk7_1";
            this.Chk7_1.Size = new System.Drawing.Size(115, 24);
            this.Chk7_1.TabIndex = 7;
            this.Chk7_1.Tag = "LQB1_Current";
            this.Chk7_1.Text = "1#冷却泵电流";
            this.Chk7_1.UseVisualStyleBackColor = false;
            // 
            // Chk10_1
            // 
            this.Chk10_1.AutoSize = true;
            this.Chk10_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk10_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk10_1.ForeColor = System.Drawing.Color.White;
            this.Chk10_1.Location = new System.Drawing.Point(13, 510);
            this.Chk10_1.Name = "Chk10_1";
            this.Chk10_1.Size = new System.Drawing.Size(115, 24);
            this.Chk10_1.TabIndex = 10;
            this.Chk10_1.Tag = "LQB2_Fre";
            this.Chk10_1.Text = "2#冷却泵频率";
            this.Chk10_1.UseVisualStyleBackColor = false;
            // 
            // Chk3_1
            // 
            this.Chk3_1.AutoSize = true;
            this.Chk3_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk3_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk3_1.ForeColor = System.Drawing.Color.White;
            this.Chk3_1.Location = new System.Drawing.Point(13, 202);
            this.Chk3_1.Name = "Chk3_1";
            this.Chk3_1.Size = new System.Drawing.Size(126, 24);
            this.Chk3_1.TabIndex = 3;
            this.Chk3_1.Tag = "LQT_OutPre";
            this.Chk3_1.Text = "冷却塔供水压力";
            this.Chk3_1.UseVisualStyleBackColor = false;
            // 
            // Chk2_1
            // 
            this.Chk2_1.AutoSize = true;
            this.Chk2_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk2_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk2_1.ForeColor = System.Drawing.Color.White;
            this.Chk2_1.Location = new System.Drawing.Point(13, 158);
            this.Chk2_1.Name = "Chk2_1";
            this.Chk2_1.Size = new System.Drawing.Size(126, 24);
            this.Chk2_1.TabIndex = 2;
            this.Chk2_1.Tag = "LQT_BSPre";
            this.Chk2_1.Text = "冷却塔补水压力";
            this.Chk2_1.UseVisualStyleBackColor = false;
            // 
            // Chk1_1
            // 
            this.Chk1_1.AutoSize = true;
            this.Chk1_1.BackColor = System.Drawing.Color.Transparent;
            this.Chk1_1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Chk1_1.ForeColor = System.Drawing.Color.White;
            this.Chk1_1.Location = new System.Drawing.Point(13, 114);
            this.Chk1_1.Name = "Chk1_1";
            this.Chk1_1.Size = new System.Drawing.Size(98, 24);
            this.Chk1_1.TabIndex = 1;
            this.Chk1_1.Tag = "LQT_Level";
            this.Chk1_1.Text = "冷却塔液位";
            this.Chk1_1.UseVisualStyleBackColor = false;
            // 
            // cmb_ZoneSel
            // 
            this.cmb_ZoneSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(44)))), ((int)(((byte)(75)))));
            this.cmb_ZoneSel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmb_ZoneSel.ForeColor = System.Drawing.SystemColors.Info;
            this.cmb_ZoneSel.FormattingEnabled = true;
            this.cmb_ZoneSel.Location = new System.Drawing.Point(11, 61);
            this.cmb_ZoneSel.Name = "cmb_ZoneSel";
            this.cmb_ZoneSel.Size = new System.Drawing.Size(142, 27);
            this.cmb_ZoneSel.TabIndex = 0;
            this.cmb_ZoneSel.SelectedIndexChanged += new System.EventHandler(this.cmb_ZoneSel_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(44)))), ((int)(((byte)(75)))));
            this.splitContainer2.Panel2.Controls.Add(this.txt_count);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.txt_lblNum);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.btn_Update);
            this.splitContainer2.Panel2.Controls.Add(this.btn_query);
            this.splitContainer2.Panel2.Controls.Add(this.dt_end);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.dt_start);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(1200, 600);
            this.splitContainer2.SplitterDistance = 545;
            this.splitContainer2.TabIndex = 0;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(165)))), ((int)(((byte)(176)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(165)))), ((int)(((byte)(176)))));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1200, 545);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // txt_count
            // 
            this.txt_count.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_count.Location = new System.Drawing.Point(871, 14);
            this.txt_count.Name = "txt_count";
            this.txt_count.Size = new System.Drawing.Size(57, 25);
            this.txt_count.TabIndex = 31;
            this.txt_count.Text = "20";
            this.txt_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_count.TextChanged += new System.EventHandler(this.txt_count_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(793, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 30;
            this.label4.Text = "显示数目:";
            // 
            // txt_lblNum
            // 
            this.txt_lblNum.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_lblNum.Location = new System.Drawing.Point(704, 14);
            this.txt_lblNum.Name = "txt_lblNum";
            this.txt_lblNum.Size = new System.Drawing.Size(57, 25);
            this.txt_lblNum.TabIndex = 29;
            this.txt_lblNum.Text = "30";
            this.txt_lblNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_lblNum.TextChanged += new System.EventHandler(this.txt_lblNum_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(580, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "显示标签数目:";
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Update.Location = new System.Drawing.Point(960, 11);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(95, 33);
            this.btn_Update.TabIndex = 26;
            this.btn_Update.Text = "停止更新";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Location = new System.Drawing.Point(1076, 11);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(95, 33);
            this.btn_query.TabIndex = 25;
            this.btn_query.Text = "开始查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // dt_end
            // 
            this.dt_end.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_end.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dt_end.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_end.Location = new System.Drawing.Point(387, 14);
            this.dt_end.Name = "dt_end";
            this.dt_end.Size = new System.Drawing.Size(165, 26);
            this.dt_end.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(307, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间:";
            // 
            // dt_start
            // 
            this.dt_start.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_start.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dt_start.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_start.Location = new System.Drawing.Point(104, 14);
            this.dt_start.Name = "dt_start";
            this.dt_start.Size = new System.Drawing.Size(165, 26);
            this.dt_start.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间:";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmTrendCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 600);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmTrendCurve";
            this.Text = "FrmTrendCurve";
            this.Load += new System.EventHandler(this.FrmTrendCurve_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.CheckBox Chk6_2;
        private System.Windows.Forms.ComboBox cmb_TrendType;
        private System.Windows.Forms.CheckBox Chk2_2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.CheckBox Chk1_2;
        private System.Windows.Forms.CheckBox Chk4_2;
        private System.Windows.Forms.CheckBox Chk9_1;
        private System.Windows.Forms.CheckBox Chk9_2;
        private System.Windows.Forms.Button btn_sure;
        private System.Windows.Forms.CheckBox Chk3_2;
        private System.Windows.Forms.CheckBox Chk8_1;
        private System.Windows.Forms.CheckBox Chk7_2;
        private System.Windows.Forms.CheckBox Chk6_1;
        private System.Windows.Forms.CheckBox Chk5_2;
        private System.Windows.Forms.CheckBox Chk5_1;
        private System.Windows.Forms.CheckBox Chk8_2;
        private System.Windows.Forms.CheckBox Chk4_1;
        private System.Windows.Forms.CheckBox Chk7_1;
        private System.Windows.Forms.CheckBox Chk10_1;
        private System.Windows.Forms.CheckBox Chk3_1;
        private System.Windows.Forms.CheckBox Chk2_1;
        private System.Windows.Forms.CheckBox Chk1_1;
        private System.Windows.Forms.ComboBox cmb_ZoneSel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txt_count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_lblNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DateTimePicker dt_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dt_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}