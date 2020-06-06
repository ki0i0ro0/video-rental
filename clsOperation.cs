using System;
using System.Data;
using System.Windows.Forms;

namespace rental
{
    internal class clsOperation
    {
        private clsDbJoin m_clsDbj = new clsDbJoin();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public bool ShowMessageBox(string strMessage)
        {
            DialogResult result = MessageBox.Show(strMessage,
                "質問",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button2);

            switch (result)
            {
                case DialogResult.OK:
                    Console.WriteLine("「はい」が選択されました");
                    return true;
                case DialogResult.Cancel:
                    Console.WriteLine("「キャンセル」が選択されました");
                    break;
                default:
                    break;
            }

            return false;
        }

        /// <summary>
        /// リストボックスにショートカットの割り当てを行う関数
        /// </summary>
        /// <param name="lbx"></param>
        /// <param name="Sql"></param>
        public void SearchSelect(ListBox lbx, string Sql)
        {
            using (DataTable dt = m_clsDbj.Fill(Sql))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lbx.Items.Add(dt.Rows[i][0]);
                }
            }
        }

        /// <summary>
        /// コンボボックスにショートカットの割り当てを行う関数
        /// </summary>
        /// <param name="cbx"></param>
        /// <param name="strSql"></param>
        public void SearchSelect(ComboBox cbx, string strSql)
        {
            using (var dt = m_clsDbj.Fill(strSql))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbx.Items.Add(dt.Rows[i][0]);
                }
            }
        }

        /// <summary>
        /// DGV全件選択
        /// </summary>
        /// <param name="dgv"></param>
        public void SelectAllRows(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Selected = true;
            }
        }

        /// <summary>
        /// DGV全件選択解除
        /// </summary>
        /// <param name="dgv"></param>
        public void UnSelectAllRows(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Selected = false;
            }
        }

        /// <summary>
        /// リストボックス全件選択
        /// </summary>
        /// <param name="dgv"></param>
        public void SelectAllRows(ListBox lbx)
        {
            for (int i = 0; i < lbx.Items.Count; i++)
            {
                lbx.SelectedIndex = i;
            }
        }

        /// <summary>
        /// リストボックス全件選択解除
        /// </summary>
        /// <param name="dgv"></param>
        public void UnSelectAllRows(ListBox lbx)
        {
            lbx.SelectedIndex = -1;
        }

        /// <summary>
        /// 削除・編集ボタン追加
        /// </summary>
        /// <param name="dgv"></param>
        public void AddDeleteButton(ref DataGridView dgv)
        {
            var column = new DataGridViewButtonColumn
            {
                //列の名前を設定
                Name = "編集",
                //全てのボタンに"詳細閲覧"と表示する
                UseColumnTextForButtonValue = true,
                Text = "削除"
            };
            dgv.Columns.Add(column);
        }
    }
}
