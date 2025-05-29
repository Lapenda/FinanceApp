using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
using FinanceApp.Models;
using System.Diagnostics;
using System.Windows.Forms;

namespace FinanceApp.Managers
{
    internal class BudgetManager
    {
        private readonly string filePath;
        private readonly CategoryManager _categoryManager;
        private static readonly object fileLock = new object();

        public BudgetManager() 
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/budgets.bin");
            _categoryManager = new CategoryManager("categories.xml");

            if (!File.Exists(filePath))
            {
                SaveBudgets(new List<Budget>());
            }
        }

        private void SaveBudgets(List<Budget> budgets)
        {
            lock(fileLock)
            {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    using(var writer = new BinaryWriter(stream))
                    {
                        writer.Write(budgets.Count);

                        foreach(var budget in budgets)
                        {
                            writer.Write(budget.Id);
                            writer.Write(budget.UserId);
                            writer.Write(budget.Limit);
                            writer.Write(budget.Spent);
                            writer.Write(budget.CategoryId);
                        }
                    }

                    Console.WriteLine("Budgets saved to: " + filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error writing budgets to: " + filePath + "Msg:" + ex.Message);
                }
            }
        }

        private List<Budget> ReadAllBudgets()
        {
            lock (fileLock)
            {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using(var reader = new BinaryReader(stream))
                    {
                        int count = reader.ReadInt32();
                        var budgets = new List<Budget>();

                        for(int i = 0; i < count; i++)
                        {
                            int id = reader.ReadInt32();
                            int userId = reader.ReadInt32();
                            float limit = reader.ReadSingle();
                            float spent = reader.ReadSingle();
                            int categoryId = reader.ReadInt32();

                            var budget = new Budget(id, userId, limit, spent, categoryId);

                            budgets.Add(budget);
                        }

                        return budgets;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error reading budgets from: " + filePath + "Msg: " + ex.Message);
                    return new List<Budget>();
                }
            }
        }

        public List<Budget> ReadAllUserBudgets()
        {
            return ReadAllBudgets().Where(b => b.UserId == SessionManager.currentUserId).ToList();
        }

        public void CreateBudget(Budget budget)
        {
            var budgets = ReadAllBudgets();
            var newId = budgets.Any() ? budgets.Max(b => b.Id) + 1 : 1;
            budget.setId(newId);
            budgets.Add(budget);
            SaveBudgets(budgets);
            MessageBox.Show("Budget created successfully.");
        }

        public Budget UpdateBudget(Budget budget, float newLimit, float newSpent)
        {
            var budgets = ReadAllBudgets();
            var existingBudget = budgets.FirstOrDefault(b => b.Id == budget.Id);
            if (existingBudget != null)
            {
                existingBudget.Spent = newSpent;
                existingBudget.UpdateLimit(newLimit);
                if(existingBudget.CalculateRemaining() < 0)
                {
                    MessageBox.Show("Exceeded budget!");
                    return null;
                }
                SaveBudgets(budgets);
                MessageBox.Show("Success updating budget.");
                return existingBudget;
            }
            else
            {
                MessageBox.Show("Errror in finding the correct budget.");
                return null;
            }
        }

        public void DeleteBudget(Budget budget)
        {
            var budgets = ReadAllBudgets();
            var existingBudget = budgets.FirstOrDefault(b => b.Id == budget.Id);
            if (existingBudget != null)
            {
                budgets.Remove(existingBudget);
                SaveBudgets(budgets);
                MessageBox.Show("Succes in deleting the budget.");
            }
            else
            {
                MessageBox.Show("Error deleting the budget.");
            }
        }
    }
}
