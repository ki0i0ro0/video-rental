using System;
using System.Data;
using System.Data.OleDb;

namespace rental
{
    internal class clsDbJoin
    {
        private readonly OleDbConnection m_con = new OleDbConnection("server=127.0.0.1;User Id=Kensaku;password=1234;database=rental;Persist Security Info=True;Character Set=utf8;Allow Zero Datetime=True");

        public class clRecommendData
        {
            public string strProductId;//商品ID
            public string strProductName;//商品名
            public string strDetail;//商品詳細
        }

        /// <summary>
        /// レコメンドに対する操作を全て行い、String型[2,4]としてレコメンドを返します
        /// </summary>
        /// <param name="strProduct"></param>
        /// <param name="strMemberId"></param>
        /// <returns></returns>
        public clRecommendData GetRecommendation(string strProduct, string strMemberId)
        {
            clRecommendData clData = new clRecommendData();

            //強調フィルタリング
            //今借りた商品と同じジャンルの商品を抽出する。今まで借りたことのある商品とおすすめの履歴は排除
            DataTable dtlRecom = Fill("SELECT Recom_Recom, Recom_RecomName, Recom_Genre, Recom_Count"
                + " FROM RecomV AS R"
                + " WHERE R.Recom_Basis='" + strProduct + "'"
                + " AND Recom_Recom NOT IN"
                + " (SELECT History_ProductId FROM HistoryV "
                + " WHERE History_MemberId = '" + strMemberId + "'"
                + " );");

            //予備レコメンド
            if (dtlRecom.Rows.Count == 0)
            {
                string strGenre = GetTopRow("SELECT ProductT.Product_Genre, ProductT.Product_ProductId"
                + " FROM ProductT"
                + " WHERE ProductT.Product_ProductId = '" + strProduct + "';");

                dtlRecom = Fill("SELECT ProductT.Product_ProductId, ProductT.Product_ProductName, ProductT.Product_Genre, ProductT.Product_Series, ProductT.Product_Director, ProductT.Product_ReleaseYear, ProductT.Product_Actor, ProductT.Product_FilmDiv, ProductT.Product_Scenario, ProductT.Product_Award"
                    + " FROM ProductT"
                    + " WHERE NOT EXISTS (SELECT * FROM HistoryV WHERE History_MemberId = '" + strMemberId + "' AND History_ProductId = ProductT.Product_ProductId)"
                    + " AND ProductT.Product_Genre = '" + strGenre + "'"
                    + " ORDER BY ProductT.Product_ReleaseYear DESC;");
            }

            //おすすめをstrRecomにセットした時
            //行数が２以下又はdtにデータが帰って来なかった場合

            DataRow dr = dtlRecom.Rows[0];
            clData.strProductId = dr[0].ToString();//商品ID
            clData.strProductName = dr[1].ToString();//商品名
            //商品ジャンル等
            for (int i = 2; i < dtlRecom.Columns.Count; i++)
            {
                if (dr[i].ToString() != "")
                {
                    clData.strDetail += "●" + dr[i].ToString() + "\n";
                }
            }

            //履歴を登録
            string strRecomNumber = GetTopRow("SELECT MAX(Recommendation_Number) FROM RecommendationT;");
            int intRecomNumber = (int.Parse(strRecomNumber) + 1);
            ExecuteNonQuery("INSERT INTO RecommendationT (Recommendation_Number, Recommendation_ProductName, Recommendation_MemberId, Recommendation_ProductId, Recommendation_Date,Recommendation_OriginProductId)"
                + " VALUES('" + intRecomNumber.ToString()  //おすすめ番号
                + "','" + clData.strProductName//おすすめした商品の名前
                + "','" + strMemberId//会員名
                + "','" + clData.strProductId//商品ID
                + "','"
                + DateTime.Now.ToShortDateString() + "',"
                + "'" + strProduct + "');");

            return (clData);
        }

        /// <summary>
        /// Fillを使って表をデータテーブル型として取得する
        /// </summary>
        /// <returns>データテーブル型</returns>
        public DataTable Fill(string strSQL)
        {
            using (DataTable dt = new DataTable())
            {
                using (OleDbDataAdapter od = new OleDbDataAdapter(strSQL, m_con))
                {
                    od.Fill(dt);
                    return (dt);
                }
            }
        }

        /// <summary>
        /// 1行分のデータをobject型で取得
        /// </summary>
        /// <returns>object型</returns>
        public object[] FillOneRow(string strSQL)
        {
            using (OleDbDataAdapter od = new OleDbDataAdapter(strSQL, m_con))
            using (DataTable dt = new DataTable())
            {
                od.Fill(dt);
                object[] obj = new object[dt.Columns.Count];
                //列数分
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        obj[i] = dt.Rows[0][i].ToString();
                    }
                }
                else
                {
                    obj[0] = "0";
                }

                return (obj);
            }
        }

        /// <summary>
        /// テーブルの一番左上のデータをストリング型で取得
        /// </summary>
        /// <returns></returns>
        public string GetTopRow(string strSQL)
        {
            using (OleDbDataAdapter od = new OleDbDataAdapter(strSQL, m_con))
            using (DataTable dt = new DataTable())
            {
                od.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return "";
                }

                if (dt.Rows[0][0].ToString() == "")
                {
                    return "0";
                }

                return (dt.Rows[0][0].ToString());
            }

        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="strSql"></param>
        public void ExecuteNonQuery(string strSql)
        {
            using (OleDbCommand cmd = new OleDbCommand(strSql, m_con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// SQLを発行してデータをString型で取得
        /// </summary>
        /// <returns>データテーブル型</returns>
        public string GetFillString(string strSQL)
        {
            using (OleDbDataAdapter od = new OleDbDataAdapter(strSQL, m_con))
            using (DataTable dt = new DataTable())
            {
                od.Fill(dt);

                if (dt.Rows.Count < 1)
                {
                    return "";
                }
                
                string str = "";

                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        str += dt.Rows[i][j].ToString() + "\n";
                    }
                }
                return (str);
            }            
        }

        ////チャートを更新する関数
        //private void Chart(System.Windows.Forms.DataVisualization.Charting.Chart chr, string strTitle, DataGridView dgv)
        //{
        //    //ジャンル毎の円グラフ
        //    //グラフを更新
        //    chr.Series.Clear();  //グラフ初期化
        //    chr.Series.Add(strTitle);  //グラフ追加
        //    //グラフの種類を指定（Columnは棒グラフ）
        //    chr.Series[strTitle].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        //    for (int i = 0; i < dgv.Rows.Count; i++)
        //    {
        //        //グラフに追加するデータクラスを生成
        //        System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
        //        dp.SetValueXY(dgv[0, i].Value.ToString(), Convert.ToInt32(dgv[1, i].Value.ToString()));  //XとYの値を設定
        //        dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
        //        chr.Series[strTitle].Points.Add(dp);   //グラフにデータ追加
        //        chr.Series[strTitle].Points[0]["PieLabelStyle"] = "Outside";
        //    }
        //}
    }
}
