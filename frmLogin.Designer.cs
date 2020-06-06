namespace rental
{
    partial class frmLogin
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtStaff_Code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.lblNowTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtStaff_Code
            // 
            this.txtStaff_Code.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStaff_Code.Location = new System.Drawing.Point(300, 344);
            this.txtStaff_Code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStaff_Code.Name = "txtStaff_Code";
            this.txtStaff_Code.Size = new System.Drawing.Size(739, 67);
            this.txtStaff_Code.TabIndex = 63;
            this.txtStaff_Code.TextChanged += new System.EventHandler(this.txtStaff_Code_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(289, 280);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 60);
            this.label1.TabIndex = 62;
            this.label1.Text = "社員コード";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(1657, 15);
            this.textBox26.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(147, 22);
            this.textBox26.TabIndex = 97;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(1579, 19);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 15);
            this.label32.TabIndex = 96;
            this.label32.Text = "店舗名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1687, 906);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 98;
            this.label2.Text = "2011/12/21（水）";
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Location = new System.Drawing.Point(1260, 39);
            this.lblStoreName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(64, 15);
            this.lblStoreName.TabIndex = 100;
            this.lblStoreName.Text = "HAL支店";
            // 
            // lblNowTime
            // 
            this.lblNowTime.AutoSize = true;
            this.lblNowTime.Location = new System.Drawing.Point(1129, 11);
            this.lblNowTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNowTime.Name = "lblNowTime";
            this.lblNowTime.Size = new System.Drawing.Size(184, 15);
            this.lblNowTime.TabIndex = 101;
            this.lblNowTime.Text = "yyyy年MM月dd日hh時mm分";
            this.lblNowTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 912);
            this.Controls.Add(this.lblNowTime);
            this.Controls.Add(this.lblStoreName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.txtStaff_Code);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmLogin";
            this.Text = "ログイン";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStaff_Code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label lblNowTime;
        private System.Windows.Forms.Timer timer1;
    }
}

