using System;
using System.Data;
using System.Windows.Forms;

namespace rental
{
    public partial class frmDiscont : Form
    {
        public frmDiscont()
        {
            InitializeComponent();
        }

        private clsDbJoin m_clsDbj = new clsDbJoin();

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //キーが押された時
        private void txtDiscont_KeyDown(object sender, KeyEventArgs e)
        {
            //エンターボタンが押された場合
            if (e.KeyCode == Keys.Enter)
            {
                //値引き率,値引き名をDBから取得
                DataTable dtlDiscount = m_clsDbj.Fill("SELECT Discount_Price, Discount_Name FROM DiscountT WHERE Discount_Id ='" + txtDiscont.Text + "';");

                lblPrice.Text = dtlDiscount.Rows[0][0].ToString(); //価格
                lblDisName.Text = dtlDiscount.Rows[0][1].ToString();//価格名

                //商品番号検索の結果マッチングがある
                if (dtlDiscount.Rows.Count == 1)
                {
                    Close();
                }
            }
        }

        private void txtDiscont_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
