using System;
using System.IO;
using FinanceApp.Managers;
using System.Linq;
using System.Windows.Forms;

namespace BackupApp
{
    internal class Program
    {

        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("No UserId provided.");
                    //return -1;
                }

                //int userId = int.Parse(args[0]);
                int userId = 4;
                var _transactionManager = new TransactionManager(userId);
                var transactions = _transactionManager.GetAllTransactions().ToList();


                if (transactions == null || !transactions.Any())
                {
                    Console.WriteLine("There are no transactions.");
                    return -1;
                }

                float totalAverage = transactions.Average(t => t.Amount);

                var categoryAverages = transactions
                    .GroupBy(t => t.Category)
                    .ToDictionary(g => g.Key.Name, g => g.Average(t => t.Amount));

                foreach (var kvp in categoryAverages)
                {
                    Console.WriteLine($"{kvp.Key}:{kvp.Value}");
                }

                string resultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../FinanceApp/Data/averages.txt");

                using (StreamWriter writer = new StreamWriter(resultFile))
                {
                    writer.WriteLine($"Average of all transactions:\r\n{totalAverage}\r\n");
                    writer.WriteLine("Average of transactions by category:");
                    foreach (var kvp in categoryAverages)
                    {
                        writer.WriteLine($"{kvp.Key}:{kvp.Value}");
                    }
                    Console.WriteLine($"Transactions saved to: {resultFile}");
                }

                return 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}
