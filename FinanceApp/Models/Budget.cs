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
        public int CategoryId { get; set; }

        public Budget() { }

        public Budget(int userId, float limit, float spent, int categoryId)
        {
            UserId = userId;
            Limit = limit;
            Spent = spent;
            CategoryId = categoryId;
        }

        public Budget(int id, int userId, float limit, float spent, int categoryId)
        {
            Id = id;
            UserId = userId;
            Limit = limit;
            Spent = spent;
            CategoryId = categoryId;
        }

        public float CalculateRemaining()
        {
            return Limit - Spent;
        }

        public void UpdateLimit(float newLimit)
        {
            Limit = newLimit;
        }

        public void setId(int id)
        {
            Id = id;
        }
    }
}
