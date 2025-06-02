using FinanceApp.Encryption;
using FinanceApp.Manager;
using FinanceApp.Managers;
using FinanceApp.Models;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly FinancialGoalManager financialGoalManager;
        private readonly TransactionManager transactionManager;
        private readonly object calculationLock = new object();
        private readonly Mutex reportMutex = new Mutex(false, "FinanceAppSummaryReportMutex");
        private Dictionary<string, float> expensesByCategory;
        private List<string> goalProgressSummaries;
        private int tasksCompleted = 0;
        private readonly int totalTasks = 3;
        private CountdownEvent calculationCountdown;

        public DashboardForm()
        {
            InitializeComponent();
            transactionManager = new TransactionManager();
            financialGoalManager = new FinancialGoalManager();
            expensesByCategory = new Dictionary<string, float>();
            goalProgressSummaries = new List<string>();
            progressBar.Maximum = totalTasks;
            calculationCountdown = new CountdownEvent(2);

            SettingsManager.ApplyTheme(this);
        }

        private void startAnalysisBtn_Click(object sender, EventArgs e)
        {
            expensesByCategory.Clear();
            goalProgressSummaries.Clear();
            tasksCompleted = 0;
            progressBar.Value = 0;
            expensesLabel.Text = "Calculating expenses....";
            goalsProgressLabel.Text = "Calculating goal progress....";
            summaryTextBox.Text = "Generating summary....";
            startAnalysisBtn.Enabled = false;

            calculationCountdown.Reset(2);

            ThreadPool.QueueUserWorkItem(task => CalculateExpensesByCategory());
            ThreadPool.QueueUserWorkItem(task => CalculateGoalProgress());


            ThreadPool.QueueUserWorkItem(task =>
            {
                calculationCountdown.Wait();
                GenerateSummaryReport();
            });
        }

        private void CalculateExpensesByCategory()
        {
            try
            {
                var transactions = transactionManager.GetAllTransactions();

                if (transactions.Any())
                {
                    lock (calculationLock)
                    {
                        foreach (var tx in transactions)
                        {
                            if (!expensesByCategory.ContainsKey(tx.Category.Name))
                            {
                                expensesByCategory[tx.Category.Name] = 0;
                            }
                            expensesByCategory[tx.Category.Name] += tx.Amount;
                        }
                    }
                }

                this.Invoke((MethodInvoker)delegate
                {
                    expensesLabel.Text = $"Expenses by Category: \n {string.Join("\n", expensesByCategory.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}";
                    UpdateProgress();
                });

            }catch(Exception ex) 
            {
                this.Invoke((MethodInvoker)delegate
                {
                    expensesLabel.Text = $"Error: {ex.Message}";
                    UpdateProgress();
                });
            }
            finally
            {
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
                }

                this.Invoke((MethodInvoker)delegate
                {
                    goalsProgressLabel.Text = "Goal progress:\n" + (goalProgressSummaries.Any() ? string.Join("\n", goalProgressSummaries) : "No goals found");
                    UpdateProgress();
                });

            }
            catch(Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    goalsProgressLabel.Text = $"Error: {ex.Message}";
                    UpdateProgress();
                });
            }
            finally
            {
                calculationCountdown.Signal();
            }
        }

        private void GenerateSummaryReport()
        {
            try
            {
                string report = $"Financial Summary Report for {SessionManager.currentUsername}\r\n";
                report += $"Generated on: {DateTime.Now.ToString("g")}\r\n";

                lock (calculationLock)
                {
                    if (expensesByCategory.Any())
                    {
                        report += "\r\nTotal expenses by Category:\r\n";
                        foreach (var kvp in expensesByCategory)
                        {
                            report += $"\r\n{kvp.Key}: {kvp.Value}\r\n";
                            var categoryTransactions = transactionManager.GetAllTransactions().Where(t => t.Category.Name == kvp.Key).OrderBy(t => t.Date);
                            foreach (var transaction in categoryTransactions)
                            {
                                report += $"  - {transaction.Description} {transaction.Date.ToString("d")}: {transaction.Amount} (Transaction ID: {transaction.Id})\r\n";
                            }
                        }
                        report += "\r\n";
                    }

                    if (expensesByCategory.ContainsKey("Savings"))
                    {
                        report += $"Total Savings: {expensesByCategory["Savings"]}\r\n\r\n";
                    }

                    if (goalProgressSummaries.Any())
                    {
                        report += "Financial Goals Progress:\r\n";
                        report += string.Join("\r\n", goalProgressSummaries) + "\r\n";
                    }
                }

                string reportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/summaryReport.txt");
                string pdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReport.pdf");
                string signaturePdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReportPdf.signature");
                string signatureTxtFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReportTxt.signature");

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
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        summaryTextBox.Text = $"PDF Generation Error: {ex.Message}";
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
                    summaryTextBox.Text = $"Error: {ex.Message}";
                    UpdateProgress();
                });
            }
        }

        private void UpdateProgress()
        {
            tasksCompleted++;
            progressBar.Value = tasksCompleted;
            if (tasksCompleted == totalTasks)
            {
                startAnalysisBtn.Enabled = true;
            }
        }

        private void viewPdfBtn_Click(object sender, EventArgs e)
        {
            string pdfFIlePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReport.pdf");
            string signaturePdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialSummaryReportPdf.signature");

            try
            {
                if(!File.Exists(pdfFIlePath) || !File.Exists(signaturePdfFilePath))
                {
                    MessageBox.Show("Error, the PDF or the signature don't exist");
                    return;
                }

                byte[] pdf = File.ReadAllBytes(pdfFIlePath);
                byte[] signature = File.ReadAllBytes(signaturePdfFilePath);

                bool isValid = RsaEncryptionHelper.VerifySignature(pdf, signature);

                if (!isValid)
                {
                    MessageBox.Show("Signature invalid! The PDF has been tampered with.");
                    return;
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfFIlePath) { UseShellExecute = true });
                MessageBox.Show("PDF verified successfully!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error verifying or opening the PDF: " + ex.Message);
            }
        }
    }
}
