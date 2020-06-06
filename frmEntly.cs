using System;
using System.Data;
using System.Windows.Forms;

namespace rental
{
    public partial class frmEntly : Form
    {
        public frmEntly()
        {
            InitializeComponent();
        }

        private DataTable m_dtlShortCut = new DataTable();
        private clsDbJoin m_clsDbj = new clsDbJoin();

        private void btnCancell_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEntly_Load(object sender, EventArgs e)
        {
            m_dtlShortCut = m_clsDbj.Fill("SELECT * FROM Mail_ShortCutT;");
            //ショートカットテーブルの行数分繰り返す
            for (int i = 0; i < m_dtlShortCut.Rows.Count; i++)
            {
                if (m_dtlShortCut.Rows[i][1].ToString() == "")
                {
                    cmbWariatekasyo.Items.Add(m_dtlShortCut.Rows[i][0].ToString());
                }
            }
        }

        /// <summary>
        /// 全件表示をクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZenkenhyouji_Click(object sender, EventArgs e)
        {
            DataTable dtlShortCut = m_clsDbj.Fill("SELECT * FROM Mail_ShortCutT;");
            cmbWariatekasyo.Items.Clear();
            for (int i = 0; i < dtlShortCut.Rows.Count; i++)
            {
                cmbWariatekasyo.Items.Add(dtlShortCut.Rows[i][0].ToString());
            }
        }

        /// <summary>
        /// コンボボックスのテキストが変わった時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbWariatekasyo_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < m_dtlShortCut.Rows.Count; i++)
            {
                if (cmbWariatekasyo.Text == m_dtlShortCut.Rows[i][0].ToString())
                {
                    lblWariateComment.Text = m_dtlShortCut.Rows[i][3].ToString();
                }
            }

        }

        private void btnEntlyOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_clsDbj.ExecuteNonQuery("UPDATE Mail_ShortCutT SET ShortCut_Sql = '"
                    + lblstrCom.Text + "', ShortCut_Name = '"
                    + txtButtonName.Text + "', ShortCut_Comment = '"
                    + txtComment.Text
                    + "' WHERE ShortCut_Id ='" + cmbWariatekasyo.Text + "';");
                MessageBox.Show("登録されました");
            }
            catch
            {
                MessageBox.Show("失敗しました");
            }
            Close();
        }
    }
}
