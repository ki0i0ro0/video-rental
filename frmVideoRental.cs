using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace rental
{
    public partial class frmVideoRental : Form
    {
        public frmVideoRental()
        {
            InitializeComponent();
        }

        private void btnClearDgv_Click(EventArgs e)
        {
            throw new NotImplementedException();
        }

        //■宣言エリア
        //オブジェクトの宣言
        //OleDbConnection cn = new OleDbConnection();//DBコネクション用オブジェクト
        private clsDbJoin clsDbj = new clsDbJoin();
        private clsOperation clsOpe = new clsOperation();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbConnection cn;
        private string ipadress = "127.0.0.1";

        //フォームをロードした
        private void lblMember_Age_Load(object sender, EventArgs e)
        {
            //マイクロソフトアクセスのアクセスコードをコネクションに読み込む
            cn = new OleDbConnection("server=" + ipadress + ";User Id=Kensaku;password=1234;database=rental;Persist Security Info=True;Character Set=utf8;Allow Zero Datetime=True");

            //コネクションコマンドをセット
            cmd.Connection = cn;
            txtChange.Text = "0";

        }

        ////////////
        //メイン業務
        //■は全てメイン業務を表す
        ////////////

        //■会員番号が入力された場合
        private void txtMemberId_KeyDown(object sender, KeyEventArgs e)
        {
            //エンターが押される
            if (e.KeyCode == Keys.Enter)
            {
                //会員番号を元に会員情報を検索するSQL文
                string strSqlMemberIdSerch = "SELECT Member_FamilyNameKana, Member_FamilyName, Member_Birth, Member_Sex, Member_TimeLimit, Member_LastCome, Member_TotalCome,MemberT.Member_FirstNameKana, MemberT.Member_FirstName FROM MemberT where Member_MemberId = '" + txtMemberId.Text + "'; ";

                string strMemberId = txtMemberId.Text;
                string strResProduct = "";

                //顧客番号から顧客情報を検索するSQL文
                cmd.CommandText = strSqlMemberIdSerch;
                cn.Open();

                OleDbDataReader rs = cmd.ExecuteReader();
                //検索の結果顧客番号があった場合
                if (rs.Read() == true)
                {
                    //誕生日の計算
                    DateTime dt1 = System.DateTime.Now; //基準日
                    DateTime dt2 = rs.GetDateTime(2); //誕生日
                    long d1 = Convert.ToInt64(dt1.ToString("yyyyMMdd")); //基準日を数値に変換
                    long d2 = Convert.ToInt64(dt2.ToString("yyyyMMdd")); //誕生日を数値に変換
                    int age = (int)Math.Floor((double)((d1 - d2) / 10000));
                    //検索の結果顧客番号があった場合は顧客情報を表示する
                    lblMember_Kana.Text = rs.GetString(0) + " " + rs.GetString(7);
                    lblMember_Name.Text = rs.GetString(1) + "　" + rs.GetString(8);
                    lblMember_Birth.Text = rs.GetDateTime(2).ToShortDateString();
                    lblAge.Text = age.ToString();
                    lblMember_Sex.Text = rs.GetString(3);
                    lblMember_Limit.Text = rs.GetDateTime(4).ToShortDateString();
                    lblMember_LastCome.Text = rs.GetDateTime(5).ToShortDateString();
                    lblMember_TotalCome.Text = rs.GetInt32(6).ToString();


                    //予約確認SQL
                    strResProduct = clsDbj.GetFillString("SELECT Product_ProductId,Product_ProductName,Product_Genre FROM `t_reservation` ,productt WHERE `ProductId` = Product_ProductId AND `MemberId` = '" + strMemberId + "'");
                    if (strResProduct != "")
                    {

                        MessageBox.Show("予約商品が存在します。" + strResProduct);
                    }

                    //表示・非表示
                    txtMemberId.Enabled = false;    //メンバーIDが入力不可
                    btnHistoryJump.Enabled = true;  //会員履歴が入力
                    fctComment("");
                    if (lblLone.BackColor == Color.Blue)
                    {
                        txtStockId.Enabled = true;
                        txtStockId.Focus();
                    }

                }
                else
                {
                    cn.Close();
                    fctComment("会員番号がありません");
                    txtMemberId.Text = "";
                }
                cn.Close();
                Lending();
            }
        }


        //■商品が入力された場合
        private void txtStockId_KeyDown(object sender, KeyEventArgs e)
        {

            int intOverlap = 0;
            //////////////
            //貸出時の処理
            //////////////
            if (e.KeyCode == Keys.Enter)
            {
                if (lblLone.BackColor == Color.Blue)
                {
                    //変数の宣言
                    string strGoodsCode = txtStockId.Text;
                    //在庫テーブルの中から入力されたIDで、泊数が0
                    string strSqlStockSerch = "SELECT StockT.Stock_StockId ,ProductT.Product_ProductName,PriceT.Price_LoanDivisionId,PriceT.Price_NightCount,PriceT.Price_Price,Stock_ProductId "
                        + "FROM (ProductT INNER JOIN (PriceT INNER JOIN ProductandPriceT ON PriceT.Price_PriceId = ProductandPriceT.ProductandPrice_PriceId) ON ProductT.Product_ProductId = ProductandPriceT.ProductandPrice_ProductId) INNER JOIN StockT ON ProductT.Product_ProductId = StockT.Stock_ProductId "
                        + "WHERE StockT.Stock_StockId ='" + txtStockId.Text + "'"
                        + " AND PriceT.Price_NightCount = 0"
                        + " AND StockT.Stock_LoanCheck = '1'"
                        + ";";

                    //コマンドを入れるためのオブジェクト
                    cmd.CommandText = strSqlStockSerch;
                    cn.Open();
                    OleDbDataReader rs = cmd.ExecuteReader(); //データリーダー（読んできたデータを一時的に入れておくところ）にSqlコマンドを入れて実行する

                    //商品番号検索の結果マッチングがある
                    if (rs.Read() == true)
                    {
                        //商品番号を変数に入れる
                        string strProductId = rs.GetString(5);
                        string strDiscountName = "なし";

                        //重複防止
                        for (int i = 0; i < dgvRentalShow.RowCount; i++)
                        {
                            if (rs.GetString(0) == dgvRentalShow[0, i].Value.ToString())
                            {
                                intOverlap = 1;
                                fctComment("バーコードが既に一覧に存在します");
                            }
                        }

                        //レコメンデーションテーブルから
                        string strRecomSQL = "SELECT RecommendationT.Recommendation_MemberId,"
                            + " RecommendationT.Recommendation_ProductId,"
                            + " RecommendationT.Recommendation_Date"
                            + " FROM RecommendationT"
                            + " WHERE Recommendation_ProductId = '" + strProductId + "'"
                            + " AND Recommendation_MemberId ='" + txtMemberId.Text + "'"
                            + " AND Recommendation_Date BETWEEN '"
                            + System.DateTime.Now.AddDays(-7).ToShortDateString()
                            + "' AND '"
                            + System.DateTime.Now.ToShortDateString()
                            + "' ;";

                        //おすすめ割引
                        if ("" != clsDbj.GetTopRow(
                        strRecomSQL))
                        {
                            strDiscountName = "おすすめ割引";
                        }

                        //DGVに表示させる
                        if (intOverlap == 0)
                        {
                            dgvRentalShow.AllowUserToAddRows = false;
                            dgvRentalShow.Rows.Add(rs.GetString(0), rs.GetString(1), rs.GetString(2), rs.GetInt32(3), strDiscountName, 0, rs.GetInt32(4), System.DateTime.Now.ToShortDateString(), rs.GetString(5));
                        }
                        cn.Close();

                        if (strDiscountName == "おすすめ割引")
                        {
                            NowRowMoney();
                        }



                        //////////////////////////
                        //使用可能一覧
                        //一括登録使用可能
                        txtKeepMoney.Enabled = true;
                        btnAllNigtCount.Enabled = true;
                        btnClearDgv.Enabled = true;
                        btnRowClear.Enabled = true;//1行取り消しを使えるようにする
                        btnDiscount.Enabled = true;
                        ////////////////////

                        //商品番号をリセットする
                        txtStockId.Text = "";

                        //DataGridViewのソート行う
                        dgvRentalShow.Sort(dgvRentalShow.Columns[2], ListSortDirection.Ascending);


                    }
                    cn.Close();
                }

                //////////////
                //返却時の処理
                //////////////
                else
                {
                    string strMemberId = "";

                    dgvReturnShow.Visible = true;
                    TimeSpan datSubmitDate = new TimeSpan();

                    //変数の宣言
                    //コネクションとコマンド変数

                    cmd.Connection = cn;
                    //商品番号から商品情報を検索するSQL文
                    cmd.CommandText = "SELECT StockT.Stock_StockId, ProductT.Product_ProductName, SaleT.Sale_StaffId, SaleT.Sale_SaleDate, SaleListT.SaleList_NightCount, SaleT.Sale_MemberId,SaleList_LoanDivision FROM (ProductT INNER JOIN StockT ON ProductT.Product_ProductId = StockT.Stock_ProductId) INNER JOIN ((MemberT INNER JOIN SaleT ON MemberT.Member_MemberId = SaleT.Sale_MemberId) INNER JOIN SaleListT ON SaleT.Sale_SaleNumber = SaleListT.SaleList_SaleNumber) ON StockT.Stock_StockId = SaleListT.SaleList_StockId WHERE StockT.Stock_LoanCheck = '0'  AND SaleListT.SaleList_StockId = '" + txtStockId.Text + "' AND SaleT.Sale_LoanDivisionId = '貸出' AND SaleT.Sale_SaleNumber IN (SELECT MAX(SaleListT.SaleList_SaleNumber) FROM StockT ,SaleT,  SaleListT WHERE Sale_SaleNumber = SaleListT.SaleList_SaleNumber AND StockT.Stock_StockId = SaleListT.SaleList_StockId AND SaleListT.SaleList_StockId = '" + txtStockId.Text + "' );";
                    //コネクションを開く
                    cn.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter(cmd.CommandText, cn);
                    //rsにレコードを入れた
                    OleDbDataReader rs = cmd.ExecuteReader();
                    if (rs.Read() == true)
                    {
                        //重複防止
                        for (int i = 0; i < dgvReturnShow.RowCount; i++)
                        {
                            if (rs.GetString(0) == dgvReturnShow[0, i].Value.ToString())
                            {
                                intOverlap = 1;
                            }
                        }
                        if (intOverlap == 0)
                        {
                            //泊数を計算して変数に入れる
                            datSubmitDate = System.DateTime.Now - rs.GetDateTime(3).AddDays(rs.GetInt32(4)); //今の時間引く貸出日
                            string strEntaiDate = "0";
                            if (datSubmitDate.Days > 0)
                            {
                                strEntaiDate = (datSubmitDate.Days).ToString();
                            }
                            //データグリッドビューへ行返却する商品の行を追加する
                            dgvReturnShow.AllowUserToAddRows = false;
                            dgvReturnShow.Rows.Add(
                                rs.GetString(0),//商品ID
                                rs.GetString(1),//商品名
                                rs.GetString(2),//スタッフ名
                                rs.GetDateTime(3).ToShortDateString(),//貸出日の日付
                                rs.GetString(6),
                                rs.GetInt32(4),             //泊数
                                strEntaiDate,  //延滞日数
                                int.Parse(strEntaiDate) * 300,//延滞金額
                                System.DateTime.Now.ToShortDateString()
                                );
                            strMemberId = rs.GetString(5); //会員情報をメンバーIDに入力
                        }
                        cn.Close();
                        //////////////////////////
                        //使用可能一覧
                        //一括登録使用可能
                        txtKeepMoney.Enabled = true;
                        btnAllNigtCount.Enabled = true;
                        btnClearDgv.Enabled = true;
                        btnRowClear.Enabled = true;//1行取り消しを使えるようにする
                        ////////////////////
                        //商品番号をリセットする
                        txtMemberId.Text = strMemberId;
                        txtStockId.Text = "";
                        //メンバーIDを取得する
                        fctMemberId();
                    }
                    cn.Close();
                }
                txtStockId.Text = "";
            }
            if (txtStockId.Text.Length == 12)
            {
                txtStockId.Text = "";
            }
        }

        //×会員番号に値が入力された時
        private void txtMember_Code_TextChanged(object sender, EventArgs e)
        {

        }

        //×泊数を加算する（DGVの中でEnterが押された場合）
        private void dgvRentalShow_KeyDown(object sender, KeyEventArgs e)
        {
        }

        //●会計をクリック
        private void btnKeepMoney_Click(object sender, EventArgs e)
        {
            txtKeepMoney.Focus();
        }

        //会計処理（会計の所でエンターが押された）
        private void txtKeepMoney_KeyDown(object sender, KeyEventArgs e)
        {
            string strTotalMoney = txtTotalMoney.Text;
            string strTax = txtTax.Text;

            if (e.KeyCode == Keys.Enter)
            {
                //貸出時の処理
                if (lblLone.BackColor == Color.Blue)
                {
                    //お預かり金が入力されている
                    if (txtKeepMoney.Text != "")
                    {
                        //お預かり金が合計金額より大きいならば
                        if (int.Parse(txtKeepMoney.Text) >= int.Parse(strTotalMoney))
                        {
                            //お釣りを計算して入力
                            txtChange.Text = (int.Parse(txtKeepMoney.Text) - int.Parse(strTotalMoney)).ToString();
                        }

                        if (txtChange.Text != "")
                        {
                            //DGVを返却予定日が早い順にソートする。
                            dgvRentalShow.Sort(dgvRentalShow.Columns[7], ListSortDirection.Ascending);

                            ////////////////////////////////////////
                            //DBへインサートする構文
                            ////////////////////////////////////////

                            //DB接続

                            cn.Open();
                            cmd.Connection = cn;
                            //伝票番号の一番大きな値を検索する
                            cmd.CommandText = "SELECT MAX(Sale_SaleNumber) AS Sale_SaleNumber FROM SaleT;";
                            OleDbDataReader rs = cmd.ExecuteReader();
                            rs.Read();
                            string strSaleNumber = Convert.ToString(rs.GetInt32(0) + 1);
                            cn.Close();

                            //売上を更新
                            cn.Open();
                            string strGoods_Code = dgvRentalShow[1, 0].Value.ToString();
                            cmd.CommandText = "INSERT INTO "
                                + "SaleT(Sale_SaleNumber,Sale_LoanDivisionId,Sale_KeepMoney,Sale_ChangeMoney,Sale_TotalManey,Sale_MemberId,Sale_SaleDate,Sale_StaffId) "
                                + "VALUES("
                                + strSaleNumber + ",'"       //伝票番号
                                + "貸出" + "'," 　          //貸出区分
                                + txtKeepMoney.Text + ","    //お預かり金
                                + txtChange.Text + ","       //お釣り
                                + strTotalMoney + ",'"  //合計金額
                                + txtMemberId.Text + "','"   //会員番号
                                + System.DateTime.Now.ToString() + "','"    //今日の日付
                                + lblStaffName.Text         //貸しだした人
                                + "');";
                            cmd.ExecuteNonQuery();
                            cn.Close();

                            //売上明細にデータをインサート
                            cn.Open();
                            //DGVの行分繰り返す
                            for (int i = 0; i < dgvRentalShow.Rows.Count; i++)
                            {
                                cmd.CommandText = "INSERT INTO SaleListT("
                                    + "SaleList_SaleNumber,"         //①売上番号
                                    + "SaleList_StockId,"           //②在庫番号
                                    + "SaleList_Money,"             //③金額
                                    + "SaleList_NightCount,"        //④泊数
                                    + "SaleList_ProductName,"       //⑤商品名
                                    + "SaleList_LoanDivision"
                                    + ",SaleList_ReturnDate"
                                    + ")"
                                    + " VALUES("
                                    + "'" + strSaleNumber + "',"                            //売上番号
                                    + "'" + dgvRentalShow[0, i].Value.ToString() + "',"     //在庫番号
                                    + dgvRentalShow[6, i].Value.ToString() + ","            //金額
                                    + dgvRentalShow[3, i].Value.ToString() + ","            //泊数
                                    + "'" + dgvRentalShow[1, i].Value.ToString() + "'" + ","//商品名
                                    + "'" + dgvRentalShow[2, i].Value.ToString() + "'"      //貸出区分
                                    + "," + "'" + System.DateTime.Now.AddDays(int.Parse(dgvRentalShow[3, i].Value.ToString())).ToShortDateString() + "'"
                                    + ");";
                                cmd.ExecuteNonQuery();
                            }
                            cn.Close();

                            //////////////////////
                            //ビデオを貸し出す
                            ////////////////
                            cn.Open();
                            for (int i = 0; i < dgvRentalShow.Rows.Count; i++)
                            {
                                string strSqlUpdate = "UPDATE StockT SET Stock_LoanCheck = 0 WHERE Stock_StockId = '"
                                    + dgvRentalShow[0, i].Value.ToString()
                                    + "';";
                                cmd.CommandText = strSqlUpdate;
                                cmd.ExecuteNonQuery();
                            }
                            cn.Close();

                            ////////////////////////////
                            //来店数を加算する
                            ////////////////////////////
                            int intMemberTotalCome = int.Parse(lblMember_TotalCome.Text);//総来店数
                            intMemberTotalCome++;
                            string strMemberId = txtMemberId.Text;
                            SqlInsert("UPDATE MemberT SET MemberT.Member_TotalCome = " + intMemberTotalCome.ToString()
                                + ", MemberT.Member_LastCome = '" + System.DateTime.Now.ToShortDateString() + "' "
                                + "WHERE (((MemberT.Member_MemberId)='" + strMemberId + "'));");


                            ////////////////////////////
                            //クリスタルレポート
                            ////////////////////////////


                            //DGVの行が無くなるまで繰り返す。
                            while (0 < dgvRentalShow.RowCount)
                            {
                                //データセットの宣言
                                Receipt dst = new Receipt();
                                //売上
                                Receipt.dtReceiptRow tr = (Receipt.dtReceiptRow)dst.dtReceipt.NewRow();
                                tr.BeginEdit();
                                tr.ReceiptNumber = strSaleNumber;   //売上番号
                                //ヘッダー
                                tr.StoreName = lblStoreName.Text;           //店舗名（仮）
                                tr.StoreTel = "TEL xxx-xxxx-xxxx";      //店舗電話番号（仮）
                                tr.LendDiv = "貸出レシート";
                                tr.SaleDate = "営業日 " + lblNowTime.Text;
                                tr.MemberId = txtMemberId.Text;

                                tr.TotalMoney = strTotalMoney;
                                tr.TaxMoney = strTax;
                                tr.CashMoneyTotal = strTotalMoney;
                                tr.KeepMoney = txtKeepMoney.Text;
                                tr.ChangeMoney = txtChange.Text;
                                tr.ReturnDate = dgvRentalShow[7, 0].Value.ToString();
                                tr.RegisterNumber = "001";
                                tr.SaleNumber = strSaleNumber;
                                tr.Staff = lblStaffName.Text;       //店員名
                                tr.EndEdit();
                                dst.dtReceipt.Rows.Add(tr);


                                string strStockDate = dgvRentalShow[7, 0].Value.ToString();
                                string strStock_ProductId = dgvRentalShow[8, 0].Value.ToString();
                                int[] intRemoveList = new int[10];
                                int k = 0;

                                //売上明細      //DGVの行数分
                                for (int j = 0; j < dgvRentalShow.RowCount; j++)
                                {
                                    //返却日が一番上の商品と同じ商品を抽出
                                    if (dgvRentalShow[7, j].Value.ToString() == strStockDate)
                                    {
                                        //データテーブルへ入れる
                                        Receipt.ReserveRow RLT = (Receipt.ReserveRow)dst.Reserve.NewRow();
                                        RLT.BeginEdit();
                                        RLT.DataColumn1 = dgvRentalShow[2, j].Value.ToString();//貸出区分
                                        RLT.DataColumn2 = dgvRentalShow[1, j].Value.ToString();//商品名
                                        RLT.DataColumn3 = dgvRentalShow[6, j].Value.ToString();//価格
                                        RLT.DataColumn4 = dgvRentalShow[3, j].Value.ToString();//泊数
                                        RLT.EndEdit();
                                        dst.Reserve.Rows.Add(RLT);
                                        k++;
                                    }
                                }
                                for (int Y = 0; Y < k; Y++)
                                {
                                    dgvRentalShow.Rows.RemoveAt(0);
                                }

                                //おすすめ商品にアクセスしデータを受け取る
                                var clReco = new clsDbJoin.clRecommendData();

                                clReco = clsDbj.GetRecommendation(strStock_ProductId, txtMemberId.Text);

                                //レコメンド１
                                Receipt.dtRecommendRow trr = (Receipt.dtRecommendRow)dst.dtRecommend.NewRow();
                                trr.BeginEdit();
                                trr.ProductName = clReco.strProductName;
                                trr.Comment = clReco.strDetail;
                                trr.EndEdit();
                                dst.dtRecommend.Rows.Add(trr);

                                //クリスタルレポートヴューに出力する。
                                crpReceipt cr = new crpReceipt();//クリスタルレポートの宣言
                                cr.SetDataSource(dst);               //データセットをクリスタルレポートにセット
                                frmShowReceipt newForm = new frmShowReceipt();
                                newForm.crvShowReceipt.ReportSource = cr;
                                newForm.ShowDialog();




                            }
                            //オールクリア
                            btnAllClear_Click(sender, e);
                        }
                    }
                }
                else
                {

                    //伝票番号の一番大きな値を取得する

                    int intSaleNumber = Convert.ToInt32(clsDbj.GetTopRow("SELECT MAX(Sale_SaleNumber) AS Sale_SaleNumber FROM SaleT;"));
                    intSaleNumber++;
                    string strSaleNumber = intSaleNumber.ToString();


                    //預かり金が見入力なら
                    if (txtKeepMoney.Text == "")
                    {
                        txtKeepMoney.Text = "0";
                        txtChange.Text = "0";
                    }

                    //返却金が見入力なら
                    if (txtChange.Text == "")
                    {
                        txtChange.Text = "0";
                    }




                    //売上を追加
                    string strGoods_Code = dgvReturnShow[1, 0].Value.ToString();
                    SqlInsert("INSERT INTO SaleT(Sale_SaleNumber,Sale_LoanDivisionId,Sale_KeepMoney,Sale_ChangeMoney,Sale_TotalManey,Sale_MemberId,Sale_SaleDate,Sale_StaffId) VALUES("
                        + strSaleNumber + ",'"       //売上番号
                        + "返却" + "'," 　          //貸出区分
                        + txtKeepMoney.Text + ","    //お預かり金
                        + txtChange.Text + ","       //お釣り
                        + strTotalMoney + ",'"  //合計金額
                        + txtMemberId.Text + "','"   //会員番号
                        + System.DateTime.Now.ToString() + "','"    //今日の日付
                        + lblStaffName.Text         //延滞処理を行った人
                        + "');");


                    //売上明細を更新
                    //DGVの行分繰り返す
                    for (int i = 0; i < dgvReturnShow.Rows.Count; i++)
                    {
                        SqlInsert("INSERT INTO SaleListT(SaleList_SaleNumber,SaleList_StockId,SaleList_Money,SaleList_NightCount) VALUES('"
                            + strSaleNumber + "','"                         //売上番号
                            + dgvReturnShow[0, i].Value.ToString() + "',"   //在庫番号
                            + int.Parse(dgvReturnShow[7, i].Value.ToString()) + ","                       //単価
                            + int.Parse(dgvReturnShow[6, i].Value.ToString())     //泊数
                            + ");");
                    }

                    //////////////////////////////////////
                    //貸出区分を返却にする

                    for (int i = 0; i < dgvReturnShow.Rows.Count; i++)
                    {
                        SqlInsert("UPDATE StockT SET Stock_LoanCheck = 1 WHERE Stock_StockId = '"
                            + dgvReturnShow[0, i].Value.ToString()
                            + "';");
                    }


                    //オールクリア
                    btnAllClear_Click(sender, e);
                }
            }
        }


        ///////////////////
        //ボタンイベント系
        //////////////////


        /// <summary>
        /// ログアウト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_Click_1(object sender, EventArgs e)
        {
            if (clsOpe.ShowMessageBox("ログアウトしますか？"))
            {
                Close();
            }
        }


        /// <summary>
        /// オールクリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllClear_Click(object sender, EventArgs e)
        {
            AllClear();
        }

        /// <summary>
        /// オールクリア
        /// </summary>
        private void AllClear()
        {
            btnHistoryJump.Enabled = false;//会員履歴
            txtMemberId.Text = "";
            txtStockId.Text = "";
            lblMember_Kana.Text = "";
            lblMember_Name.Text = "";
            lblMember_Birth.Text = "";
            lblMember_Sex.Text = "";
            lblMember_Limit.Text = "";
            lblMember_LastCome.Text = "";
            lblMember_TotalCome.Text = "";
            lblAge.Text = "";
            txtLend.Text = "0";
            txtLending.Text = "0";
            txtArrearage.Text = "0";
            txtChange.Text = "0";
            txtKeepMoney.Text = "";
            btnDiscount.Enabled = false;
            //エラーの所
            lblComment.Text = "";
            lblComment.BackColor = Color.DodgerBlue;


            txtMemberId.Focus();
            if (txtKeepMoney.Enabled == true)
            {
                ClearTextBox(gbxMoney);
            }
            if (lblLone.BackColor == Color.Blue)
            {
                txtMemberId.Enabled = true;
                txtMemberId.Focus();
                txtStockId.Enabled = false;

            }
            else
            {
                txtMemberId.Enabled = false;
                txtStockId.Enabled = true;
                txtStockId.Focus();
            }

            //返却処理
            dgvRentalShow.Rows.Clear();
            dgvReturnShow.Rows.Clear();
            txtKeepMoney.Enabled = false;
        }


        /// <summary>
        /// 一括泊数登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllNigtCount_Click(object sender, EventArgs e)
        {
            //貸出表に行がある場合
            for (int i = 0; i < dgvRentalShow.Rows.Count; i++)
            {
                DateTime DT = DateTime.Now;

                //０泊ではなく０行目の場合
                if (i == 0)
                {
                    //泊数を加算する
                    dgvRentalShow[3, 0].Value = int.Parse(dgvRentalShow[3, 0].Value.ToString()) + 1;

                    //泊数が４の場合は１週間にする。
                    if (int.Parse(dgvRentalShow[3, 0].Value.ToString()) == 4)
                    {
                        dgvRentalShow[3, i].Value = 7;

                    }

                    //泊数が８の場合は０にする
                    if (int.Parse(dgvRentalShow[3, 0].Value.ToString()) == 8)
                    {
                        dgvRentalShow[3, i].Value = 0;
                    }
                }



                dgvRentalShow[3, i].Value = dgvRentalShow[3, 0].Value;


                string strSqlPriceSerch = "SELECT Price_Price FROM PriceT "
                + "WHERE Price_NightCount =" + dgvRentalShow[3, i].Value.ToString()
                + " AND Price_LoanDivisionId = '" + dgvRentalShow[2, i].Value.ToString()
                + "';";

                //顧客番号から顧客情報を検索するSQL文
                cmd.CommandText = strSqlPriceSerch;

                cn.Open();
                OleDbDataReader rs = cmd.ExecuteReader();

                //検索の結果金額があった場合
                if (rs.Read() == true)
                {
                    //値段を変更する
                    dgvRentalShow[6, i].Value = rs.GetInt32(0);
                    //日付を変更する
                    dgvRentalShow[7, i].Value = (DT.AddDays(int.Parse(dgvRentalShow[3, i].Value.ToString()))).ToShortDateString();
                }
                cn.Close();
                NowRowMoney();
            }
        }

        /// <summary>
        /// データベースクリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearDgv_Click(object sender, EventArgs e)
        {
            //返却処理
            dgvRentalShow.Rows.Clear();
            dgvReturnShow.Rows.Clear();
            txtKeepMoney.Enabled = false;
        }

        //ショートカットが押された時
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((int)keyData == (int)Keys.F1)
            {
                btnOut.PerformClick();
                return true;
            }

            if ((int)keyData == (int)Keys.F2)
            {
                btnAllClear.PerformClick();
                return true;
            }

            if ((int)keyData == (int)Keys.F5)
            {
                btnSaleJump.PerformClick();
                return true;
            }

            if ((int)keyData == (int)Keys.F6)
            {
                btnHistoryJump.PerformClick();
                return true;
            }

            if ((int)keyData == (int)Keys.F7)
            {
                btnClearDgv.PerformClick();
                return true;
            }

            if ((int)keyData == (int)Keys.F8)
            {
                btnRowClear.PerformClick();
                return true;
            }

            if ((int)keyData == (int)Keys.F9)
            {
                btnDiscount.PerformClick();
                return true;
            }

            //●泊数変更
            if ((int)keyData == (int)Keys.F10)
            {
                //貸出表に行がある場合
                if (dgvRentalShow.Rows.Count != 0)
                {
                    DateTime DT = DateTime.Now;

                    //泊数が変更される
                    dgvRentalShow.CurrentCell = dgvRentalShow[3, dgvRentalShow.CurrentCell.RowIndex];

                    //泊数を１日加算する
                    dgvRentalShow.CurrentCell.Value = int.Parse(dgvRentalShow.CurrentCell.Value.ToString()) + 1;
                    if (int.Parse(dgvRentalShow.CurrentCell.Value.ToString()) == 4)
                    {
                        dgvRentalShow.CurrentCell.Value = 7;

                    }
                    if (int.Parse(dgvRentalShow.CurrentCell.Value.ToString()) == 8)
                    {
                        dgvRentalShow.CurrentCell.Value = 0;
                    }

                    string strSqlPriceSerch = "SELECT Price_Price FROM PriceT"
                    + " WHERE Price_NightCount =" + dgvRentalShow.CurrentCell.Value.ToString()
                    + " AND Price_LoanDivisionId = '" + dgvRentalShow[2, int.Parse(dgvRentalShow.CurrentCell.RowIndex.ToString())].Value.ToString()
                    + "';";

                    //顧客番号から顧客情報を検索するSQL文
                    cmd.CommandText = strSqlPriceSerch;

                    cn.Open();
                    OleDbDataReader rs = cmd.ExecuteReader();

                    //検索の結果金額があった場合
                    if (rs.Read() == true)
                    {
                        //値段を変更する
                        dgvRentalShow[6, int.Parse(dgvRentalShow.CurrentCell.RowIndex.ToString())].Value = rs.GetInt32(0);
                        //日付を変更する
                        dgvRentalShow[7, dgvRentalShow.CurrentCell.RowIndex].Value = (DT.AddDays(int.Parse(dgvRentalShow.CurrentCell.Value.ToString()))).ToShortDateString();
                    }
                    cn.Close();
                    NowRowMoney();

                }
                return true;
            }

            if ((int)keyData == (int)Keys.F11)
            {
                btnAllNigtCount.PerformClick();
                return true;
            }

            if ((int)keyData == (int)Keys.F12)
            {
                btnKeepMoney.PerformClick();
                return true;
            }

            if ((int)keyData == (int)Keys.Down)
            {
                if (fctTrueorFolse())
                {
                    DgvDown(dgvRentalShow);
                }
                else
                {
                    DgvDown(dgvReturnShow);
                }
                return true;

            }


            //↓
            if ((int)keyData == (int)Keys.Up)
            {
                if (fctTrueorFolse())
                {
                    DgvUp(dgvRentalShow);
                }
                else
                {
                    DgvUp(dgvReturnShow);
                }
                return true;

            }


            if ((int)keyData == (int)Keys.Tab)
            {
                //モード切り替え
                if (lblLone.BackColor == Color.Blue)
                {
                    //返却
                    lblLone.BackColor = Color.White;
                    lblReturn.BackColor = Color.Blue;
                    dgvReturnShow.Visible = true;
                    dgvRentalShow.Visible = false;
                    txtMemberId.Enabled = false;
                    txtStockId.Enabled = true;
                    txtStockId.Focus();
                    AllClear();
                }
                else
                {
                    //貸出
                    lblLone.BackColor = Color.Blue;
                    lblReturn.BackColor = Color.White;
                    dgvReturnShow.Visible = false;
                    dgvRentalShow.Visible = true;
                    txtMemberId.Enabled = true;
                    txtStockId.Enabled = false;
                    txtMemberId.Focus();
                    AllClear();
                }
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        //1行取り消しがクリック
        private void btnRowClear_Click(object sender, EventArgs e)
        {
            dgvRentalShow.Rows.RemoveAt(int.Parse(dgvRentalShow.CurrentCell.RowIndex.ToString()));
        }

        //一括泊数登録クリック
        private void btnNightChange_Click(object sender, EventArgs e)
        {

        }

        //●会員履歴へ移動（会員履歴をクリック）
        private void btnHistoryJump_Click(object sender, EventArgs e)
        {
            frmShowMemberHistory newForm = new frmShowMemberHistory(); ;
            newForm.lblMemberId.Text = txtMemberId.Text;
            newForm.Show();
        }

        //DGV貸出の行の場所が移動した時
        private void dgvRentalShow_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            MoneyCount();
        }

        //DGV貸出セルの内容が変わった場合
        private void dgvRentalShow_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MoneyCount();
        }

        private void dgvReturnShow_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MoneyCount();
        }

        private void dgvReturnShow_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            MoneyCount();
        }

        //時間が経過した時
        private void time_Tick(object sender, EventArgs e)
        {
            lblNowTime.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        //会員ごとの貸出中の計算を行う関数
        public void Lending()
        {
            txtLending.Text = clsDbj.GetTopRow("SELECT COUNT(*)"
                + " FROM LendingV"
                + " WHERE LendingV.Sale_MemberId = '" + txtMemberId.Text + "'"
                + " ;"
                );
            CalcArrearage();
        }

        //延滞中の計算を行う関数
        public void CalcArrearage()
        {
            txtArrearage.Text = clsDbj.GetTopRow("SELECT COUNT(*)"
                + " FROM LendingV"
                + " WHERE LendingV.Sale_MemberId = '" + txtMemberId.Text + "'"
                + " AND SaleList_ReturnDate < " + System.DateTime.Now.ToShortDateString() + ""
                + " ;"
                );
            if (txtArrearage.Text != "0")
            {
                fctComment("延滞商品が存在します");
            }
        }

        //お金を計算する関数
        private void MoneyCount()
        {
            //価格計算を行い表示させる
            int intSum = 0;
            int intDis = 0;

            //貸出の場合
            if (fctTrueorFolse())
            {
                //合計金額を算出する
                for (int i = 0; i < dgvRentalShow.Rows.Count; i++)
                {
                    intSum += int.Parse(dgvRentalShow[6, i].Value.ToString());
                    intDis += int.Parse(dgvRentalShow[5, i].Value.ToString());
                }
            }
            //返却の場合
            else
            {
                for (int i = 0; i < dgvReturnShow.Rows.Count; i++)
                {
                    intSum += int.Parse(dgvReturnShow[7, i].Value.ToString());
                }
            }
            txtTotalMoney.Text = Convert.ToString(intSum);
            lblTotalMoney.Text = intSum.ToString("C0");
            txtDiscount.Text = Convert.ToString(intDis);
            lblDiscount.Text = intDis.ToString("C0");
            int intTax = Convert.ToInt32(intSum * 0.05);
            txtTax.Text = Convert.ToString(intTax);
            lblTax.Text = intTax.ToString("C0");
            txtLend.Text = dgvRentalShow.Rows.Count.ToString();//貸出数

            //預かり金入力可不可の判断
            if (dgvRentalShow.RowCount == 0)
            {
                txtKeepMoney.Enabled = false;
                //1行取り消しと全行取り消しを使用不可にする。
                btnRowClear.Enabled = false;
                btnClearDgv.Enabled = false;
            }
            else
            {
                btnNightChange.Enabled = true;
            }



        }

        //会計のテキストボックスをクリアする関数
        public static void ClearTextBox(Control hParent)
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if (cControl.HasChildren == true)
                {
                    ClearTextBox(cControl);
                }

                // コントロールの型が TextBoxBase からの派生型の場合は Text をクリアする
                if (cControl is TextBoxBase)
                {
                    cControl.Text = string.Empty;
                }
            }
        }

        //行の金額と値引き額を計算する関数
        public void NowRowMoney()
        {
            //変数の宣言
            int intPrice = 0;

            //コマンドを入れるためのオブジェクト
            cmd.CommandText = "SELECT Discount_Price FROM DiscountT WHERE Discount_Name ='" + dgvRentalShow[4, dgvRentalShow.CurrentCell.RowIndex].Value.ToString() + "';";
            cn.Open();
            OleDbDataReader rs = cmd.ExecuteReader(); //データリーダー（読んできたデータを一時的に入れておくところ）にSqlコマンドを入れて実行する

            //商品番号検索の結果マッチングがある
            if (rs.Read() == true)
            {
                intPrice = rs.GetInt32(0);//
                cn.Close();
            }
            cn.Close();

            //価格を計算して値引き額に入れる
            dgvRentalShow[5, dgvRentalShow.CurrentCell.RowIndex].Value = int.Parse(dgvRentalShow[6, dgvRentalShow.CurrentCell.RowIndex].Value.ToString()) * intPrice / 100;
            //価格を計算して金額に入れる
            dgvRentalShow[6, dgvRentalShow.CurrentCell.RowIndex].Value = int.Parse(dgvRentalShow[6, dgvRentalShow.CurrentCell.RowIndex].Value.ToString()) - int.Parse(dgvRentalShow[5, dgvRentalShow.CurrentCell.RowIndex].Value.ToString());//金額を適正な値にする。

        }


        //●割引をクリック
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            frmDiscont newForm = new frmDiscont();
            newForm.ShowDialog();
            //フォームから区分と数値を引っ張る
            if (newForm.lblPrice.Text != "")
            {
                dgvRentalShow[4, dgvRentalShow.CurrentCell.RowIndex].Value = newForm.lblDisName.Text;//値引き区分
                dgvRentalShow[5, dgvRentalShow.CurrentCell.RowIndex].Value = int.Parse(newForm.lblPrice.Text);//値引き額 
            }
            NowRowMoney();
            txtStockId.Focus();
        }

        private void fctComment(string strComment)
        {
            if (strComment != "")
            {
                lblComment.Text = strComment;
                lblComment.BackColor = Color.Yellow;
            }
            else
            {
                lblComment.Text = "";
                lblComment.BackColor = Color.DodgerBlue;
            }
        }

        //●売上確認画面へ移動
        private void F7_Click(object sender, EventArgs e)
        {
            //frmSales newForm = new frmSales();
            //newForm.ShowDialog();
        }

        //●おすすめ商品画面へ移動
        private void F8_Click(object sender, EventArgs e)
        {
            frmMail newForm = new frmMail();
            newForm.ShowDialog();
        }



        /// <summary>
        ///返却か貸出か判断する関数 
        /// </summary>
        /// <returns></returns>
        private bool fctTrueorFolse()
        {
            if (lblLone.BackColor == Color.Blue)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //DGVをの関数
        private void DgvDown(DataGridView dgv)
        {
            if (dgv.Rows.Count != 0)
            {
                if (dgv.CurrentCell.RowIndex + 1 < dgv.Rows.Count)
                {
                    dgv.CurrentCell = dgv[dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex + 1];
                }
            }
        }

        //下に下げる
        private void DgvUp(DataGridView dgv)
        {
            if (dgv.Rows.Count != 0)
            {
                if (0 <= dgv.CurrentCell.RowIndex - 1)
                {
                    dgv.CurrentCell = dgv[dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex - 1];
                }
            }
        }

        //インサート関数
        private void SqlInsert(string strSqlInsert)
        {
            cn.Open();

            cmd.CommandText = strSqlInsert;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void gbxCondeition_Enter(object sender, EventArgs e)
        {

        }

        //コメントをリフレッシュ
        private void timComment_Tick(object sender, EventArgs e)
        {
        }


        //////////////////////////////////////
        //あんまり触るなエリアスタート
        //////////////////////////////////////

        //ラベル修正
        private void txtChange_TextChanged(object sender, EventArgs e)
        {

            int inttxtChange = 0;
            if (txtChange.Text == "")
            {
                txtChange.Text = "0";
            }
            inttxtChange = Convert.ToInt32(txtChange.Text);
            lblChange.Text = inttxtChange.ToString("C0");
        }





        //////////////////////////////////////
        //あんまり触るなエリアエンド
        //////////////////////////////////////


        private void fctMemberId()
        {
            //会員番号を元に会員情報を検索するSQL文
            string strSqlMemberIdSerch = "SELECT Member_FamilyNameKana, Member_FamilyName, Member_Birth, Member_Sex, Member_TimeLimit, Member_LastCome, Member_TotalCome,MemberT.Member_FirstNameKana, MemberT.Member_FirstName FROM MemberT where Member_MemberId = '" + txtMemberId.Text + "'; ";


            //顧客番号から顧客情報を検索するSQL文
            cmd.CommandText = strSqlMemberIdSerch;
            cn.Open();
            OleDbDataReader rs = cmd.ExecuteReader();
            //検索の結果顧客番号があった場合
            if (rs.Read() == true)
            {
                //誕生日の計算
                DateTime dt1 = System.DateTime.Now; //基準日
                DateTime dt2 = rs.GetDateTime(2); //誕生日
                long d1 = Convert.ToInt64(dt1.ToString("yyyyMMdd")); //基準日を数値に変換
                long d2 = Convert.ToInt64(dt2.ToString("yyyyMMdd")); //誕生日を数値に変換
                int age = (int)Math.Floor((double)((d1 - d2) / 10000));
                //検索の結果顧客番号があった場合は顧客情報を表示する
                lblMember_Kana.Text = rs.GetString(0) + " " + rs.GetString(7);
                lblMember_Name.Text = rs.GetString(1) + "　" + rs.GetString(8);
                lblMember_Birth.Text = rs.GetDateTime(2).ToShortDateString();
                lblAge.Text = age.ToString();
                lblMember_Sex.Text = rs.GetString(3);
                lblMember_Limit.Text = rs.GetDateTime(4).ToShortDateString();
                lblMember_LastCome.Text = rs.GetDateTime(5).ToShortDateString();
                lblMember_TotalCome.Text = rs.GetInt32(6).ToString();

                //表示・非表示
                txtMemberId.Enabled = false;    //メンバーIDが入力不可
                btnHistoryJump.Enabled = true;  //会員履歴が入力可
                if (lblLone.BackColor == Color.Blue)
                {
                    txtStockId.Enabled = true;
                    txtStockId.Focus();

                }
                fctComment("");
            }
            //
            else
            {
                cn.Close();
                fctComment("会員番号がありません");
                txtMemberId.Text = "";
            }
            cn.Close();
            Lending();
        }
    }



}



