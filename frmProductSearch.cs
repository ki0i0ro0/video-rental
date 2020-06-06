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
    public partial class frmProductSearch : Form
    {
        public frmProductSearch()
        {
            InitializeComponent();
        }
        //■宣言エリア
        //オブジェクトの宣言
        OleDbConnection cn = new OleDbConnection();//DBコネクション用オブジェクト
        OleDbCommand cmd = new OleDbCommand();//コマンドを入れておくオブジェクト

        private void button1_Click(object sender, EventArgs e)
        {
            //マイクロソフトアクセスのアクセスコードをコネクションに読み込む
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Kensaku\\Dropbox\\rental.accdb";
            //コネクションコマンドをセット
            cmd.Connection = cn;

            DataTable dtlGenre = new DataTable();
            OleDbDataAdapter odaGenre = new OleDbDataAdapter("SELECT * FROM ProductT INNER JOIN StockT ON (ProductT.Product_ProductId = StockT.Stock_ProductId) AND (ProductT.Product_ProductId = StockT.Stock_ProductId) WHERE StockT.Stock_StockId = '"+textBox1.Text+"'", cn);
            odaGenre.Fill(dtlGenre);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Add(dtlGenre.Rows[0][0])
                ;
            textBox1.Text = "";
            textBox1.Focus();
        }
    }
}
