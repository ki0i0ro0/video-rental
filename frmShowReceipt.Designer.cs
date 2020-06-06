namespace rental
{
    partial class frmShowReceipt
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
            this.crvShowReceipt = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvShowReceipt
            // 
            this.crvShowReceipt.ActiveViewIndex = -1;
            this.crvShowReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvShowReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvShowReceipt.Location = new System.Drawing.Point(0, 0);
            this.crvShowReceipt.Name = "crvShowReceipt";
            this.crvShowReceipt.SelectionFormula = "";
            this.crvShowReceipt.Size = new System.Drawing.Size(1008, 730);
            this.crvShowReceipt.TabIndex = 0;
            this.crvShowReceipt.ViewTimeSelectionFormula = "";
            // 
            // frmShowReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.crvShowReceipt);
            this.Name = "frmShowReceipt";
            this.Text = "ShowReceipt";
            this.Load += new System.EventHandler(this.frmShowReceipt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvShowReceipt;

    }
}