namespace rental
{
    partial class frmEntly
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
            this.btnEntlyOK = new System.Windows.Forms.Button();
            this.btnCancell = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtButtonName = new System.Windows.Forms.TextBox();
            this.btnZenkenhyouji = new System.Windows.Forms.Button();
            this.lblWariateComment = new System.Windows.Forms.Label();
            this.cmbWariatekasyo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblstrCom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEntlyOK
            // 
            this.btnEntlyOK.Location = new System.Drawing.Point(47, 203);
            this.btnEntlyOK.Name = "btnEntlyOK";
            this.btnEntlyOK.Size = new System.Drawing.Size(75, 23);
            this.btnEntlyOK.TabIndex = 0;
            this.btnEntlyOK.Text = "登録";
            this.btnEntlyOK.UseVisualStyleBackColor = true;
            this.btnEntlyOK.Click += new System.EventHandler(this.btnEntlyOK_Click);
            // 
            // btnCancell
            // 
            this.btnCancell.Location = new System.Drawing.Point(165, 203);
            this.btnCancell.Name = "btnCancell";
            this.btnCancell.Size = new System.Drawing.Size(75, 23);
            this.btnCancell.TabIndex = 1;
            this.btnCancell.Text = "キャンセル";
            this.btnCancell.UseVisualStyleBackColor = true;
            this.btnCancell.Click += new System.EventHandler(this.btnCancell_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "現在の検索情報をショートカットに登録します";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(10, 85);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(260, 19);
            this.txtComment.TabIndex = 3;
            this.txtComment.Text = "４０代の女性";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "コメント";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "ボタン名";
            // 
            // txtButtonName
            // 
            this.txtButtonName.Location = new System.Drawing.Point(12, 48);
            this.txtButtonName.Name = "txtButtonName";
            this.txtButtonName.Size = new System.Drawing.Size(82, 19);
            this.txtButtonName.TabIndex = 5;
            this.txtButtonName.Text = "40代";
            // 
            // btnZenkenhyouji
            // 
            this.btnZenkenhyouji.Location = new System.Drawing.Point(137, 134);
            this.btnZenkenhyouji.Name = "btnZenkenhyouji";
            this.btnZenkenhyouji.Size = new System.Drawing.Size(75, 23);
            this.btnZenkenhyouji.TabIndex = 7;
            this.btnZenkenhyouji.Text = "全件表示";
            this.btnZenkenhyouji.UseVisualStyleBackColor = true;
            this.btnZenkenhyouji.Click += new System.EventHandler(this.btnZenkenhyouji_Click);
            // 
            // lblWariateComment
            // 
            this.lblWariateComment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWariateComment.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblWariateComment.Location = new System.Drawing.Point(10, 168);
            this.lblWariateComment.Name = "lblWariateComment";
            this.lblWariateComment.Size = new System.Drawing.Size(260, 16);
            this.lblWariateComment.TabIndex = 8;
            this.lblWariateComment.Text = "割り当て中のコメントが表示されます";
            this.lblWariateComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbWariatekasyo
            // 
            this.cmbWariatekasyo.FormattingEnabled = true;
            this.cmbWariatekasyo.Location = new System.Drawing.Point(10, 134);
            this.cmbWariatekasyo.Name = "cmbWariatekasyo";
            this.cmbWariatekasyo.Size = new System.Drawing.Size(121, 20);
            this.cmbWariatekasyo.TabIndex = 9;
            this.cmbWariatekasyo.SelectedIndexChanged += new System.EventHandler(this.cmbWariatekasyo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "割り当て箇所";
            // 
            // lblstrCom
            // 
            this.lblstrCom.AutoSize = true;
            this.lblstrCom.Location = new System.Drawing.Point(10, 245);
            this.lblstrCom.Name = "lblstrCom";
            this.lblstrCom.Size = new System.Drawing.Size(53, 12);
            this.lblstrCom.TabIndex = 11;
            this.lblstrCom.Text = "非表示中";
            this.lblstrCom.Visible = false;
            // 
            // frmEntly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblstrCom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbWariatekasyo);
            this.Controls.Add(this.lblWariateComment);
            this.Controls.Add(this.btnZenkenhyouji);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtButtonName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancell);
            this.Controls.Add(this.btnEntlyOK);
            this.Name = "frmEntly";
            this.Text = "ショートカット登録";
            this.Load += new System.EventHandler(this.frmEntly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnZenkenhyouji;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnEntlyOK;
        public System.Windows.Forms.TextBox txtComment;
        public System.Windows.Forms.TextBox txtButtonName;
        public System.Windows.Forms.Label lblWariateComment;
        public System.Windows.Forms.ComboBox cmbWariatekasyo;
        public System.Windows.Forms.Label lblstrCom;

    }
}