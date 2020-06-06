using System;
using System.Windows.Forms;

namespace rental
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private clsDbJoin m_clDb = new clsDbJoin();

        private void txtStaff_Code_TextChanged(object sender, EventArgs e)
        {
            var dt = m_clDb.Fill("SELECT Staff_Name,Staff_Id FROM StaffT WHERE Staff_Id ='" + txtStaff_Code.Text + "';");

            if (dt.Rows.Count < 1)
            {
                return;
            }

            //検索の結果社員番号があった場合はレンタル画面を表示する。
            var newForm = new frmVideoRental();
            newForm.lblStaffName.Text = dt.Rows[0]["Staff_Name"].ToString();
            newForm.lblStoreName.Text = lblStoreName.Text;
            newForm.ShowDialog(this);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNowTime.Text = DateTime.Now.ToString("yyyy年MM月dd日hh時mm分");
        }
    }
}

