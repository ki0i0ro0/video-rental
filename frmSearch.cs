using System;
using System.Windows.Forms;

namespace rental
{
    public partial class frmSeach : Form
    {
        public frmSeach()
        {
            InitializeComponent();
        }

        private clsDbJoin dbj = new clsDbJoin();

        private void frmSeach_Load(object sender, EventArgs e)
        {

        }

        //商品履歴入力
        private void btnRecommendation_Click(object sender, EventArgs e)
        {
            dgvProductShow.DataSource = dbj.Fill("");
        }

        private clsDbJoin clsDbj = new clsDbJoin();

        //会員コードが入力された時
        private void txtSerchMemberId_KeyDown(object sender, KeyEventArgs e)
        {
            dgvSerchShow.DataSource = clsDbj.Fill("SELECT RecommendationT.Recommendation_MemberId, RecommendationT.Recommendation_ProductName, RecommendationT.Recommendation_Date"
                + " FROM RecommendationT"
                + " WHERE (((RecommendationT.Recommendation_MemberId)='" + txtSerchMemberId.Text + "'))"
                + " ORDER BY RecommendationT.Recommendation_Date DESC;"
            );
        }
    }
}
