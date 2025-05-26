using FinanceApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Managers
{
    internal class FinancialGoalManager
    {
        private readonly string filePath;
        private static readonly object fileLock = new object();

        public FinancialGoalManager()
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/financialGoals.json");
            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        public List<FinancialGoal> ReadAllGoals()
        {
            lock(fileLock)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        return new List<FinancialGoal>();
                    }

                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<FinancialGoal>>(json) ?? new List<FinancialGoal>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading json form on path: {filePath}, error: {ex.Message}");
                    return new List<FinancialGoal>();
                }
            }
        }

        private void Save(List<FinancialGoal> goals) 
        {
            lock (fileLock)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(goals, Formatting.Indented);
                    File.WriteAllText(filePath, json);
                    Console.WriteLine($"Finacial goals saved to {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving goals to JSON on path: {filePath}, error: {ex.Message}");
                }
            }
        }

        public void CreateGoal(FinancialGoal goal)
        {
            var goals = ReadAllGoals();
            goal.Id = goals.Any() ? goals.Max(g => g.Id) + 1 : 1;
            goals.Add(goal);
            Save(goals);
            MessageBox.Show("Success");
        }

        public void UpdateGoal(FinancialGoal goal, string newName, float newTargetAmount, float newCurrentAmount)
        {
            var goals = ReadAllGoals();
            var existingGoal = goals.FirstOrDefault(g => g.Id == goal.Id);
            if(existingGoal != null)
            {
                existingGoal.Name = newName;
                existingGoal.TargetAmount = newTargetAmount;
                existingGoal.CurrentAmount = newCurrentAmount;
                Save(goals);
                MessageBox.Show("Success");
            }
            else
            {
                throw new Exception($"Error finding goal with ID: {goal.Id}");
            }
        }

        public void DeleteGoal(FinancialGoal goal)
        {
            var goals = ReadAllGoals();
            var existingGoal = goals.FirstOrDefault(g => g.Id == goal.Id);
            if(existingGoal != null)
            {
                goals.Remove(existingGoal);
                Save(goals);
                MessageBox.Show("Success");
            }
            else
            {
                throw new Exception($"Error finding goal: {goal}");
            }
        }
    }
}
