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
    public partial class frmSales : Form
    {
        //■宣言エリア
        //オブジェクトの宣言
        //DataSet dSet = new DataSet();
        //DataTable dtlTodayTable = new DataTable();
        clsDbJoin clsDbj = new clsDbJoin();
        clsOperation clsOpe = new clsOperation();

        public frmSales()
        {
            InitializeComponent();
        }

        //▲フォームをロードした
        private void frmSales_Load(object sender, EventArgs e)
        {

            ////DataGridViewButtonColumnの作成
            //DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            ////列の名前を設定
            //column.Name = "編集";
            ////全てのボタンに"詳細閲覧"と表示する
            //column.UseColumnTextForButtonValue = true;
            //column.Text = "削除";
            ////DataGridViewに追加する
            //dgvOrder_OrderList.Columns.Add(column);

            clsOpe.fctDgvAddDele(dgvOrder_OrderList);
            clsOpe.fctDgvAddDele(dgvStock_StockShow);
            
            //初期ページ設定
            //btnRecom_Click(sender, e);
            //btnSaleToday_Click(sender, e);

        }

        //売上分析////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

   //     //●当日売上をクリック
   //     private void btnSaleToday_Click(object sender, EventArgs e)
   //     {
   //         //オブジェクトの宣言
   //         string strTerm = " BETWEEN '2012-01-20' AND '2012-01-21'";
              
   //         //ジャンル合計を表示   
   //         dgvGenre.DataSource = clsDbj.fctFilldgv("SELECT Product_Genre, COUNT(Product_Genre) AS 枚数"
   //             + " FROM (ProductT INNER JOIN StockT ON ProductT.Product_ProductId = StockT.Stock_ProductId) INNER JOIN (SaleT INNER JOIN SaleListT ON SaleT.Sale_SaleNumber = SaleListT.SaleList_SaleNumber) ON StockT.Stock_StockId = SaleListT.SaleList_StockId"
   //             + " WHERE Sale_SaleDate" + strTerm
   //             + " AND Sale_LoanDivisionId = '貸出'"
   //             + " GROUP BY Product_Genre ORDER BY COUNT(Product_Genre) Desc;");
   //         dgvGenre.Refresh();

   //         //新旧区分を表示
   //         dgvDayDiv.DataSource = clsDbj.fctFilldgv("SELECT PriceT.Price_LoanDivisionId, Count(PriceT.Price_LoanDivisionId) AS 区分合計"
   //             +" FROM SaleT INNER JOIN ((ProductT INNER JOIN (PriceT INNER JOIN ProductandPriceT ON PriceT.Price_PriceId = ProductandPriceT.ProductandPrice_PriceId) ON ProductT.Product_ProductId = ProductandPriceT.ProductandPrice_ProductId) INNER JOIN (StockT INNER JOIN SaleListT ON StockT.Stock_StockId = SaleListT.SaleList_StockId) ON ProductT.Product_ProductId = StockT.Stock_ProductId) ON SaleT.Sale_SaleNumber = SaleListT.SaleList_SaleNumber"
   //             + " WHERE Sale_SaleDate"+ strTerm
   //             + " AND Sale_LoanDivisionId = '貸出' OR Sale_LoanDivisionId ='延滞' GROUP BY PriceT.Price_LoanDivisionId;");
   //         dgvDayDiv.Refresh();


   //         //売上合計
   //         int intTotalMoney = int.Parse(clsDbj.fctFillTop("SELECT Sum(Sale_TotalManey) FROM SaleT "
   //             +"WHERE Sale_SaleDate " + strTerm +" AND Sale_LoanDivisionId = '貸出';"));
   //         lblTotalMoney.Text = intTotalMoney.ToString("C0");

   //         //貸出数合計(新作区分を使用)
   //         int intSum = 0;
   //         for (int i = 0; i < dgvDayDiv.Rows.Count; i++)
			//{
   //             intSum +=int.Parse(dgvDayDiv[1, i].Value.ToString());
			//}
   //         lblLendSum.Text=intSum.ToString("#,##0");
            
   //         //来店者数
   //         int intComeStorCount = int.Parse(clsDbj.fctFillTop("SELECT COUNT(*) FROM SaleT WHERE Sale_SaleDate "+ strTerm +";"));
   //         if (intComeStorCount == 0)
   //         {
   //             intComeStorCount = 1;
   //         }
   //         lblComeStorCount.Text = intComeStorCount.ToString("#,##0");

   //         //１人あたりの平均枚数（貸出数合計と来店者数を使用）
   //         lblAvgDisc.Text = Convert.ToString(int.Parse(lblLendSum.Text) / int.Parse(lblComeStorCount.Text));

   //         //平均客単価（来店者数と売上合計を使用）
   //         lblAvgMemberPrice.Text = (intTotalMoney / intComeStorCount).ToString("C0");

   //         //新作区分毎の円グラフ
   //         Chart(crtToday, "新作区分毎", dgvDayDiv);
   //         //ジャンル毎のグラフ
   //         Chart(chrSale_Genre, "ジャンル毎のグラフ", dgvGenre);

   //         int[,] intGet = new int[dgvGenre.RowCount,12];
   //         string[,] strTime = new string[1,12];
   //         int k = 0;

   //         //データグリッドビューのジャンル分繰り返す
   //         for (int i = 0; i < dgvGenre.RowCount; i++)
   //         {
   //             k = 0;
   //             //10時から22時迄繰り返す
   //             for (int j = 10; j < 22; j++)
   //             {
   //                 //現在の時間を入れる
                    
   //                 string strGet = clsDbj.fctFillTop("SELECT COUNT(*) FROM (SELECT Count(AllV.Sale_SaleDate) , AllV.Product_Genre FROM AllV WHERE Sale_SaleDate Between '2012-1-20' And '2012-1-21' and Sale_Hour = "+ j.ToString() +" GROUP BY AllV.Product_Genre, AllV.Sale_SaleDate HAVING AllV.Product_Genre='" + dgvGenre[0, i].Value.ToString() + "') AS A");
   //                 strTime[0, k] = j.ToString();
   //                 intGet[i, k] = int.Parse(strGet);
   //                 k++;
   //             }
   //         }
   //         BarGraph(chrTimeLine, dgvGenre, strTime, intGet);

   //         //タブを切り替えて画面を表示する
   //         tabMein.SelectedTab = tpgAnalysis;


   //     }

        //おすすめ分析////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        ////●おすすめ
        //private void btnRecom_Click(object sender, EventArgs e)
        //{
        //    tabMein.SelectedTab = tpgRecom;
            
        //    //レコメンド成功率
        //    //成功数
        //    double dblRecSucCNT = double.Parse(clsDbj.fctFillTop("SELECT COUNT(*) FROM 2012_01_21_おすすめ成功;"));
        //    //おすすめ数
        //    double dblRecomeCNT = double.Parse(clsDbj.fctFillTop("SELECT COUNT(*) FROM RecommendationT;"));
        //    //売上数
        //    double dblSaleListCNT = double.Parse(clsDbj.fctFillTop("SELECT COUNT(*) FROM SaleListT WHERE (((SaleListT.SaleList_Money)<>0)); "));

        //    //売上数分のおすすめ成功数
        //    lblRecSuc.Text = Math.Round((dblRecSucCNT / dblRecomeCNT)*100,2).ToString() + " %";

        //    //おすすめ成功作品  //2012_01_31_おすすめ_成功数
        //    dgvMonSucProNam.DataSource = clsDbj.fctFilldgv("SELECT 2012_01_29_おすすめベース.Product_ProductName AS 商品名, Count(*) AS 数 FROM 2012_01_29_おすすめベース GROUP BY 2012_01_29_おすすめベース.Product_ProductName ORDER BY Count(*) DESC;");

        //    //ジャンル毎の成功数 //2012_01_31_おすすめ_ジャンル比率
        //    dgvMonSucGenCou.DataSource = clsDbj.fctFilldgv("SELECT 2012_01_29_おすすめベース.Product_Genre, COUNT(*) FROM 2012_01_29_おすすめベース GROUP BY 2012_01_29_おすすめベース.Product_Genre ORDER BY COUNT(*) DESC;");

        //    //おすすめ回数
        //    lblRecCount.Text = clsDbj.fctFillTop("SELECT COUNT(*) FROM RecommendationT;") + " 回";

        //    //全体売上おすすめ率
        //    lblRecSaleparRec.Text = Math.Round((dblRecSucCNT / dblSaleListCNT) * 100, 2).ToString() + " %"; ;

        //    //成功レコメンドのジャンル比率
        //    Chart(crtMonRecGen, "ジャンル比率", dgvMonSucGenCou);
            
        //}

        ////●おすすめ分析のDGVをクリック
        //private void dgvMonSucProNam_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //MessageBox.Show(dgvMonSucProNam[0, dgvMonSucProNam.CurrentCell.RowIndex].Value.ToString());
        //    //借りた人の情報年代比率
        //    dgvRecomAge.DataSource = clsDbj.fctFilldgv("SELECT MemberV.age, COUNT(*)"
        //        + " FROM MemberV INNER JOIN 2012_01_29_おすすめベース ON MemberV.Member_MemberId = 2012_01_29_おすすめベース.Sale_MemberId"
        //        + " WHERE 2012_01_29_おすすめベース.Product_ProductName = '" + dgvMonSucProNam[0, dgvMonSucProNam.CurrentCell.RowIndex].Value.ToString() + "'"
        //        + " GROUP BY MemberV.age"
        //        + " ;"
        //        );

        //    //借りた人の情報性別比率
        //    dgvRecomSex.DataSource = clsDbj.fctFilldgv("SELECT MemberT.Member_Sex, COUNT(*)"
        //        + " FROM MemberT INNER JOIN 2012_01_29_おすすめベース ON MemberT.Member_MemberId = 2012_01_29_おすすめベース.Sale_MemberId"
        //        + " WHERE 2012_01_29_おすすめベース.Product_ProductName='" + dgvMonSucProNam[0, dgvMonSucProNam.CurrentCell.RowIndex].Value.ToString() + "'"
        //        + " GROUP BY MemberT.Member_Sex"
        //        + " ;"
        //        );

        //    Chart(crtRecomSex, "性比率", dgvRecomSex);

        //    Chart(crtRecomAge, "年代比率", dgvRecomAge);
        //}

   //     //★円グラフを更新する関数
   //     private void Chart(System.Windows.Forms.DataVisualization.Charting.Chart chr,string strTitle,DataGridView dgv)
   //     {
   //             //ジャンル毎の円グラフ
   //         //グラフを更新
   //         chr.Series.Clear();  //グラフ初期化
   //         chr.Series.Add(strTitle);  //グラフ追加
   //         //グラフの種類を指定（Columnは棒グラフ）
   //         chr.Series[strTitle].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
   //         for (int i = 0; i < dgv.Rows.Count; i++)
   //         {
   //             //グラフに追加するデータクラスを生成
   //             System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
   //             dp.SetValueXY(dgv[0,i].Value.ToString(), Convert.ToInt32(dgv[1, i].Value.ToString()));  //XとYの値を設定
   //             dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
   //             chr.Series[strTitle].Points.Add(dp);   //グラフにデータ追加
   //         }
   //     }

   //     //★円グラフを更新する関数
   //     private void ChartB(System.Windows.Forms.DataVisualization.Charting.Chart chr, string strTitle, DataGridView dgv)
   //     {
   //         //ジャンル毎の円グラフ
   //         //グラフを更新
   //         chr.Series.Clear();  //グラフ初期化
   //         chr.Series.Add(strTitle);  //グラフ追加
   //         //グラフの種類を指定（Columnは棒グラフ）
   //         chr.Series[strTitle].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
   //         for (int i = 0; i < dgv.Rows.Count; i++)
   //         {
   //             //グラフに追加するデータクラスを生成
   //             System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
   //             dp.SetValueXY(dgv[0, i].Value.ToString(), Convert.ToInt32(dgv[1, i].Value.ToString()));  //XとYの値を設定
   //             dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
   //             chr.Series[strTitle].Points.Add(dp);   //グラフにデータ追加
   //         }
   //     }

   //     //★積み上げ棒グラフ
   //     public void BarGraph(System.Windows.Forms.DataVisualization.Charting.Chart chr,DataGridView dgv,string[,] str,int[,] intGet) {
            
   //         string[] legends = new string[dgv.RowCount]; //凡例
   //         for (int i = 0; i < dgv.RowCount; i++)
			//{
			//    legends[i]= dgv[0,i].Value.ToString();
			//}

   //         chr.Series.Clear();  //グラフ初期化

   //         foreach (var item in legends)
   //         {
   //             chr.Series.Add(item);    //グラフ追加
   //             //グラフの種類を指定（Columnは積み上げ縦棒グラフ）
   //             chr.Series[item].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
   //             chr.Series[item].LegendText = item;  //凡例に表示するテキストを指定
   //         }

   //         string[] xValues = new string[12] ;    //X軸のデータ//時間名のデータ

   //         for (int i = 0; i < 12; i++)
   //         {
   //             xValues[i]=str[0,i];
   //         }
              
   //         int[,] yValues = new int[dgv.RowCount,13] ;//{ { 10, 20, 30, 40, 50 }, { 20, 40, 60, 80, 100 } };    //Y軸のデータ
   //         //時間名
   //         for (int i = 0; i < dgv.RowCount; i++)
   //         {
   //             //個数
   //             for (int j = 0; j < 12; j++)
   //             {
   //                yValues[i, j] = intGet[i,j];
                    
   //             }
   //         }

   //         for (int i = 0; i < xValues.Length; i++)
   //         {
   //             for (int j = 0; j < yValues.GetLength(0); j++)
   //             {
   //                 //グラフに追加するデータクラスを生成
   //                 System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
   //                 dp.SetValueXY(xValues[i], yValues[j, i]);   //XとYの値を設定
   //                 dp.IsValueShownAsLabel = false;              //グラフに値を表示するように指定
   //                 chr.Series[legends[j]].Points.Add(dp);      //グラフにデータ追加
   //             }
   //         }
        
   //     }

        //顧客編集////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //●メンバー顧客編集
        private void btnMemberEdit_Click(object sender, EventArgs e)
        {
            //再読み込みクリックを呼び出し
            btnMemberReload_Click(sender, e);
            //メンバー編集にタブをフォーカス
            tabMein.SelectedTab = tabPage4;
        }

        //●メンバー再読み込み
        private void btnMemberReload_Click(object sender, EventArgs e)
        {
            dgvMemberShow.DataSource = clsDbj.fctFilldgv("SELECT MemberT.Member_MemberId AS 顧客ID, MemberT.Member_FamilyName AS 姓, MemberT.Member_FirstName AS 名, MemberT.Member_FamilyNameKana AS 姓カナ, MemberT.Member_FirstNameKana AS 名カナ, MemberT.Member_Sex AS 性別, MemberT.Member_TelephoneNumber AS 電話番号, MemberT.Member_MailAdress AS メールアドレス, MemberT.Member_Zip AS 郵便番号, MemberT.Member_Prefecture AS 都道府県, MemberT.Member_Municipality AS 市区町村, MemberT.Member_HouseAddres AS 番地, MemberT.Member_HouseNumber AS 番地2, MemberT.Member_Building AS 建物名, MemberT.Member_Birth AS 誕生日"
                + " FROM MemberT ORDER BY MemberT.Member_MemberId;");
            for (int i = 0; i < 15; i++)
            {
                //ボタンコントロールを検索して名前をつける
                Control[] cs = this.Controls.Find("txtMember" + (i + 1).ToString(), true);
                if (cs.Length > 0)
                {
                    ((TextBox)cs[0]).Text = "";
                }
            }
            lblRenewDate.Text = "最終更新時間　" + System.DateTime.Now.ToString();
        }

        //●メンバー削除
        private void btnMemberDelete_Click(object sender, EventArgs e)
        {
            if (txtMember1.Text != "")
            {
                if (fctDialogCheck("メンバーを削除しますか？"))
                {
                    clsDbj.fctInsert("UPDATE MemberT SET MemberT.Member_WithdrawDate = " + System.DateTime.Now.ToShortDateString()
                        + " WHERE (((MemberT.Member_MemberId)='" + txtMember1.Text + "'));");
                    btnMemberEdit_Click(sender, e);
                }
            }
            else {
                lblMemberError.Text = "会員番号がありません";
            }
        }

        //●メンバー編集
        private void btnMemberChange_Click(object sender, EventArgs e)
        {
            if (fctDialogCheck("メンバーを編集しますか？"))
            {
                //メンバー編集
                fctMemberEdit();
                //リスト更新更新
                btnMemberEdit_Click(sender, e);
            }
        }

        //●ID取得クリック
        private void btnMemberIdGet_Click(object sender, EventArgs e)
        {
            //会員番号がなければ
            if (txtMember1.Text == "")
            {
                //会員番号の最終番号を取得
                string strMenberIdMax = clsDbj.fctFillTop("SELECT MAX(Member_MemberId) From MemberT;");
                long lngMemberIdMax = long.Parse(strMenberIdMax);
                //最終番号に１を加算し新しい番号を生成
                lngMemberIdMax++;
                //新しい番号をセット
                txtMember1.Text = lngMemberIdMax.ToString();
            }
            else {
                lblMemberError.Text = "既に会員番号が存在します";
            }
        }

        //●メンバー追加をクリック
        private void btnMemberAdd_Click(object sender, EventArgs e)
        {

            if (fctDialogCheck("メンバーを追加しますか？"))
            {
                if (txtMember1.Text != "")
                {
                    //会員番号をDBに追加
                    clsDbj.fctInsert("INSERT INTO MemberT(Member_MemberId) values('" + txtMember1.Text + "');");
                    //メンバー編集
                    fctMemberEdit();
                    //リスト更新
                    btnMemberEdit_Click(sender, e);
                }
                else if (fctDialogCheck("会員番号がありませんが会員番号を取得して更新しますか？"))
                {
                    btnMemberIdGet_Click(sender, e);
                    fctMemberEdit();
                }
            }
        }

        //★メンバー編集
        private void fctMemberEdit() {
            if (txtMember1.Text != "")
            {
                if (txtMember15.Text == "") {
                    txtMember15.Text = "2012/01/01";

                }
                clsDbj.fctInsert("UPDATE MemberT SET"
                            + " MemberT.Member_FamilyName =" + "'" + txtMember2.Text + "'"
                            + ", MemberT.Member_FirstName =" + "'" + txtMember3.Text + "'"
                            + ", MemberT.Member_FamilyNameKana =" + "'" + txtMember4.Text + "'"
                            + ", MemberT.Member_FirstNameKana =" + "'" + txtMember5.Text + "'"
                            + ", MemberT.Member_Sex =" + "'" + txtMember6.Text + "'"
                            + ", MemberT.Member_TelephoneNumber =" + "'" + txtMember7.Text + "'"
                            + ", MemberT.Member_MailAdress =" + "'" + txtMember8.Text + "'"
                            + ", MemberT.Member_Zip =" + "'" + txtMember9.Text + "'"
                            + ", MemberT.Member_Prefecture =" + "'" + txtMember10.Text + "'"
                            + ", MemberT.Member_Municipality =" + "'" + txtMember11.Text + "'"
                            + ", MemberT.Member_HouseAddres =" + "'" + txtMember12.Text + "'"
                            + ", MemberT.Member_HouseNumber =" + "'" + txtMember13.Text + "'"
                            + ", MemberT.Member_Building =" + "'" + txtMember14.Text + "'"
                            + ", MemberT.Member_Birth =" + txtMember15.Text
                            + " WHERE MemberT.Member_MemberId =" + "'" + txtMember1.Text + "'"
                             + ";");
            }
            else { 
                lblMemberError.Text = "会員番号がありません";
            }
        }

        //●ロウヘッダーがクリックされた時
        private void dgvMemberShow_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                //ボタンコントロールを検索して名前をつける
                Control[] cs = this.Controls.Find("txtMember" + (i + 1).ToString(), true);
                if (cs.Length > 0)
                {
                    ((TextBox)cs[0]).Text = dgvMemberShow[i, dgvMemberShow.CurrentCell.RowIndex].Value.ToString();

                }
                if (i == 14 && dgvMemberShow[i, dgvMemberShow.CurrentCell.RowIndex].Value.ToString()!="")
                {
                    if (cs.Length > 0)
                    {
                        DateTime dt = Convert.ToDateTime(dgvMemberShow[i, dgvMemberShow.CurrentCell.RowIndex].Value.ToString());
                        ((TextBox)cs[0]).Text = dt.ToShortDateString();

                    }
                }
            }
        }

        private bool fctDialogCheck(string strComment) {
            //ダイアログボックスを表示
            DialogResult result = MessageBox.Show(strComment,
                "質問",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //OKが選択
            if (result == DialogResult.OK)
            {
                return true;
            }
            //キャンセルが選択
            else
            {
                return false;
            }
        }

        //▲時計をすすめる
        private void timer_Tick(object sender, EventArgs e)
        {
            lblNowTime.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ssああああ");
        }

        //会員
        private void dgvMemberShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                //ボタンコントロールを検索して名前をつける
                Control[] cs = this.Controls.Find("txtMember" + (i + 1).ToString(), true);
                if (cs.Length > 0)
                {
                    ((TextBox)cs[0]).Text = dgvMemberShow[i, dgvMemberShow.CurrentCell.RowIndex].Value.ToString();

                }
                if (i == 14 && dgvMemberShow[i, dgvMemberShow.CurrentCell.RowIndex].Value.ToString() != "")
                {
                    if (cs.Length > 0)
                    {
                        DateTime dt = Convert.ToDateTime(dgvMemberShow[i, dgvMemberShow.CurrentCell.RowIndex].Value.ToString());
                        ((TextBox)cs[0]).Text = dt.ToShortDateString();

                    }
                }
            }
        }


        //その他////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //●閉じる
        private void button8_Click_1(object sender, EventArgs e)
        {
            clsDbj.fctInsert("UPDATE StockT SET Stock_LoanCheck = '1';");
            this.Close();
        }

        //●メール画面を開く
        private void btnMail_Click(object sender, EventArgs e)
        {
            frmMail newForm = new frmMail();
            newForm.Show();
        }

        //●商品検索を開く
        private void btnProductSerch_Click(object sender, EventArgs e)
        {
            frmSeach newForm = new frmSeach();
            newForm.Show();
        }

        //発注////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //●発注_発注を開く
        private void btnStockSet_Click(object sender, EventArgs e)
        {
            //タブ切り替え
            tabMein.SelectedTab = tpgOrder;


                        //dgvOrder_OrderList.Rows.Add(new Object[] { "fasdf", "fasdfd", "fasdfds", 1 });
                        //dgvOrder_OrderList.Rows.Add(new Object[] { "fasdf", "fasdfd", "fasdfds", 1 });

            //発注のジャンルにジャンル割り当てを行う
            clsOpe.fctSearchSelect(cmxOrder_GenreSelect, "SELECT DISTINCT Product_Genre FROM ProductT;");
            

        }


        //▲発注_商品検索のテキストボックスが変わった時
        private void txtPro_ProductSerch_TextChanged(object sender, EventArgs e)
        {
            fctProductSerch();
        }

        //★発注_商品テーブルから検索する
        private void fctProductSerch() {
            string strGenre = " AND Product_Genre ='" + cmxOrder_GenreSelect.Text + "'";
            if (cmxOrder_GenreSelect.Text=="全て")
            {
                strGenre = "";
            }
            dgvOrder_ProductShow.DataSource = clsDbj.fctFilldgv("SELECT Product_ProductId AS 商品ID, Product_ProductName AS 商品名, Product_Genre AS ジャンル "
                + "FROM ProductT WHERE Product_ProductName Like '" + txtOrder_ProductSerch.Text + "%'" + strGenre + ";");
        }

        //●発注_オーダーリスト削除
        private void dgvOrder_OrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clsOpe.fctDgvPushDelete(sender,e);
        }

        //●発注_リストをダブルクリック
        private void dgvOrder_ProductShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddList();
        }

        //★発注_リストに追加する関数
        public void AddList() {
            int intColumnCount = 4;
            object[] objProduct = new object[intColumnCount];
            for (int i = 0; i < intColumnCount; i++)
            {
                objProduct[i] = dgvOrder_ProductShow[i, dgvOrder_ProductShow.CurrentCell.RowIndex].Value.ToString();
                
            }
            objProduct[3] = "1";
            dgvOrder_OrderList.Rows.Add(objProduct);
        }

        //●発注_発注数量全件変更
        private void btnOrder_AllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvOrder_OrderList.Rows.Count; i++)
			{
			    dgvOrder_OrderList[3,i].Value = cmbOrder_OrderCount.Text; 
			}
            
        }

        //●発注_商品検索_おすすめリスト
        private void btnOrder_RecomendlistSerch_Click(object sender, EventArgs e)
        {
            //商品リストにおすすめリストを読み込む
            dgvOrder_ProductShow.DataSource = clsDbj.fctFilldgv("SELECT Product_ProductId AS 商品ID,Product_ProductName AS 商品名, Product_Genre ジャンル,Count(*) AS 成功数 FROM 2012_01_29_おすすめベース GROUP BY 2012_01_29_おすすめベース.Product_ProductName ORDER BY Count(*) DESC;");

        }

        //●発注_商品検索_新作リスト
        private void btnOrder_NewlistSerch_Click(object sender, EventArgs e)
        {
            //発注リストに新作リストを読み込む
            dgvOrder_ProductShow.DataSource = clsDbj.fctFilldgv("");
        }

        //●発注_オールセレクト
        private void btnOrder_DgvAllSelect_Click(object sender, EventArgs e)
        {
            clsOpe.fctDgvAllSelect(dgvOrder_ProductShow);
        }

        //●発注_オールキャンセル
        private void btnOrder_DgvAllCancell_Click(object sender, EventArgs e)
        {
            clsOpe.fctDgvAllCancell(dgvOrder_ProductShow);
        }

        //●発注_追加
        private void btnOrder_OrderListAdd_Click(object sender, EventArgs e)
        {
            int intColumnCount = 4;
            for (int i = 0; i < dgvOrder_ProductShow.Rows.Count; i++)
            {

                object[] objProduct = new object[intColumnCount];
                if (dgvOrder_ProductShow.Rows[i].Selected == true)
                {

                    for (int j = 0; j < intColumnCount; j++)
                    {
                        objProduct[j] = dgvOrder_ProductShow[j, i].Value.ToString();

                    }
                    objProduct[3] = "1";
                    dgvOrder_OrderList.Rows.Add(objProduct);
                }
            }
        }

        //▲発注_ジャンルが変わった時
        private void cmxOrder_GenreSelect_TextChanged(object sender, EventArgs e)
        {
            fctProductSerch();
        }

        //●発注_オーダーリスト全件削除
        private void button2_Click(object sender, EventArgs e)
        {
            dgvOrder_OrderList.Rows.Clear();

        }

        //●発注_発注確定
        private void btnOrder_OrderEnter_Click(object sender, EventArgs e)
        {
            bool flg = true;

            //数量見入力時のエラーメッセージ
            for (int i = 0; i < dgvOrder_OrderList.Rows.Count; i++)
            {
                if (dgvOrder_OrderList[3, i].Value.ToString() == "0" || dgvOrder_OrderList[3, i].Value.ToString() == "")
                {
                    MessageBox.Show("数量の未入力があります。");
                    flg = false;
                }
            }

            if (flg == true)
            {
                //エクセルの宣言
                Microsoft.Office.Interop.Excel.Application oXlsApp;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;
                Microsoft.Office.Interop.Excel.Range[,] Syouhin = new Microsoft.Office.Interop.Excel.Range[10, 10];
                Microsoft.Office.Interop.Excel.Range oxlOrderDate;
                Microsoft.Office.Interop.Excel.Range oxlOrderNumber;
                Microsoft.Office.Interop.Excel.Range oxlDeliverDate;

                // エクセル起動
                oXlsApp = new Microsoft.Office.Interop.Excel.Application();

                // エクセル非表示
                oXlsApp.Application.Visible = false;
                oXlsApp.Application.DisplayAlerts = false;

                //テンプレートを呼び出し
                oXlsApp.Application.Workbooks.Add("C:/Users/Kensaku/Dropbox/OrderSeet.xltx");

                // シート選択
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oXlsApp.Worksheets[1];

                // カラム幅設定
                //oSheet.Columns("C").ColumnWidth = 20
                ((Microsoft.Office.Interop.Excel.Range)oSheet.get_Range(oSheet.Cells[11, 7], oSheet.Cells[65535, 7])).ColumnWidth = 17;

                // カラムの書式設定の表示形式を文字列にする
                //oSheet.Columns("C").NumberFormatLocal = "@"
                ((Microsoft.Office.Interop.Excel.Range)oSheet.get_Range(
                    oSheet.Cells[1, 3],
                    oSheet.Cells[65535, 3])).NumberFormatLocal = "@";

                //発注日の当てはめ
                oxlOrderDate = oSheet.get_Range(oSheet.Cells[3, 6], oSheet.Cells[3, 6]);
                oxlOrderDate.Value2 = System.DateTime.Now.ToShortDateString();

                oxlOrderNumber = oSheet.get_Range(oSheet.Cells[4, 6], oSheet.Cells[4, 6]);
                oxlOrderNumber.Value2 = "000001";

                oxlDeliverDate = oSheet.get_Range(oSheet.Cells[17, 2], oSheet.Cells[17, 2]);
                oxlDeliverDate.Value2 = System.DateTime.Now.AddDays(7).ToShortDateString();

                //セルを当てはめる
                int intStart = 20;
                int intDgvRowsCount = dgvOrder_OrderList.Rows.Count;
                for (int i = 0; i < intDgvRowsCount; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Syouhin[i, j] = oSheet.get_Range(oSheet.Cells[intStart, j + 1], oSheet.Cells[intStart, j + 1]);

                        switch (j)
                        {
                            case 0:
                                Syouhin[i, j].Value2 = dgvOrder_OrderList[0, i].Value.ToString();//商品ID
                                break;

                            case 1:
                                Syouhin[i, j].Value2 = dgvOrder_OrderList[1, i].Value.ToString();//商品名
                                break;

                            case 2:
                                Syouhin[i, j].Value2 = "枚";
                                break;


                            case 3:
                                Syouhin[i, j].Value2 = dgvOrder_OrderList[3, i].Value.ToString();//枚数
                                break;


                            case 4:
                                Syouhin[i, j].Value2 = "7000";
                                break;

                            default:

                                break;
                        }
                    }

                    intStart++;
                }

                //データベースにインサート
                long lngOrderId = long.Parse(clsDbj.fctFillTop("select MAX(Order_OrderId) from OrderT;"));
                lngOrderId++;
                clsDbj.fctInsert("INSERT INTO `OrderT`(`Order_OrderId`, `Order_OrderDate`) VALUES ("+ lngOrderId +",'"+ System.DateTime.Now.ToShortDateString() +"')");
                for (int i = 0; i < intDgvRowsCount; i++)
                {
                    clsDbj.fctInsert("INSERT INTO `OrderListT`(`OrderList_OrderId`, `OrderList_RowNumber`, `OrderList_ProductId`, `OrderList_Number`, `Order_ProductPrice`, `Order_DeliverDate`)"
                        +" VALUES (" + lngOrderId +","+ i+1 +","+dgvOrder_OrderList[0, i].Value.ToString()+","+dgvOrder_OrderList[3, i].Value.ToString()+","+ 7000 +",'"+System.DateTime.Now.AddDays(7).ToShortDateString()+"');");

                }


                // エクセル表示
                oXlsApp.Application.Visible = true;
            }
        }




        //在庫////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //▲在庫_バーコド検索でエンターが押された時
        private void txtSto_BarcodeSerch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                //行を追加          //SELECT StockT.Stock_StockId,ProductT.Product_ProductName,PriceT.Price_LoanDivisionId, ProductT.Product_ReleaseYear FROM PriceT, ProductT,ProductandPriceT,StockT WHERE PriceT.Price_PriceId=ProductandPriceT.ProductandPrice_PriceId AND ProductandPriceT.ProductandPrice_ProductId=StockT.Stock_ProductId AND ProductT.Product_ProductId = ProductandPriceT.ProductandPrice_ProductId AND ProductT.Product_ProductId = StockT.Stock_ProductId AND StockT.Stock_StockId ='' ; 

                object[] objRowsAdd = clsDbj.fctFillOneRow("SELECT StockT.Stock_StockId,ProductT.Product_ProductName,ProductT.Product_ReleaseYear,PriceT.Price_LoanDivisionId FROM PriceT, ProductT,ProductandPriceT,StockT WHERE PriceT.Price_PriceId=ProductandPriceT.ProductandPrice_PriceId AND ProductandPriceT.ProductandPrice_ProductId=StockT.Stock_ProductId AND ProductT.Product_ProductId = ProductandPriceT.ProductandPrice_ProductId AND ProductT.Product_ProductId = StockT.Stock_ProductId "
                    + "AND StockT.Stock_StockId ='" + txtSto_BarcodeSerch.Text + "' ;");
                if (objRowsAdd[0] != "0")
                {
                    dgvStock_StockShow.Rows.Add(objRowsAdd);
                }
                fctDivChange();
                txtSto_BarcodeSerch.Text = "";
            }
        }
        /// <summary>
        /// ★在庫_在庫管理で区分を変更する関数
        /// </summary>
        public void fctDivChange() {
            int intOldDivColomn = 3;
            int intNewDivColomn = 4;

            for (int i = 0; i < dgvStock_StockShow.Rows.Count; i++)
            {
                    //区分が新作ならば
                    if (dgvStock_StockShow[intOldDivColomn, i].Value.ToString() == "新作")
                    {
                        dgvStock_StockShow[intNewDivColomn, i].Value = "準新作";

                    }
                    //区分が準新作ならば
                    else if (dgvStock_StockShow[intOldDivColomn, i].Value.ToString() == "準新作")
                    {
                        dgvStock_StockShow[intNewDivColomn, i].Value = "旧作";
                    }
                    else if (dgvStock_StockShow[intOldDivColomn, i].Value.ToString() == "旧作")
                    {
                        dgvStock_StockShow[intNewDivColomn, i].Value = "販売";
                    }   
            }
        }

        //●在庫_在庫商品をクリック
        private void btnProduct_Click(object sender, EventArgs e)
        {
            tabMein.SelectedTab = tpgProduct;
            txtSto_BarcodeSerch.Focus();
            
        }

        //●在庫_確定/印刷
        private void btnStock_Enter_Click(object sender, EventArgs e)
        {
            int intNewDivColomn = 4;
            string strNewProductDiv = "";

            for (int i = 0; i < dgvStock_StockShow.Rows.Count; i++)
			{
                    //価格区分が新作ならば
                    if (dgvStock_StockShow[intNewDivColomn, i].Value.ToString() == "新作")
                    {
                        strNewProductDiv = "01";

                    }
                    //価格区分が準新作ならば
                    else if (dgvStock_StockShow[intNewDivColomn, i].Value.ToString() == "準新作")
                    {
                        strNewProductDiv = "11";
                    }

                    else if (dgvStock_StockShow[intNewDivColomn, i].Value.ToString() == "旧作")
                    {
                        strNewProductDiv = "21";
                    }

                    //在庫商品IDを基に価格を変更するSQL
                    clsDbj.fctInsert("UPDATE StockEditV SET ProductandPrice_PriceId = '" + strNewProductDiv + "' WHERE Stock_StockId ="+dgvStock_StockShow[0, i].Value.ToString()+";");
                    MessageBox.Show("変更が完了しました");
                    dgvStock_StockShow.Rows.Clear();
                    
            }
            txtSto_BarcodeSerch.Focus();
        }

        //●在庫_DGV内の削除ボタンクリック
        private void dgvStock_StockShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clsOpe.fctDgvPushDelete(sender,e);
            txtSto_BarcodeSerch.Focus();
        }

        //●在庫_全件削除クリック
        private void btnSto_DgvClear_Click(object sender, EventArgs e)
        {
            dgvStock_StockShow.Rows.Clear();
            txtSto_BarcodeSerch.Focus();
        }

        //●売上_リスト表示をクリック
        private void btnSale_GenreListChange_Click(object sender, EventArgs e)
        {
            //DGVを表示する
            if (dgvGenre.Visible == false)
            {
                dgvGenre.Visible = true;
                chrSale_Genre.Visible = false;
                btnSale_GenreListChange.Text = "グラフ表示";
            }
            else {
                dgvGenre.Visible = false;
                chrSale_Genre.Visible = true;
                btnSale_GenreListChange.Text = "リスト表示";
            }
        }

        private void tpgStoreState_Click(object sender, EventArgs e)
        {

        }

        //●在庫状況_在庫状況クリック
        private void button1_Click(object sender, EventArgs e)
        {
            tabMein.SelectedTab = tpgStoreState;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if ((int)keyData == (int)Keys.F5)
            {
                this.Close();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        //●本日納品がクリック
        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void gbxSto_Enter(object sender, EventArgs e)
        {

        }

        //予約////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        DataTable dtlResPrint = new DataTable();

        //●予約表印刷
        private void btnResPrint_Click(object sender, EventArgs e)
        {
            DataTable dtlRes = clsDbj.fctFilldgv("SELECT ProductId,MemberId"
                                +" FROM t_reservation "
//                                +" WHERE `ComeDate` = '0000-00-00'" //今日の日付
                                + " GROUP BY ProductId ,MemberId,ResNumber"
                                +" ORDER BY `ResNumber`"
                                +";"
                                );
            DataTable dtlSrock = clsDbj.fctFilldgv("SELECT `Stock_ProductId`, `Stock_StockId`,`Product_ProductName`,`Product_Genre`"
                +" FROM stockt,productt"
                +" WHERE `Product_ProductId` = `Stock_ProductId`"
                +" AND `Stock_LoanCheck` = '1'"
                + ";");
            
            for (int i = 0; i < 6; i++)
            {
                dtlResPrint.Columns.Add();
            }
            


            //予約テーブルの行数分繰り返す
            for (int i = 0; i < dtlRes.Rows.Count; i++)
            {
                //在庫テーブルの行数分繰り返す
                for (int j = 0; j < dtlSrock.Rows.Count; j++)
                {
                    //同じプロダクトIDがあった場合
                    if (dtlRes.Rows[i][0].ToString() == dtlSrock.Rows[j][0].ToString())
                    {
                        object[] objResAdd = new object[6];
                        for (int k = 0; k < 2; k++)
                        {
                            objResAdd[k]=dtlRes.Rows[i][k].ToString();
                        }

                        //
                        for (int k = 2; k < 4; k++)
                        {
                            objResAdd[k]=dtlSrock.Rows[i][k].ToString();
                        }

                        dtlResPrint.Rows.Add(objResAdd);
                        //ストックテーブルの行を削除する
                        dtlSrock.Rows.RemoveAt(j);
                        break;
                    }
                }
            }

            //テスト表示
            dataGridView1.DataSource = dtlResPrint;

            //エクセルの宣言
            Microsoft.Office.Interop.Excel.Application oXlsApp;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range[,] Syouhin = new Microsoft.Office.Interop.Excel.Range[10, 10];

            // エクセル起動
            oXlsApp = new Microsoft.Office.Interop.Excel.Application();

            // エクセル非表示
            oXlsApp.Application.Visible = false;
            oXlsApp.Application.DisplayAlerts = false;

            //テンプレートを呼び出し
            oXlsApp.Application.Workbooks.Add("C:/Users/Kensaku/Dropbox/ResSeet.xltx");

            // シート選択
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oXlsApp.Worksheets[1];

            // カラム幅設定
            //oSheet.Columns("C").ColumnWidth = 20
            ((Microsoft.Office.Interop.Excel.Range)oSheet.get_Range(oSheet.Cells[11, 7], oSheet.Cells[65535, 7])).ColumnWidth = 17;

            // カラムの書式設定の表示形式を文字列にする
            //oSheet.Columns("C").NumberFormatLocal = "@"
            ((Microsoft.Office.Interop.Excel.Range)oSheet.get_Range(
                oSheet.Cells[1, 3],
                oSheet.Cells[65535, 3])).NumberFormatLocal = "@";

            //発注日の当てはめ

            //セルを当てはめる
            //ループ開始
            int intStart = 5;
            
            //リストの数を取得
            int intDgvRowsCount = dtlResPrint.Rows.Count;
            for (int i = 0; i < intDgvRowsCount; i++)
            {
                //横幅
                for (int j = 0; j < 5; j++)
                {
                    Syouhin[i, j] = oSheet.get_Range(oSheet.Cells[intStart, j + 1], oSheet.Cells[intStart, j + 1]);

                    switch (j)
                    {
                        case 0:
                            
                            break;

                        case 1:
                            Syouhin[i, j].Value2 = dtlResPrint.Rows[i][0].ToString();//予約者名
                            break;

                        case 2:
                            Syouhin[i, j].Value2 = dtlResPrint.Rows[i][1].ToString();//商品ID
                            break;


                        case 3:
                            Syouhin[i, j].Value2 = dtlResPrint.Rows[i][2].ToString();//商品名
                            break;


                        case 4:
                            Syouhin[i, j].Value2 = dtlResPrint.Rows[i][3].ToString();//ジャンル
                            break;

                        default:

                            break;
                    }
                }

                intStart++;
            }

            // エクセル表示
            oXlsApp.Application.Visible = true;

            //メール送信
            for (int i = 0; i < dtlResPrint.Rows.Count; i++)
            {
                string strMailMessage = "";
                strMailMessage += "お客様がご予約されていた商品が準備できました。\n本日の来店をお待ちしております。";

                clsOpe.SendMailac("MATSUTAYA予約完了お知らせ",strMailMessage);
            }
            
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            //予約印刷をクリック
            btnResPrint_Click(sender, e);
        }


    }
}
