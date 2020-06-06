namespace rental
{
    partial class frmMemberHistory
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
            this.dgvHistoryShow = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMember = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistoryShow
            // 
            this.dgvHistoryShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryShow.Location = new System.Drawing.Point(12, 83);
            this.dgvHistoryShow.Name = "dgvHistoryShow";
            this.dgvHistoryShow.RowTemplate.Height = 21;
            this.dgvHistoryShow.Size = new System.Drawing.Size(760, 418);
            this.dgvHistoryShow.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(700, 507);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 48);
            this.btnClose.TabIndex = 222;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "F12\r\n\r\n閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(37, 13);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(35, 12);
            this.lblMember.TabIndex = 223;
            this.lblMember.Text = "label1";
            // 
            // frmMemberHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvHistoryShow);
            this.Name = "frmMemberHistory";
            this.Text = "レンタル履歴";
            this.Load += new System.EventHandler(this.frmMemberHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistoryShow;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblMember;



    }
}