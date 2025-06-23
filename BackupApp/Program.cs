using System;
using System.IO;
using FinanceApp.Managers;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using FinanceApp.Models;
using System.Threading;
using System.Runtime.CompilerServices;

namespace BackupApp
{
    internal class Program
    {
        private static float firstSum;
        private static float secondSum;

        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("No UserId provided.");
                    return -1;
                }

                int userId = int.Parse(args[0]);
                var _transactionManager = new TransactionManager(userId);
                var transactions = _transactionManager.GetAllTransactions().ToList();
                

                if (transactions == null || !transactions.Any())
                {
                    Console.WriteLine("There are no transactions.");
                    return -1;
                }

                firstSum = 0;
                secondSum = 0;

                CountdownEvent countdownEvent = new CountdownEvent(2);

                ThreadPool.QueueUserWorkItem(task => Thread1(transactions, countdownEvent));
                ThreadPool.QueueUserWorkItem(task => Thread2(transactions, countdownEvent));

                countdownEvent.Wait();

                float totalAverage = (firstSum + secondSum) / transactions.Count();

                var categoryAverages = transactions
                    .GroupBy(t => t.Category)
                    .ToDictionary(c => c.Key.Name, c => c.Average(t => t.Amount));

                foreach (var kvp in categoryAverages)
                {
                    Console.WriteLine($"{kvp.Key}:{kvp.Value}");
                }

                string resultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../FinanceApp/Data/averages.txt");

                using (StreamWriter writer = new StreamWriter(resultFile))
                {
                    writer.WriteLine($"Average of all transactions:\r\n{totalAverage}\r\n");
                    writer.WriteLine($"Average of transactions by category:");
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

        private static void Thread1(List<Transaction> transactions, CountdownEvent countdownEvent)
        {
            int halfTransactions = transactions.Count / 2;

            for(int i = 0; i < halfTransactions; i++) 
            {
                firstSum += transactions[i].Amount;
            }

            countdownEvent.Signal();
        }

        private static void Thread2(List<Transaction> transactions, CountdownEvent countdownEvent)
        {
            int halfTransactions = transactions.Count / 2;

            for(int i = halfTransactions; i < transactions.Count; i++)
            {
                secondSum += transactions[i].Amount;
            }

            countdownEvent.Signal();
        }
    }
}
