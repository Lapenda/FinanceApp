using FinanceApp.Encryption;
using FinanceApp.Manager;
using FinanceApp.Managers;
using FinanceApp.Models;
using iText.Commons.Utils;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.StyledXmlParser.Node;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading;
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly FinancialGoalManager financialGoalManager;
        private readonly TransactionManager transactionManager;
        private readonly object calculationLock = new object();
        private readonly object numberOfTransLock = new object();
        private readonly object tasksLock = new object();
        private readonly Mutex reportMutex = new Mutex(false, "FinanceAppSummaryReportMutex");
        private Dictionary<string, float> expensesByCategory;
        private List<string> goalProgressSummaries;
        private int tasksCompleted = 0;
        private readonly int totalTasks = 9;
        private CountdownEvent calculationCountdown;
        string report;
        List<Transaction> transactions;

        int numberOfSmallTrans;
        int numberOfLargeTrans;
        int numberOfMediumTrans;

        public DashboardForm()
        {
            InitializeComponent();
            transactionManager = new TransactionManager();
            financialGoalManager = new FinancialGoalManager();
            expensesByCategory = new Dictionary<string, float>();
            goalProgressSummaries = new List<string>();
            progressBar.Maximum = totalTasks;
            calculationCountdown = new CountdownEvent(totalTasks - 1);

            SettingsManager.ApplyTheme(this);
        }

        private void startAnalysisBtn_Click(object sender, EventArgs e)
        {
            report = null;

            report = $"{Properties.Resources.ReportSum} {SessionManager.currentUsername}\r\n";
            report += $"{Properties.Resources.Generated} {DateTime.Now.ToString("g")}\r\n";

            numberOfLargeTrans = 0;
            numberOfMediumTrans = 0;
            numberOfSmallTrans = 0;

            expensesByCategory.Clear();
            goalProgressSummaries.Clear();
            tasksCompleted = 0;
            progressBar.Value = 0;
            expensesLabel.Text = Properties.Resources.CalcExpenses;
            goalsProgressLabel.Text = Properties.Resources.CalcGoal;
            summaryTextBox.Text = Properties.Resources.GenSummary;
            startAnalysisBtn.Enabled = false;

            calculationCountdown.Reset(totalTasks - 1);

            ThreadPool.QueueUserWorkItem(task => CalculateExpensesByCategory());
            ThreadPool.QueueUserWorkItem(task => CalculateGoalProgress());

            ThreadPool.QueueUserWorkItem(task =>
            {
                calculationCountdown.Wait();
                GenerateSummaryReport();
            });
        }

        private void Calculate(int beginning, int count, CountdownEvent threadCountdown)
        {
            try
            {
                lock (calculationLock)
                {
                    for (int i = beginning; i < count; i++)
                    {
                        if (!expensesByCategory.ContainsKey(transactions[i].Category.Name))
                        {
                            expensesByCategory[transactions[i].Category.Name] = 0;
                        }
                        expensesByCategory[transactions[i].Category.Name] += transactions[i].Amount;
                    }

                    if(count < 3 && threadCountdown.InitialCount == 1)
                    {
                        tasksCompleted += 3;
                    }
                    else
                    {
                        tasksCompleted++;
                    }

                    threadCountdown.Signal();
                }

                this.Invoke((MethodInvoker)delegate
                {
                    UpdateProgress();
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(ex.Message, Properties.Resources.Error);
                    lock (calculationLock)
                    {
                        if (count < 3 && threadCountdown.InitialCount == 1)
                        {
                            tasksCompleted += 3;
                        }
                        else
                        {
                            tasksCompleted++;
                        }
                    }
                    UpdateProgress();
                    threadCountdown.Signal();
                });
            }
            finally
            {
                if(count < 3 && threadCountdown.InitialCount == 1)
                {
                    calculationCountdown.Signal();
                    calculationCountdown.Signal();
                    calculationCountdown.Signal();
                }
                else
                {
                    calculationCountdown.Signal();
                }
            }
        }

        private void Thread1(int count, CountdownEvent threadCountdown)
        {
            Calculate(0, count, threadCountdown);
        }

        private void Thread2(int count, CountdownEvent threadCountdown)
        {
            Calculate(count, count * 2, threadCountdown);
        }

        private void Thread3(int count, CountdownEvent threadCountdown)
        {
            Calculate(count * 2, transactions.Count(), threadCountdown);
        }

        private void PopulateTransNumbers(Transaction transaction)
        {
            if (transaction.Amount < 100)
            {
                lock (numberOfTransLock)
                {
                    numberOfSmallTrans++;
                }
            }
            else if (transaction.Amount >= 100 && transaction.Amount < 1000)
            {
                lock (numberOfTransLock)
                {
                    numberOfMediumTrans++;
                }
            }
            else
            {
                lock (numberOfTransLock)
                {
                    numberOfLargeTrans++;
                }
            }
        }

        private void CalculateSmallTransactionsThread(int count)
        {
            try {
                for(int i = 0; i < count; i++)
                {
                    PopulateTransNumbers(transactions[i]);
                }
                lock (calculationLock)
                {
                    if(transactions.Count < 3)
                    {
                        tasksCompleted += 3;
                    }
                    else
                    {
                        tasksCompleted++;
                    }
                }
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateProgress();
                });

                if(transactions.Count() < 3)
                {
                    calculationCountdown.Signal();
                    calculationCountdown.Signal();
                    calculationCountdown.Signal();
                }
                else
                {
                    calculationCountdown.Signal();
                }
            }
            catch(Exception ex)
            {
                lock (calculationLock)
                {
                    tasksCompleted++;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateProgress();
                });

                if (transactions.Count() < 3)
                {
                    calculationCountdown.Signal();
                    calculationCountdown.Signal();
                    calculationCountdown.Signal();
                }
                else
                {
                    calculationCountdown.Signal();
                }
                MessageBox.Show(Properties.Resources.Error + ex.Message);
            }
        }

        private void CalculateMediumTransactionsThread(int count)
        {
            try
            {
                for (int i = count; i < count * 2; i++)
                {
                    PopulateTransNumbers(transactions[i]);
                }
                lock (calculationLock)
                {
                    tasksCompleted++;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateProgress();
                });
                calculationCountdown.Signal();
            }
            catch(Exception ex)
            {
                lock (calculationLock)
                {
                    tasksCompleted++;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateProgress();
                });
                calculationCountdown.Signal();
                MessageBox.Show(Properties.Resources.Error + ex.Message);
            }
            
        }

        private void CalculateLargeTransactionsThread(int count)
        {
            try
            {
                for (int i = count * 2; i < transactions.Count(); i++)
                {
                    PopulateTransNumbers(transactions[i]);
                }
                lock (calculationLock)
                {
                    tasksCompleted++;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateProgress();
                });

                calculationCountdown.Signal();
            }
            catch (Exception ex)
            {
                lock (calculationLock)
                {
                    tasksCompleted++;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateProgress();
                });
                calculationCountdown.Signal();
                MessageBox.Show(Properties.Resources.Error + ex.Message);
            }
            
        }

        private void CalculateExpensesByCategory()
        {
            try
            {
                transactions = transactionManager.GetAllTransactions().ToList();

                int threadCount = transactions.Count() >= 3 ? 3 : 1;
                CountdownEvent threadCountdown = new CountdownEvent(threadCount);

                if(transactions.Count() >= 3)
                {
                    int thirdOfTransactions = transactions.Count() / 3;

                    ThreadPool.QueueUserWorkItem(task => Thread1(thirdOfTransactions, threadCountdown));
                    ThreadPool.QueueUserWorkItem(task => Thread2(thirdOfTransactions, threadCountdown));
                    ThreadPool.QueueUserWorkItem(task => Thread3(thirdOfTransactions, threadCountdown));

                    ThreadPool.QueueUserWorkItem(task => CalculateSmallTransactionsThread(thirdOfTransactions));
                    ThreadPool.QueueUserWorkItem(task => CalculateMediumTransactionsThread(thirdOfTransactions));
                    ThreadPool.QueueUserWorkItem(task => CalculateLargeTransactionsThread(thirdOfTransactions));
                }
                else
                {
                    ThreadPool.QueueUserWorkItem(task => Thread1(transactions.Count(), threadCountdown));
                    ThreadPool.QueueUserWorkItem(task => CalculateSmallTransactionsThread(transactions.Count()));
                }

                threadCountdown.Wait();

                if (transactions.Any())
                {
                    lock (calculationLock)
                    {
                        if (expensesByCategory.Any())
                        {
                            report += "\r\n" + Properties.Resources.TotalExpCat + "\r\n";
                            foreach (var kvp in expensesByCategory)
                            {
                                report += $"\r\n{kvp.Key}: {kvp.Value}\r\n";
                                var categoryTransactions = transactions.Where(t => t.Category.Name == kvp.Key).OrderBy(t => t.Date);
                                foreach (var transaction in categoryTransactions)
                                {
                                    report += $"  - {transaction.Description} {transaction.Date.ToString("d")}: {transaction.Amount} (ID: {transaction.Id})\r\n";
                                }
                            }
                            report += "\r\n";
                        }

                        if (expensesByCategory.ContainsKey("Savings"))
                        {
                            report += $"{Properties.Resources.TotalSavings} {expensesByCategory["Savings"]}\r\n\r\n";
                        }
                    }
                }

                lock (calculationLock)
                {
                    tasksCompleted++;
                }

                this.Invoke((MethodInvoker)delegate
                {
                    expensesLabel.Text = $"{Properties.Resources.ExpByCat} \n {string.Join("\n", expensesByCategory.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}";
                    UpdateProgress();
                });

                calculationCountdown.Signal();
            }
            catch (Exception ex) 
            {
                this.Invoke((MethodInvoker)delegate
                {
                    expensesLabel.Text = $"{Properties.Resources.Error}: {ex.Message}";
                    lock(calculationLock)
                    {
                        tasksCompleted++;
                    }
                    UpdateProgress();
                });
                calculationCountdown.Signal();
            }
        }

        private void CalculateGoalProgress()
        {
            try
            {
                var goals = financialGoalManager.ReadAllUserGoals();
                List<string> localSummaries = new List<string>();

                foreach (var goal in goals)
                {
                    float progress = (goal.CurrentAmount / goal.TargetAmount) * 100;
                    localSummaries.Add($"{goal.Name}: {progress:F2}% ({goal.CurrentAmount}/{goal.TargetAmount})");
                }

                lock (calculationLock)
                {
                    goalProgressSummaries.AddRange(localSummaries);

                    if (goalProgressSummaries.Any())
                    {
                        report += Properties.Resources.GoalProgress + "\r\n";
                        report += string.Join("\r\n", goalProgressSummaries) + "\r\n\r\n";
                    }

                    tasksCompleted++;
                }

                this.Invoke((MethodInvoker)delegate
                {
                    goalsProgressLabel.Text = Properties.Resources.GoalProgress + "\n" + (goalProgressSummaries.Any() ? string.Join("\n", goalProgressSummaries) : Properties.Resources.NoGoals);
                    UpdateProgress();
                });

                calculationCountdown.Signal();
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    goalsProgressLabel.Text = $"{Properties.Resources.Error}: {ex.Message}";
                    lock (calculationLock)
                    {
                        tasksCompleted++;
                    }
                    UpdateProgress();
                });
                calculationCountdown.Signal();
            }
        }

        private void GenerateSummaryReport()
        {
            try
            {
                string reportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/summaryReport.txt");
                string pdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReport.pdf");
                string signaturePdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReportPdf.signature");
                string signatureTxtFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReportTxt.signature");

                string transText = 
                    $"{Properties.Resources.SmallTrans} {numberOfSmallTrans}\r\n" +
                    $"{Properties.Resources.MediumTrans} {numberOfMediumTrans}\r\n" +
                    $"{Properties.Resources.LargeTrans} {numberOfLargeTrans}\r\n" +
                    $"{Properties.Resources.TotalTrans} {numberOfSmallTrans + numberOfMediumTrans + numberOfLargeTrans}";

                this.Invoke((MethodInvoker)delegate
                {
                    numberOfTransLabel.Text = transText;
                });

                lock(calculationLock)
                {
                    report += transText;
                }

                reportMutex.WaitOne();
                try
                {
                    File.WriteAllText(reportFilePath, report);

                    byte[] pdfBytes;

                    using (var ms = new MemoryStream())
                    {
                        using (var writer = new PdfWriter(ms))
                        using(var pdf = new PdfDocument(writer))
                        using (var document = new Document(pdf))
                        {
                            var font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                            document.Add(new Paragraph(report).SetFont(font));
                        }
                        pdfBytes = ms.ToArray();
                    }

                    File.WriteAllBytes(pdfFilePath, pdfBytes);

                    byte[] signature = RsaEncryptionHelper.SignDocument(pdfBytes);
                    File.WriteAllBytes(signaturePdfFilePath, signature);

                    lock(calculationLock)
                    {
                        tasksCompleted++;
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        summaryTextBox.Text = $"{Properties.Resources.PDFGenErr} {ex.Message}";
                        lock (calculationLock)
                        {
                            tasksCompleted++;
                        }
                        UpdateProgress();
                    });
                    return;
                }
                finally
                {
                    reportMutex.ReleaseMutex();
                }

                this.Invoke((MethodInvoker)delegate
                {
                    summaryTextBox.Text = report;
                    UpdateProgress();
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    summaryTextBox.Text = $"{Properties.Resources.Error}: {ex.Message}";
                    lock (calculationLock)
                    {
                        tasksCompleted++;
                    }
                    UpdateProgress();
                });
            }
        }

        private void UpdateProgress()
        {
            progressBar.Value = tasksCompleted;
            if (tasksCompleted == totalTasks)
            {
                startAnalysisBtn.Enabled = true;
            }
        }

        private void viewPdfBtn_Click(object sender, EventArgs e)
        {
            string pdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReport.pdf");
            string signaturePdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReportPdf.signature");

            try
            {
                if(!File.Exists(pdfFilePath) || !File.Exists(signaturePdfFilePath))
                {
                    MessageBox.Show(Properties.Resources.PDFError);
                    return;
                }

                byte[] pdf = File.ReadAllBytes(pdfFilePath);
                byte[] signature = File.ReadAllBytes(signaturePdfFilePath);

                bool isValid = RsaEncryptionHelper.VerifySignature(pdf, signature);

                if (!isValid)
                {
                    MessageBox.Show(Properties.Resources.InvalidSignature);
                    return;
                }

                Process.Start(new ProcessStartInfo(pdfFilePath) { UseShellExecute = true });
                MessageBox.Show(Properties.Resources.PDFSuccess);
            }
            catch(Exception ex)
            {
                MessageBox.Show(Properties.Resources.PDFErr2);
                Console.WriteLine("Error verifying or opening the PDF: " + ex.Message);
            }
        }

        private void calculateAvgTransactions_Click(object sender, EventArgs e)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../BackupApp/bin/Debug/BackupApp.exe"),
                    Arguments = SessionManager.currentUserId.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                }
            };

            try
            {
                process.Start();
                process.WaitForExit();

                int exitCode = process.ExitCode;

                if(exitCode == 0)
                {
                    string resultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/averages.txt");
                    if (File.Exists(resultFile))
                    {
                        string[] lines = File.ReadAllLines(resultFile);
                        float totalAverage = float.Parse(lines[1]);
                        var categoryAverages = new Dictionary<string, float>();
                        for(int i = 4; i < lines.Length; i++)
                        {
                            string[] parts = lines[i].Split(':');
                            categoryAverages[parts[0]] = float.Parse(parts[1]);
                        }

                        string message = $"{Properties.Resources.AvgTransValue} {totalAverage}\n\n";
                        message += $"{Properties.Resources.AvgByCat} \n";
                        foreach(var kvp in categoryAverages)
                        {
                            message += $"{kvp.Key}: {kvp.Value}\n";
                        }

                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.AvgTxtErr);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.AvgCalcErr);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Properties.Resources.AvgCalcErr);
                Console.WriteLine("Error in averages", ex.Message);
            }
        }
    }
}
