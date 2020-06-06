using System;
using System.Windows.Forms;

namespace rental
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmVideoRental());
            //Application.Run(new frmProgressBar());
            //Application.Run(new frmSales());
            //Application.Run(new frmRecommendation());

        }
    }
}
