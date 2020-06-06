namespace rental
{
    partial class frmMail
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
            this.dgvMemberList = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbComeCount = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAgeOff = new System.Windows.Forms.Button();
            this.btnAgeOn = new System.Windows.Forms.Button();
            this.lbxAge = new System.Windows.Forms.ListBox();
            this.btnMailMake = new System.Windows.Forms.Button();
            this.btnSerch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenreOff = new System.Windows.Forms.Button();
            this.btnGenreOn = new System.Windows.Forms.Button();
            this.lbxGenre = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOld = new System.Windows.Forms.CheckBox();
            this.chkNew = new System.Windows.Forms.CheckBox();
            this.chkNextNew = new System.Windows.Forms.CheckBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnEntry = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMemberList = new System.Windows.Forms.TabPage();
            this.btnMemberAllNoSelect = new System.Windows.Forms.Button();
            this.btnMemberAllSelect = new System.Windows.Forms.Button();
            this.btnSendListAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvSendList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMailMake = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.chkRecommendation = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblNowTime = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.lblMemberCount = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMemberList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSendList)).BeginInit();
            this.tabMailMake.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMemberList
            // 
            this.dgvMemberList.AllowUserToAddRows = false;
            this.dgvMemberList.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemberList.ColumnHeadersVisible = false;
            this.dgvMemberList.Location = new System.Drawing.Point(4, 64);
            this.dgvMemberList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMemberList.Name = "dgvMemberList";
            this.dgvMemberList.RowHeadersWidth = 51;
            this.dgvMemberList.RowTemplate.Height = 21;
            this.dgvMemberList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberList.Size = new System.Drawing.Size(669, 610);
            this.dgvMemberList.TabIndex = 3;
            this.dgvMemberList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvShowRecom_RowStateChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbComeCount);
            this.groupBox5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox5.Location = new System.Drawing.Point(16, 365);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(244, 69);
            this.groupBox5.TabIndex = 235;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "来店頻度";
            // 
            // cmbComeCount
            // 
            this.cmbComeCount.FormattingEnabled = true;
            this.cmbComeCount.Location = new System.Drawing.Point(8, 22);
            this.cmbComeCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbComeCount.Name = "cmbComeCount";
            this.cmbComeCount.Size = new System.Drawing.Size(193, 28);
            this.cmbComeCount.TabIndex = 169;
            this.cmbComeCount.SelectedIndexChanged += new System.EventHandler(this.cbxComeCount_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbYear);
            this.groupBox3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(16, 264);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(244, 72);
            this.groupBox3.TabIndex = 233;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "最終来店日";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(8, 22);
            this.cmbYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(193, 28);
            this.cmbYear.TabIndex = 168;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAgeOff);
            this.groupBox4.Controls.Add(this.btnAgeOn);
            this.groupBox4.Controls.Add(this.lbxAge);
            this.groupBox4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox4.Location = new System.Drawing.Point(16, 68);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(244, 179);
            this.groupBox4.TabIndex = 234;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "年代";
            // 
            // btnAgeOff
            // 
            this.btnAgeOff.Location = new System.Drawing.Point(7, 130);
            this.btnAgeOff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgeOff.Name = "btnAgeOff";
            this.btnAgeOff.Size = new System.Drawing.Size(160, 29);
            this.btnAgeOff.TabIndex = 316;
            this.btnAgeOff.Text = "全て解除";
            this.btnAgeOff.UseVisualStyleBackColor = true;
            this.btnAgeOff.Click += new System.EventHandler(this.btnAgeOff_Click);
            // 
            // btnAgeOn
            // 
            this.btnAgeOn.Location = new System.Drawing.Point(7, 94);
            this.btnAgeOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgeOn.Name = "btnAgeOn";
            this.btnAgeOn.Size = new System.Drawing.Size(160, 29);
            this.btnAgeOn.TabIndex = 315;
            this.btnAgeOn.Text = "全て選択";
            this.btnAgeOn.UseVisualStyleBackColor = true;
            this.btnAgeOn.Click += new System.EventHandler(this.btnAgeOn_Click);
            // 
            // lbxAge
            // 
            this.lbxAge.FormattingEnabled = true;
            this.lbxAge.ItemHeight = 20;
            this.lbxAge.Location = new System.Drawing.Point(7, 21);
            this.lbxAge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxAge.Name = "lbxAge";
            this.lbxAge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbxAge.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxAge.Size = new System.Drawing.Size(159, 64);
            this.lbxAge.TabIndex = 314;
            // 
            // btnMailMake
            // 
            this.btnMailMake.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMailMake.Location = new System.Drawing.Point(1175, 859);
            this.btnMailMake.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMailMake.Name = "btnMailMake";
            this.btnMailMake.Size = new System.Drawing.Size(153, 60);
            this.btnMailMake.TabIndex = 313;
            this.btnMailMake.TabStop = false;
            this.btnMailMake.Text = "メール\r\n作成";
            this.btnMailMake.UseVisualStyleBackColor = true;
            this.btnMailMake.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // btnSerch
            // 
            this.btnSerch.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSerch.Location = new System.Drawing.Point(1071, 859);
            this.btnSerch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(96, 60);
            this.btnSerch.TabIndex = 305;
            this.btnSerch.TabStop = false;
            this.btnSerch.Text = "検索";
            this.btnSerch.UseVisualStyleBackColor = true;
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenreOff);
            this.groupBox1.Controls.Add(this.btnGenreOn);
            this.groupBox1.Controls.Add(this.lbxGenre);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(16, 462);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(244, 185);
            this.groupBox1.TabIndex = 236;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "お客様の好きなジャンル";
            // 
            // btnGenreOff
            // 
            this.btnGenreOff.Location = new System.Drawing.Point(13, 131);
            this.btnGenreOff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenreOff.Name = "btnGenreOff";
            this.btnGenreOff.Size = new System.Drawing.Size(155, 29);
            this.btnGenreOff.TabIndex = 319;
            this.btnGenreOff.Text = "全て解除";
            this.btnGenreOff.UseVisualStyleBackColor = true;
            this.btnGenreOff.Click += new System.EventHandler(this.btnGenreOff_Click);
            // 
            // btnGenreOn
            // 
            this.btnGenreOn.Location = new System.Drawing.Point(13, 95);
            this.btnGenreOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenreOn.Name = "btnGenreOn";
            this.btnGenreOn.Size = new System.Drawing.Size(155, 29);
            this.btnGenreOn.TabIndex = 318;
            this.btnGenreOn.Text = "全て選択";
            this.btnGenreOn.UseVisualStyleBackColor = true;
            this.btnGenreOn.Click += new System.EventHandler(this.btnGenreOn_Click);
            // 
            // lbxGenre
            // 
            this.lbxGenre.FormattingEnabled = true;
            this.lbxGenre.ItemHeight = 20;
            this.lbxGenre.Location = new System.Drawing.Point(8, 22);
            this.lbxGenre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxGenre.Name = "lbxGenre";
            this.lbxGenre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbxGenre.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxGenre.Size = new System.Drawing.Size(159, 64);
            this.lbxGenre.TabIndex = 317;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOld);
            this.groupBox2.Controls.Add(this.chkNew);
            this.groupBox2.Controls.Add(this.chkNextNew);
            this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(16, 676);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(244, 119);
            this.groupBox2.TabIndex = 236;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "好きな貸出区分";
            // 
            // chkOld
            // 
            this.chkOld.AutoSize = true;
            this.chkOld.Checked = true;
            this.chkOld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOld.Location = new System.Drawing.Point(8, 82);
            this.chkOld.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkOld.Name = "chkOld";
            this.chkOld.Size = new System.Drawing.Size(73, 24);
            this.chkOld.TabIndex = 320;
            this.chkOld.Text = "旧作";
            this.chkOld.UseVisualStyleBackColor = true;
            // 
            // chkNew
            // 
            this.chkNew.AutoSize = true;
            this.chkNew.Checked = true;
            this.chkNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNew.Location = new System.Drawing.Point(8, 22);
            this.chkNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNew.Name = "chkNew";
            this.chkNew.Size = new System.Drawing.Size(73, 24);
            this.chkNew.TabIndex = 318;
            this.chkNew.Text = "新作";
            this.chkNew.UseVisualStyleBackColor = true;
            // 
            // chkNextNew
            // 
            this.chkNextNew.AutoSize = true;
            this.chkNextNew.Checked = true;
            this.chkNextNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNextNew.Location = new System.Drawing.Point(8, 52);
            this.chkNextNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNextNew.Name = "chkNextNew";
            this.chkNextNew.Size = new System.Drawing.Size(94, 24);
            this.chkNextNew.TabIndex = 319;
            this.chkNextNew.Text = "準新作";
            this.chkNextNew.UseVisualStyleBackColor = true;
            // 
            // lblComment
            // 
            this.lblComment.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblComment.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblComment.Location = new System.Drawing.Point(24, 808);
            this.lblComment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(1304, 29);
            this.lblComment.TabIndex = 314;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(123, 858);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 60);
            this.button2.TabIndex = 315;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(16, 858);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 60);
            this.button1.TabIndex = 309;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnF1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.btnOut_MouseEnter);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button3.Location = new System.Drawing.Point(227, 858);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 60);
            this.button3.TabIndex = 316;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Location = new System.Drawing.Point(331, 858);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 60);
            this.button4.TabIndex = 318;
            this.button4.TabStop = false;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button5.Location = new System.Drawing.Point(435, 859);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 60);
            this.button5.TabIndex = 317;
            this.button5.TabStop = false;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button6.Location = new System.Drawing.Point(539, 859);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 60);
            this.button6.TabIndex = 319;
            this.button6.TabStop = false;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button7.Location = new System.Drawing.Point(643, 859);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 60);
            this.button7.TabIndex = 320;
            this.button7.TabStop = false;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button8.Location = new System.Drawing.Point(747, 859);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 60);
            this.button8.TabIndex = 321;
            this.button8.TabStop = false;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            this.button8.MouseEnter += new System.EventHandler(this.button8_MouseEnter);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button9.Location = new System.Drawing.Point(851, 859);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 60);
            this.button9.TabIndex = 322;
            this.button9.TabStop = false;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            this.button9.MouseEnter += new System.EventHandler(this.button9_MouseEnter);
            // 
            // btnEntry
            // 
            this.btnEntry.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEntry.Location = new System.Drawing.Point(955, 859);
            this.btnEntry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(96, 60);
            this.btnEntry.TabIndex = 323;
            this.btnEntry.TabStop = false;
            this.btnEntry.Text = "登録";
            this.btnEntry.UseVisualStyleBackColor = true;
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMemberList);
            this.tabControl1.Controls.Add(this.tabMailMake);
            this.tabControl1.Location = new System.Drawing.Point(268, 36);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1064, 768);
            this.tabControl1.TabIndex = 324;
            // 
            // tabMemberList
            // 
            this.tabMemberList.Controls.Add(this.btnMemberAllNoSelect);
            this.tabMemberList.Controls.Add(this.btnMemberAllSelect);
            this.tabMemberList.Controls.Add(this.btnSendListAdd);
            this.tabMemberList.Controls.Add(this.label6);
            this.tabMemberList.Controls.Add(this.label4);
            this.tabMemberList.Controls.Add(this.label5);
            this.tabMemberList.Controls.Add(this.dgvMemberList);
            this.tabMemberList.Controls.Add(this.dgvSendList);
            this.tabMemberList.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabMemberList.Location = new System.Drawing.Point(4, 25);
            this.tabMemberList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMemberList.Name = "tabMemberList";
            this.tabMemberList.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMemberList.Size = new System.Drawing.Size(1056, 739);
            this.tabMemberList.TabIndex = 0;
            this.tabMemberList.Text = "抽出一覧";
            this.tabMemberList.UseVisualStyleBackColor = true;
            // 
            // btnMemberAllNoSelect
            // 
            this.btnMemberAllNoSelect.Location = new System.Drawing.Point(164, 681);
            this.btnMemberAllNoSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMemberAllNoSelect.Name = "btnMemberAllNoSelect";
            this.btnMemberAllNoSelect.Size = new System.Drawing.Size(152, 46);
            this.btnMemberAllNoSelect.TabIndex = 335;
            this.btnMemberAllNoSelect.Text = "選択解除";
            this.btnMemberAllNoSelect.UseVisualStyleBackColor = true;
            this.btnMemberAllNoSelect.Click += new System.EventHandler(this.btnMemberAllNoSelect_Click);
            // 
            // btnMemberAllSelect
            // 
            this.btnMemberAllSelect.Location = new System.Drawing.Point(4, 681);
            this.btnMemberAllSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMemberAllSelect.Name = "btnMemberAllSelect";
            this.btnMemberAllSelect.Size = new System.Drawing.Size(152, 46);
            this.btnMemberAllSelect.TabIndex = 334;
            this.btnMemberAllSelect.Text = "全件選択";
            this.btnMemberAllSelect.UseVisualStyleBackColor = true;
            this.btnMemberAllSelect.Click += new System.EventHandler(this.btnMemberAllSelect_Click);
            // 
            // btnSendListAdd
            // 
            this.btnSendListAdd.Location = new System.Drawing.Point(677, 368);
            this.btnSendListAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendListAdd.Name = "btnSendListAdd";
            this.btnSendListAdd.Size = new System.Drawing.Size(81, 86);
            this.btnSendListAdd.TabIndex = 333;
            this.btnSendListAdd.Text = " 〉〉〉\r\n追加";
            this.btnSendListAdd.UseVisualStyleBackColor = true;
            this.btnSendListAdd.Click += new System.EventHandler(this.btnSendListAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(553, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 332;
            this.label6.Text = "送信リスト";
            this.label6.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(156, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 331;
            this.label4.Text = "抽出条件";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "抽出リスト";
            // 
            // dgvSendList
            // 
            this.dgvSendList.AllowUserToAddRows = false;
            this.dgvSendList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSendList.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvSendList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSendList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvSendList.Location = new System.Drawing.Point(760, 64);
            this.dgvSendList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSendList.Name = "dgvSendList";
            this.dgvSendList.ReadOnly = true;
            this.dgvSendList.RowHeadersVisible = false;
            this.dgvSendList.RowHeadersWidth = 51;
            this.dgvSendList.RowTemplate.Height = 21;
            this.dgvSendList.Size = new System.Drawing.Size(289, 614);
            this.dgvSendList.TabIndex = 4;
            this.dgvSendList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSendList_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "会員ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "会員名";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // tabMailMake
            // 
            this.tabMailMake.Controls.Add(this.label3);
            this.tabMailMake.Controls.Add(this.comboBox1);
            this.tabMailMake.Controls.Add(this.button10);
            this.tabMailMake.Controls.Add(this.btnSendMail);
            this.tabMailMake.Controls.Add(this.chkRecommendation);
            this.tabMailMake.Controls.Add(this.label2);
            this.tabMailMake.Controls.Add(this.txtText);
            this.tabMailMake.Controls.Add(this.label1);
            this.tabMailMake.Controls.Add(this.txtSubject);
            this.tabMailMake.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabMailMake.Location = new System.Drawing.Point(4, 25);
            this.tabMailMake.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMailMake.Name = "tabMailMake";
            this.tabMailMake.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMailMake.Size = new System.Drawing.Size(1056, 739);
            this.tabMailMake.TabIndex = 1;
            this.tabMailMake.Text = "メール作成";
            this.tabMailMake.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(729, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "テンプレート";
            this.label3.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(852, 9);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 28);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Visible = false;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button10.Location = new System.Drawing.Point(573, 606);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(201, 60);
            this.button10.TabIndex = 7;
            this.button10.Text = "全文消去";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btnSendMail
            // 
            this.btnSendMail.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSendMail.Location = new System.Drawing.Point(804, 606);
            this.btnSendMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(201, 60);
            this.btnSendMail.TabIndex = 6;
            this.btnSendMail.Text = "送信";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click_1);
            // 
            // chkRecommendation
            // 
            this.chkRecommendation.AutoSize = true;
            this.chkRecommendation.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkRecommendation.Location = new System.Drawing.Point(17, 641);
            this.chkRecommendation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRecommendation.Name = "chkRecommendation";
            this.chkRecommendation.Size = new System.Drawing.Size(185, 24);
            this.chkRecommendation.TabIndex = 5;
            this.chkRecommendation.Text = "おすすめ情報追加";
            this.chkRecommendation.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(17, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "本文";
            // 
            // txtText
            // 
            this.txtText.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtText.Location = new System.Drawing.Point(17, 88);
            this.txtText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(995, 488);
            this.txtText.TabIndex = 2;
            this.txtText.Text = "MATSUTAYA ハル支店\r\n\r\nいつもご来店ありがとうございます。\r\nMATSUTAYAハル支店の松本です。\r\nいつもご愛顧いただいているお客様に\r\nあなたの" +
    "ための、特別なクーポン情報をお送り致します。\r\n是非この機会に、ご鑑賞してみてはいかがでしょうか？\r\n\r\n＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊\r\nMATSU" +
    "TAYA　ハル支店\r\n住所：××××\r\nTEL：XXXX-XXX-XXXX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "件名";
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSubject.Location = new System.Drawing.Point(17, 31);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(407, 27);
            this.txtSubject.TabIndex = 0;
            this.txtSubject.Text = "MATSUTAYA通信";
            // 
            // lblNowTime
            // 
            this.lblNowTime.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNowTime.Location = new System.Drawing.Point(1049, 11);
            this.lblNowTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNowTime.Name = "lblNowTime";
            this.lblNowTime.Size = new System.Drawing.Size(279, 19);
            this.lblNowTime.TabIndex = 329;
            this.lblNowTime.Text = "時間が表示されます";
            this.lblNowTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStaffName.Location = new System.Drawing.Point(947, 11);
            this.lblStaffName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(49, 20);
            this.lblStaffName.TabIndex = 328;
            this.lblStaffName.Text = "名前";
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStoreName.Location = new System.Drawing.Point(740, 11);
            this.lblStoreName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(69, 20);
            this.lblStoreName.TabIndex = 327;
            this.lblStoreName.Text = "支店名";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label31.Location = new System.Drawing.Point(868, 11);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 20);
            this.label31.TabIndex = 326;
            this.label31.Text = "担当者";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label32.Location = new System.Drawing.Point(639, 11);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(93, 20);
            this.label32.TabIndex = 325;
            this.label32.Text = "店舗名称";
            // 
            // time
            // 
            this.time.Enabled = true;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // lblMemberCount
            // 
            this.lblMemberCount.AutoSize = true;
            this.lblMemberCount.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMemberCount.Location = new System.Drawing.Point(269, 11);
            this.lblMemberCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberCount.Name = "lblMemberCount";
            this.lblMemberCount.Size = new System.Drawing.Size(153, 20);
            this.lblMemberCount.TabIndex = 330;
            this.lblMemberCount.Text = "会員件数　0　人";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(16, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 27);
            this.textBox1.TabIndex = 331;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(16, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 332;
            this.label7.Text = "検索";
            // 
            // frmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 928);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblMemberCount);
            this.Controls.Add(this.lblNowTime);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.lblStoreName);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.btnEntry);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnMailMake);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSerch);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "顧客検索";
            this.Load += new System.EventHandler(this.frmRecommendation_Load);
            this.MouseLeave += new System.EventHandler(this.frmRecommendation_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMemberList.ResumeLayout(false);
            this.tabMemberList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSendList)).EndInit();
            this.tabMailMake.ResumeLayout(false);
            this.tabMailMake.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMemberList;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbComeCount;
        private System.Windows.Forms.Button btnMailMake;
        private System.Windows.Forms.Button btnSerch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkOld;
        private System.Windows.Forms.CheckBox chkNew;
        private System.Windows.Forms.CheckBox chkNextNew;
        private System.Windows.Forms.ListBox lbxAge;
        private System.Windows.Forms.Button btnAgeOff;
        private System.Windows.Forms.Button btnAgeOn;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button btnGenreOff;
        private System.Windows.Forms.Button btnGenreOn;
        private System.Windows.Forms.ListBox lbxGenre;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnEntry;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMemberList;
        private System.Windows.Forms.TabPage tabMailMake;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.CheckBox chkRecommendation;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label lblNowTime;
        public System.Windows.Forms.Label lblStaffName;
        public System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.Label lblMemberCount;
        private System.Windows.Forms.DataGridView dgvSendList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSendListAdd;
        private System.Windows.Forms.Button btnMemberAllNoSelect;
        private System.Windows.Forms.Button btnMemberAllSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
    }
}