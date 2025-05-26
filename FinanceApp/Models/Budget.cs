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
        private int Id { get; set; }
        private float Limit { get; set; }
        private float Spent { get; set; }
        private Category Category { get; set; }

        public Budget() { }

        public Budget(int id, float limit, float spent, Category category)
        {
            Id = id;
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

        public Category getCategory()
        {
            return Category;
        }

        public void setCategory(Category category)
        {
            Category = category;
        }

        public float getSpent()
        {
            return Spent;
        }

        public void setSpent(float spent)
        { 
            Spent = spent;
        }


        public float getLimit()
        {
            return Limit;
        }
    }
}
