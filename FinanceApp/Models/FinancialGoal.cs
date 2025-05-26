using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Models
{
    public class FinancialGoal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float CurrentAmount { get; set; }
        public float TargetAmount { get; set; }

        public FinancialGoal() { }

        public FinancialGoal(string name, float currentAmount, float targetAmount)
        {
            Name = name;
            TargetAmount = targetAmount;
            CurrentAmount = currentAmount;
        }

        public void UpdateProgress(float amount)
        {
            CurrentAmount += amount;
            MessageBox.Show($"Goal progress: {CurrentAmount}/{TargetAmount} => {Math.Floor(CurrentAmount/TargetAmount * 100)}%");
        }

        public bool IsAchieved()
        {
            return CurrentAmount >= TargetAmount;
        }
    }
}
