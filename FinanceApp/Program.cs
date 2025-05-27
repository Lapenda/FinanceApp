using FinanceApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using FinanceApp.Manager;
using System.Drawing.Text;
using FinanceApp.Managers;

namespace FinanceApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SettingsManager.LoadLanguageFromIni();

            string connectionString = Environment.GetEnvironmentVariable("FINANCEAPP_CONNECTION_STRING");
            string jwtSecretKey = Environment.GetEnvironmentVariable("FINANCEAPP_JWT_SECRET");

            if(string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(jwtSecretKey))
            {
                MessageBox.Show("Environment variables not found");
                return;
            }

            var userManager = new UserManager(connectionString, jwtSecretKey);
            string storedToken = Properties.Settings.Default.JwtToken;

            if(!string.IsNullOrEmpty(storedToken) && userManager.ValidateToken(storedToken, out var claimsPrincipal))
            {
                Application.Run(new TransactionForm());
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }
    }
}
