namespace rental
{
    partial class frmShowMemberHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHistoryShow = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistoryShow
            // 
            this.dgvHistoryShow.AllowUserToAddRows = false;
            this.dgvHistoryShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistoryShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryShow.Location = new System.Drawing.Point(12, 85);
            this.dgvHistoryShow.Name = "dgvHistoryShow";
            this.dgvHistoryShow.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            this.dgvHistoryShow.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistoryShow.RowTemplate.Height = 21;
            this.dgvHistoryShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoryShow.Size = new System.Drawing.Size(760, 418);
            this.dgvHistoryShow.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(700, 509);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 48);
            this.btnClose.TabIndex = 222;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "F6\r\n\r\n閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMemberId
            // 
            this.lblMemberId.AutoSize = true;
            this.lblMemberId.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMemberId.Location = new System.Drawing.Point(12, 9);
            this.lblMemberId.Name = "lblMemberId";
            this.lblMemberId.Size = new System.Drawing.Size(154, 21);
            this.lblMemberId.TabIndex = 223;
            this.lblMemberId.Text = "000000000001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 21);
            this.label1.TabIndex = 224;
            this.label1.Text = "貸出中商品一覧";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 12);
            this.label2.TabIndex = 225;
            this.label2.Text = "※延滞中は赤で色で表示されています";
            // 
            // frmShowMemberHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMemberId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvHistoryShow);
            this.Name = "frmShowMemberHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "レンタル履歴";
            this.Load += new System.EventHandler(this.frmMemberHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistoryShow;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;



    }
}