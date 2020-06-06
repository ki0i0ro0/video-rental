using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace rental
{
    public partial class frmMemberHistory : Form
    {
        public frmMemberHistory()
        {
            InitializeComponent();
        }

        private void btnRental_Return_Jump_Click(object sender, EventArgs e)
        {
            //レンタルビデオ画面へ移動
            //frmRental_Video newForm = new frmRental_Video();
            //newForm.Show();
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // F1ボタンの処理
            if ((int)keyData == (int)Keys.F12)
            {
                this.btnClose.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //●グローバル変数
        OleDbConnection cn = new OleDbConnection();//DBコネクション用オブジェクト
        OleDbCommand cmd = new OleDbCommand();//コマンドを入れておくオブジェクト

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ロードされた時
        private void frmMemberHistory_Load(object sender, EventArgs e)
        {
            //マイクロソフトアクセスのアクセスコードをコネクションに読み込む
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Kensaku\\Dropbox\\rental.accdb";
            //コネクションコマンドをセット
            cmd.Connection = cn;
            string strSqlHistory = "SELECT ProductT.Product_ProductName,SaleT.Sale_SaleDate,SaleT.Sale_StaffId,StockT.Stock_StockId,StockT.Stock_ProductId"
               + " FROM (SELECT * FROM SaleT, SaleListT, StockT,ProductT WHERE SaleT.Sale_SaleNumber = SaleListT.SaleList_SaleNumber AND StockT.Stock_StockId = SaleListT.SaleList_StockId AND Sale_LoanDivisionId = '貸出' AND SaleT.Sale_MemberId ='01' AND ProductT.Product_ProductId = StockT.Stock_ProductId)  AS 貸出"
               + " WHERE (((Exists (select * from (SELECT * FROM SaleT, SaleListT, StockT WHERE SaleT.Sale_SaleNumber = SaleListT.SaleList_SaleNumber AND StockT.Stock_StockId = SaleListT.SaleList_StockId AND Sale_LoanDivisionId = '返却' AND SaleT.Sale_MemberId ='01') AS 返却 where 貸出.SaleList_StockId = 返却.SaleList_StockId))=False))";

            DataTable dt = new DataTable();

            OleDbDataAdapter da = new OleDbDataAdapter(strSqlHistory,cn);

            da.Fill(dt);
            dgvHistoryShow.DataSource = dt;
            dgvHistoryShow.Refresh();
            

           

        }
    }
}
