using System;
using System.Data;
using System.Windows.Forms;


namespace rental
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }

        private const int COL_CNT = 2;
        private string[] m_strButtonSql = new string[10];
        private string m_strSQL = "";
        private string[] m_strComment = new string[10];
        private clsDbJoin m_clsDbj = new clsDbJoin();
        private clsOperation m_clsOpe = new clsOperation();

        private void frmRecommendation_Load(object sender, EventArgs e)
        {
            m_clsOpe.AddDeleteButton(ref dgvSendList);
            ShortCutButton();
            //年代
            m_clsOpe.SearchSelect(lbxAge, "SELECT DISTINCT age FROM MemberV ORDER BY age;");
            //ジャンル
            m_clsOpe.SearchSelect(lbxGenre, "SELECT DISTINCT Product_Genre FROM ProductT;");
            //来店頻度
            m_clsOpe.SearchSelect(cmbComeCount, "SELECT DISTINCT ComeCountName FROM Mail_ComeCountT;");
            //最終来店日
            m_clsOpe.SearchSelect(cmbYear, "SELECT LastComeName FROM Mail_LastComeT;");
        }


        /// <summary>
        /// ボタンからマウスが離れたら説明が消える
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecommendation_MouseLeave(object sender, EventArgs e)
        {
            lblComment.Text = "";
        }

        /// <summary>
        /// 年齢全て選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgeOn_Click(object sender, EventArgs e)
        {
            m_clsOpe.SelectAllRows(lbxAge);
        }

        /// <summary>
        /// 年齢全て解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgeOff_Click(object sender, EventArgs e)
        {
            m_clsOpe.UnSelectAllRows(lbxAge);
        }

        /// <summary>
        /// ジャンル全て選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenreOn_Click(object sender, EventArgs e)
        {
            m_clsOpe.SelectAllRows(lbxGenre);
        }
        /// <summary>
        /// ジャンル全て解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenreOff_Click(object sender, EventArgs e)
        {
            m_clsOpe.UnSelectAllRows(lbxGenre);
        }

        /// <summary>
        /// 検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerch_Click(object sender, EventArgs e)
        {

            m_strSQL = "SELECT * FROM MemberV"
                         + " WHERE Member_MemberId IS NOT NULL";
            //年代から値を取得
            bool bolAgeflg = true;
            foreach (object obj in lbxAge.SelectedItems)
            {
                //フラグが
                if (bolAgeflg)
                {
                    m_strSQL += " AND age =" + obj;
                    bolAgeflg = false;
                }
                else
                {
                    m_strSQL += " OR age =" + obj;
                }

            }
            m_strSQL += ";";
            dgvMemberList.DataSource = m_clsDbj.Fill(m_strSQL);

            //最終来店日
            if (cmbYear.Text != "指定なし")
            {
                //来店数を取得
                string strTotalCome = m_clsDbj.GetFillString("SELECT ComeCount_TotalCome FROM ComeCount_Name = " + cmbYear.Text + ";");
            }

            //来店頻度
            //cn.Open();
            //cmd.CommandText = "SELECT ComeCountT.ComeCount_TotalCome FROM ComeCountT WHERE ComeCount_Name ='" + cbxComeCount.Text + "' ;";
            //rs = cmd.ExecuteReader();
            //if (rs.Read() == true)
            //{
            //    strAge += "AND Member_TotalCome " + "> " + rs.GetInt32(0).ToString() + " ";
            //}
            //cn.Close();

            ////ジャンル
            //foreach (object obj in lbxGenre.SelectedItems)
            //{
            //    if (flg == 0)
            //    {
            //        strAge += "AND ";
            //        flg = 1;
            //    }
            //    else
            //    {
            //        strAge += "OR BETWEEN " + System.DateTime.Now.AddYears(-rs.GetInt32(0)).ToShortDateString() + " AND " + System.DateTime.Now.AddYears(-rs.GetInt32(1)).ToShortDateString() + " ";
            //    }
            //}
            //flg = 0;

            //dgvShowRecom.DataSource = clsDbj.fctFilldgv("SELECT *"
            //    + " FROM MemberT "
            //    + strAge + ";");
            //dgvShowRecom.Refresh();

            //strCom = "SELECT *"
            //    + " FROM MemberT "
            //    + strAge + ";";



        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            GoSql(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoSql(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GoSql(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GoSql(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GoSql(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GoSql(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GoSql(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GoSql(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GoSql(8);
        }

        /// <summary>
        /// ショートカットの変数
        /// </summary>
        /// <param name="i"></param>
        public void GoSql(int i)
        {
            dgvMemberList.DataSource = m_clsDbj.Fill(m_strButtonSql[i]);

            tabControl1.SelectedTab = tabMemberList;
        }

        /// <summary>
        /// ボタンにマウスが乗った時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[0];
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[1];
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[2];
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[3];
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[4];
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[5];
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[6];
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[7];
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = m_strComment[8];
        }

        /// <summary>
        /// メール作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMail_Click(object sender, EventArgs e)
        {            
            tabControl1.SelectedTab = tabMailMake;//タブを切り替える
        }

        /// <summary>
        /// メール送信
        /// </summary>
        /// <param name="strText"></param>
        public void SendMail(string strText)
        {
            var mail = new clsOperation();

            //GMail
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new System.Net.NetworkCredential("mail", ""),
                EnableSsl = true
            };

            var oMsg = new System.Net.Mail.MailMessage("mail", "mail", txtSubject.Text, txtText.Text + "\n\n" + strText + "\n http://192.168.11.2:8080/VideoRental/rogin.html");

            try
            {
                smtp.Send(oMsg);


                MessageBox.Show("送信完了");
            }
            catch
            {
                MessageBox.Show("回線が不安定です");
            }
        }

        /// <summary>
        /// 登録をクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntry_Click(object sender, EventArgs e)
        {

            DataTable dtlShortCut = m_clsDbj.Fill("SELECT * FROM Mail_ShortCutT;");
            frmEntly newForm = new frmEntly();
            newForm.lblstrCom.Text = m_strSQL;
            newForm.ShowDialog();
            ShortCutButton();
        }

        /// <summary>
        /// ショートカットの割り当てを行う
        /// </summary>
        public void ShortCutButton()
        {
            DataTable dtlShortCut = m_clsDbj.Fill("SELECT ShortCut_Id,ShortCut_Sql,ShortCut_Name,ShortCut_Comment FROM Mail_ShortCutT;");
            for (int i = 0; i < dtlShortCut.Rows.Count; i++)
            {
                //ボタンコントロールを検索して名前をつける
                Control[] cs = Controls.Find("button" + (i + 1).ToString(), true);
                if (cs.Length > 0)
                {
                    ((Button)cs[0]).Text = dtlShortCut.Rows[i][2].ToString();
                    if (dtlShortCut.Rows[i][1].ToString() == "")
                    {
                        ((Button)cs[0]).Visible = false;
                    }
                    else
                    {
                        ((Button)cs[0]).Visible = true;
                    }
                }
                m_strButtonSql[i] = dtlShortCut.Rows[i][1].ToString();
                m_strComment[i] = dtlShortCut.Rows[i][3].ToString();
            }

        }

        /// <summary>
        /// メール送信をクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMail_Click_1(object sender, EventArgs e)
        {
            string strRecom = "";
            //会員番号がDGVにある場合
            if (dgvSendList.Rows.Count < 1) return;

            for (int i = 0; i < dgvSendList.Rows.Count; i++)
            {
                //おすすめ情報にチェックが付いている。
                if (chkRecommendation.Checked == true)
                {
                    string strMeilMemberId = dgvMemberList[0, i].Value.ToString();
                }
                //メール送信
                SendMail(strRecom);
            }
        }

        /// <summary>
        /// 時間を更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_Tick(object sender, EventArgs e)
        {
            lblNowTime.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        /// 顧客件数を計算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShowRecom_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            lblMemberCount.Text = "会員件数 " + dgvMemberList.RowCount.ToString() + " 人";
        }

        private void cbxComeCount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 全件選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemberAllSelect_Click(object sender, EventArgs e)
        {
            m_clsOpe.SelectAllRows(dgvMemberList);
        }

        /// <summary>
        /// 全件キャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemberAllNoSelect_Click(object sender, EventArgs e)
        {
            m_clsOpe.UnSelectAllRows(dgvMemberList);
        }

        /// <summary>
        /// 送信リストに追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendListAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMemberList.Rows.Count; i++)
            {
                object[] objProduct = new object[COL_CNT];
                if (dgvMemberList.Rows[i].Selected == true)
                {
                    for (int j = 0; j < COL_CNT; j++)
                    {
                        objProduct[j] = dgvMemberList[j, i].Value.ToString();
                    }
                    dgvSendList.Rows.Add(objProduct);
                }
            }
        }

        private void dgvSendList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "編集")
            {
                dgv.Rows.RemoveAt(int.Parse(e.RowIndex.ToString()));
            }
        }

    }




}
