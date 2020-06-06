using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace rental
{
    public partial class frmShowMemberHistory : Form
    {
        public frmShowMemberHistory()
        {
            InitializeComponent();
        }

        private clsDbJoin dbj = new clsDbJoin();

        private void frmMemberHistory_Load(object sender, EventArgs e)
        {
            DataTable dtlMemberList = dbj.Fill("SELECT LendingV.SaleList_StockId AS 商品ID, LendingV.SaleList_ProductName AS 商品名, LendingV.SaleList_LoanDivision AS 新旧区分,LendingV.SaleList_NightCount AS 泊数, LendingV.Sale_SaleDate AS 貸出日, LendingV.SaleList_ReturnDate AS 返却予定日"
                + " FROM LendingV"
                + " WHERE LendingV.Sale_MemberId = '" + lblMemberId.Text + "'"
                + " ;");

            dgvHistoryShow.DataSource = dtlMemberList;
            for (int i = 0; i < dgvHistoryShow.Rows.Count; i++)
            {
                if (DateTime.Parse(System.DateTime.Now.ToShortDateString()) > DateTime.Parse(dgvHistoryShow[5, i].Value.ToString()))
                {
                    dgvHistoryShow.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            dgvHistoryShow.Refresh();
            dgvHistoryShow.MultiSelect = false;
            dgvHistoryShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((int)keyData == (int)Keys.F6)
            {
                btnClose.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
