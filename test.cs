using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rental
{
    public partial class frmtest : Form
    {
        public frmtest()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////////////////////////////
            //クリスタルレポート
            ////////////////////////////

            //データセットの宣言
            Receipt ds = new Receipt();
            //売上
            Receipt.dtReceiptDataTable dtrrr = new Receipt.dtReceiptDataTable();

            Receipt.dtReceiptRow tr = (Receipt.dtReceiptRow)ds.dtReceipt.NewRow();
            tr.BeginEdit();


            tr.StoreTel = "090-4288-8148";      //店舗電話番号（仮）
            tr.StoreName = "HAL支店";           //店舗名（仮）

            tr.ReceiptNumber = "001";
            tr.Recommend = "";
            tr.TotalCount = "";

            tr.EndEdit();
            ds.dtReceipt.Rows.Add(tr);

            //売上明細
            //並び替える列を決める
            //DataGridViewColumn sortColumn = dgvRentalShow.CurrentCell.OwningColumn;
            ////並び替えの方向（昇順か降順か）を決める
            //ListSortDirection sortDirection = ListSortDirection.Ascending;
            //if (dgvRentalShow.SortedColumn != null &&
            //    dgvRentalShow.SortedColumn.Equals(sortColumn))
            //{
            //    sortDirection =
            //        dgvRentalShow.SortOrder == SortOrder.Ascending ?
            //        ListSortDirection.Descending : ListSortDirection.Ascending;
            //}
            ////並び替えを行う
            //dgvRentalShow.Sort(sortColumn, sortDirection);
            //for (int i = 0; i < dgvRentalShow.Rows.Count; i++)
            //{
            //   // string strReturnDate = dgvRentalShow[7, i].Value.ToString();
            //   // if(dgvRentalShow[7, i].Value.ToString() == strReturnDate){
            //        Receipt.dtReceiptListRow trl = (Receipt.dtReceiptListRow)ds.dtReceiptList.NewRow();
            //        trl.BeginEdit(); ;
            //        trl.LendDivision= dgvRentalShow[2, i].Value.ToString();//貸出区分
            //        trl.ProductName = dgvRentalShow[1, i].Value.ToString();//商品名
            //        trl.NightCount  = dgvRentalShow[3, i].Value.ToString();//泊数
            //        trl.Price       = dgvRentalShow[6, i].Value.ToString();//価格
            //        trl.EndEdit();
            //        ds.dtReceiptList.Rows.Add(trl);
            //   // }
            //}

            ////レコメンド
            //Receipt.dtRecommendRow trr = (Receipt.dtRecommendRow)ds.dtRecommend.NewRow();
            //trr.BeginEdit();
            //trr.ProductName = "バイオハザード";
            //trr.EndEdit();
            //ds.dtRecommend.Rows.Add(trr);

            //クリスタルレポート側

        

//            dhhhh.Rows.Add("100");
            crpReceipt cr = new crpReceipt();//クリスタルレポートの宣言
            cr.SetDataSource(ds);               //データセットをクリスタルレポートにセット
            ShowReceipt newForm = new ShowReceipt();
            newForm.crvShowReceipt.ReportSource = cr;
            newForm.ShowDialog();
        }
    }
}
