using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Models
{
    public class Budget
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public float Limit { get; private set; }
        public float Spent { get; set; }
        public Category Category { get; set; }

        public Budget() { }

        public Budget(int id, int userId, float limit, float spent, Category category)
        {
            Id = id;
            UserId = userId;
            Limit = limit;
            Spent = spent;
            Category = category;
        }

        public float CalculateRemaining()
        {
            return Limit - Spent;
        }

        public void UpdateLimit(float newLimit)
        {
            Limit = newLimit;
            MessageBox.Show($"Budget limit updated to: {Limit}");
        }
    }
}
