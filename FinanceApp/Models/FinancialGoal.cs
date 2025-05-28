using FinanceApp.Encryption;
using Newtonsoft.Json;
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
        public int UserId { get; set; }
        public string Name { get; set; }
        //public DateTime Deadline { get; set; }

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
