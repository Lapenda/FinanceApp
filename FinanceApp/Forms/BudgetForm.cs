using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceApp.Manager;
using FinanceApp.Models;
using FinanceApp.Managers;

namespace FinanceApp.Forms
{
    public partial class BudgetForm : Form
    {
        private Budget budget = new Budget();

        private readonly CategoryManager categoryManager;

        public BudgetForm()
        {
            InitializeComponent();
            categoryManager = new CategoryManager("categories.xml");
            InitializeCategoryComboBox();
            UpdateLabel();
            SettingsManager.ApplyTheme(this);
        }

        private void UpdateLabel()
        {
            //remainingBudgetLabel.Text = $"Category: {budget.getCategory().Name}, Spent: {budget.getSpent()}, Remaining: {budget.CalculateRemaining()}";
        }

        public void UpdateBudget(float amount, Category category)
        {
            //if(budget.getCategory() == category || string.IsNullOrEmpty(budget.getCategory())) 
            //{
                budget.Spent = amount;
                budget.Category = category;
            //}
            UpdateLabel();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            //ReportForm reportForm = new ReportForm();
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide();
        }

        private void InitializeCategoryComboBox()
        {
            categoryComboBox.Items.Clear();

            var categories = categoryManager.ReadAllUserCategories();

            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.DataSource = categories;
        }
    }
}
