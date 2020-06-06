namespace rental
{
    partial class frmDiscont
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
            this.txtDiscont = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDisName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDiscont
            // 
            this.txtDiscont.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDiscont.Location = new System.Drawing.Point(35, 75);
            this.txtDiscont.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscont.Name = "txtDiscont";
            this.txtDiscont.Size = new System.Drawing.Size(249, 27);
            this.txtDiscont.TabIndex = 0;
            this.txtDiscont.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscont_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "値引きコードを入力してください。";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(35, 131);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(0, 15);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Visible = false;
            // 
            // lblDisName
            // 
            this.lblDisName.AutoSize = true;
            this.lblDisName.Location = new System.Drawing.Point(81, 131);
            this.lblDisName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisName.Name = "lblDisName";
            this.lblDisName.Size = new System.Drawing.Size(0, 15);
            this.lblDisName.TabIndex = 3;
            this.lblDisName.Visible = false;
            // 
            // frmDiscont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 328);
            this.Controls.Add(this.lblDisName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDiscont);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDiscont";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "値引き入力";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiscont;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblPrice;
        public System.Windows.Forms.Label lblDisName;
    }
}