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
    public partial class frmVideoReturn : Form
    {
        public frmVideoReturn()
        {
            InitializeComponent();
        }

        //■宣言エリア
        //オブジェクトの宣言
        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();//コマンドを入れておくオブジェクト

        //●商品情報が入力された時
        private void txtStockId_TextChanged(object sender, EventArgs e)
        {
            TimeSpan datSubmitDate = new TimeSpan();

            //変数の宣言
            //コネクションとコマンド変数
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            //商品番号から商品情報を検索するSQL文
            cmd.CommandText = "SELECT StockT.Stock_StockId, ProductT.Product_ProductName, SaleT.Sale_StaffId, SaleT.Sale_SaleDate, SaleListT.SaleList_NightCount, SaleT.Sale_MemberId,SaleList_LoanDivision FROM (ProductT INNER JOIN StockT ON ProductT.Product_ProductId = StockT.Stock_ProductId) INNER JOIN ((MemberT INNER JOIN SaleT ON MemberT.Member_MemberId = SaleT.Sale_MemberId) INNER JOIN SaleListT ON SaleT.Sale_SaleNumber = SaleListT.SaleList_SaleNumber) ON StockT.Stock_StockId = SaleListT.SaleList_StockId WHERE StockT.Stock_LoanCheck = '0'  AND SaleListT.SaleList_StockId = '" + txtStockId.Text + "' AND SaleT.Sale_LoanDivisionId = '貸出' AND SaleT.Sale_SaleNumber IN (SELECT MAX(SaleListT.SaleList_SaleNumber) FROM StockT ,SaleT,  SaleListT WHERE Sale_SaleNumber = SaleListT.SaleList_SaleNumber AND StockT.Stock_StockId = SaleListT.SaleList_StockId AND SaleListT.SaleList_StockId = '" + txtStockId.Text + "' );";

            //コネクションを開く
            cn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd.CommandText, cn);
            //rsにレコードを入れた
            OleDbDataReader rs = cmd.ExecuteReader();
            if (rs.Read() == true)
            {
                ////////////////////////////////////////
                //泊数を計算して変数に入れる
                datSubmitDate = Convert.ToDateTime(lblNowTime.Text) - rs.GetDateTime(3).AddDays(rs.GetInt32(4)); //今の時間引く貸出日
                //データグリッドビューへ行返却する商品の行を追加する
                dgvReturnShow.AllowUserToAddRows = false;
                dgvReturnShow.Rows.Add(
                    rs.GetString(0),
                    rs.GetString(1),
                    rs.GetString(2),
                    rs.GetDateTime(3).ToShortDateString(),//貸出日の日付
                    rs.GetString(6),
                    rs.GetInt32(4),             //泊数
                    (datSubmitDate.Days).ToString(),  //延滞日数
                    int.Parse((datSubmitDate.Days).ToString()) * 300,                        //延滞金額
                    System.DateTime.Now.ToShortDateString()
                    );
                txtMemberId.Text = rs.GetString(5); //会員情報をメンバーIDに入力
                //商品番号をリセットする
                txtStockId.Text = "";

            }
            cn.Close();

        }

        //●フォームをロードした
        private void frmRental_Return_Load(object sender, EventArgs e)
        {
            //データベースへのアクセスコード指定
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Kensaku\\Dropbox\\rental.accdb";

            //コネクションコマンドをセット
            cmd.Connection = cn;
        }

        //●返却ボタン
        private void btnReturnDetermine_Click(object sender, EventArgs e)
        {
            //お釣りを計算して表示
            if (txtKeepMoney.Text != "")
            {
                txtChange.Text = (int.Parse(txtKeepMoney.Text) - int.Parse(txtTotalMoney.Text)).ToString();

                if (txtChange.Text != "")
                {
                    //DB接続

                    OleDbCommand cmd = new OleDbCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    //伝票番号の一番大きな値を検索する
                    cmd.CommandText = "SELECT MAX(Sale_SaleNumber) AS Sale_SaleNumber FROM SaleT;";
                    OleDbDataReader rs;
                    rs = cmd.ExecuteReader();
                    rs.Read();
                    string strSaleNumber = Convert.ToString(rs.GetInt32(0) + 1);
                    cn.Close();


                    //売上を更新
                    cn.Open();
                    string strGoods_Code = dgvReturnShow[1, 0].Value.ToString();
                    string strSqlSaleIn = "INSERT INTO SaleT(Sale_SaleNumber,Sale_LoanDivisionId,Sale_KeepMoney,Sale_ChangeMoney,Sale_TotalManey,Sale_MemberId,Sale_SaleDate,Sale_StaffId) VALUES("
                        + strSaleNumber + ",'"       //売上番号
                        + "返却" + "'," 　          //貸出区分
                        + txtKeepMoney.Text + ","    //お預かり金
                        + txtChange.Text + ","       //お釣り
                        + txtTotalMoney.Text + ",'"  //合計金額
                        + txtMemberId.Text + "','"   //会員番号
                        + DateTime.Parse(lblNowTime.Text) + "','"    //今日の日付
                        + lblStaffName.Text         //延滞処理を行った人
                        +"');";
                    cmd.CommandText = strSqlSaleIn;
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    //売上明細を更新
                    cn.Open();
                    //DGVの行分繰り返す
                    for (int i = 0; i < dgvReturnShow.Rows.Count; i++)
                    {
                        string strSqlSaleListIn = "INSERT INTO SaleListT(SaleList_SaleNumber,SaleList_StockId,SaleList_Money,SaleList_NightCount) VALUES('"
                            + strSaleNumber + "','"                         //売上番号
                            + dgvReturnShow[0, i].Value.ToString() + "',"   //在庫番号
                            + int.Parse(dgvReturnShow[7, i].Value.ToString()) + ","                       //単価
                            + int.Parse(dgvReturnShow[6, i].Value.ToString())     //泊数
                            +");";
                        cmd.CommandText = strSqlSaleListIn;
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();

                    //////////////////////////////////////
                    //貸出区分を返却にする
                    cn.Open();
                    for (int i = 0; i < dgvReturnShow.Rows.Count; i++)
                    {
                        string strSqlUpdate = "UPDATE StockT SET Stock_LoanCheck = 1 WHERE Stock_StockId = '"
                            + dgvReturnShow[0, i].Value.ToString()
                            + "';";
                        cmd.CommandText = strSqlUpdate;
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                    //////////////////////////////////////

                    //オールクリア
                    btnAllClear_Click(sender, e);
                }
            }
        }

        //●会員情報が入力された
        private void txtMemberId_TextChanged(object sender, EventArgs e)
        {
            cn.Close();
            //会員番号を元に会員情報を検索するSQL文
            //接続
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;

            //顧客番号から顧客情報を検索するSQL文
            cmd.CommandText = "SELECT Member_FamilyNameKana, Member_FamilyName, Member_Birth, Member_Sex, Member_TimeLimit, Member_LastCome, Member_TotalCome ,MemberT.Member_FirstNameKana, MemberT.Member_FirstName FROM MemberT where Member_MemberId = '" + txtMemberId.Text + "' ;  ";
            OleDbDataReader rs;
            cn.Open();
            rs = cmd.ExecuteReader();

            //検索の結果顧客番号あった場合
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
            }
            cn.Close();
        }

        //●右上の時計を更新する
        private void time_Tick(object sender, EventArgs e)
        {
            lblNowTime.Text = System.DateTime.Now.ToString("yyyy年MM月dd日hh時mm分");
            //} 
        }

        //●オールクリアがクリック
        private void btnAllClear_Click(object sender, EventArgs e)
        {
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
            txtLending.Text = "0";
            txtArrearage.Text = "0";
            ClearTextBox(gbxMoney);
            dgvReturnShow.Rows.Clear();
            txtMemberId.Focus();
            
        }
        //★会計のテキストボックスをクリアする関数
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

        private void dgvRentalShow_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //価格計算を行い表示させる
            int sum = 0;

            for (int i = 0; i < dgvReturnShow.Rows.Count; i++)
            {
                sum += int.Parse(dgvReturnShow[7, i].Value.ToString());
            }
            txtTotalMoney.Text = Convert.ToString(sum);
            double dblSum = sum * 0.05;
            txtTax.Text = Convert.ToString(Convert.ToInt32(dblSum));
        }

        private void btnRental_Video_Jump_Click_1(object sender, EventArgs e)
        {
            //レンタルビデオ画面へ移動
            this.Close();
        }
    }
}
