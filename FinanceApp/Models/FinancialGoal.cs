using FinanceApp.Encryption;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace FinanceApp.Models
{
    public class FinancialGoal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool IsAchieved { get; set; }

        [JsonProperty("TargetAmount")]
        private string EncryptedTargetAmount { get; set; }

        [JsonProperty("CurrentAmount")]
        private string EncryptedCurrentAmount { get; set; }

        [JsonIgnore]
        public float CurrentAmount
        {
            get => RsaEncryptionHelper.DecryptFloat(EncryptedCurrentAmount);
            set => EncryptedCurrentAmount = RsaEncryptionHelper.EncryptFloat(value);
        }

        [JsonIgnore]
        public float TargetAmount
        {
            get => RsaEncryptionHelper.DecryptFloat(EncryptedTargetAmount);
            set => EncryptedTargetAmount = RsaEncryptionHelper.EncryptFloat(value);
        }

        public FinancialGoal() { }

        public FinancialGoal(int userId, string name, float currentAmount, float targetAmount)
        {
            UserId = userId;
            Name = name;
            TargetAmount = targetAmount;
            CurrentAmount = currentAmount;
            IsAchieved = IsGoalAchieved();
        }

        public void UpdateProgress(float amount)
        {
            CurrentAmount += amount;
            MessageBox.Show($"Goal progress: {CurrentAmount}/{TargetAmount} => {Math.Floor(CurrentAmount/TargetAmount * 100)}%");
            IsAchieved = IsGoalAchieved();
        }

        public bool IsGoalAchieved()
        {
            return CurrentAmount >= TargetAmount;
        }
    }
}
