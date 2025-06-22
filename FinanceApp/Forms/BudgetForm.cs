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
using System.Runtime.CompilerServices;

namespace FinanceApp.Forms
{
    public partial class BudgetForm : Form
    {
        private readonly CategoryManager _categoryManager;
        private readonly BudgetManager _budgetManager;
        private readonly TransactionManager _transactionManager;

        public BudgetForm()
        {
            InitializeComponent();
            _transactionManager = new TransactionManager();
            _categoryManager = new CategoryManager("categories.xml", _transactionManager);
            _budgetManager = new BudgetManager();
            InitializeCategoryComboBox();
            SettingsManager.ApplyTheme(this);
            UpdateLabel(null);
        }

        private void UpdateLabel(Budget budget)
        {
            if(budget != null)
            {
                var category = _categoryManager.ReadAllUserCategories().FirstOrDefault(c => c.Id == budget.CategoryId);
                if(category == null)
                {
                    return;
                }
                remainingBudgetLabel.Text = $"{Properties.Resources.Category} {category.Name}, {Properties.Resources.Spent} {budget.Spent}, {Properties.Resources.Remaining} {budget.CalculateRemaining()}";
                return;
            }
            remainingBudgetLabel.Text = Properties.Resources.NoRemainingBudgetLabel;
        }

        public bool UpdateBudget(float amount, Category category)
        {
            var budgets = _budgetManager.ReadAllUserBudgets();
            var budget = budgets.FirstOrDefault(b => b.CategoryId == category.Id);

            if (budget != null)
            {
                budget.Spent += amount;
                var budgetUpdated = _budgetManager.UpdateBudget(budget, budget.Limit, budget.Spent);
                if (budgetUpdated != null)
                {
                    UpdateLabel(budget);
                    return true;
                }
                return false;
            }
            return true;
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide();
        }

        private void InitializeCategoryComboBox()
        {
            categoryComboBox.Items.Clear();

            var categories = _categoryManager.ReadAllUserCategories();

            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.DataSource = categories;
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBoxes();
        }

        private void UpdateTextBoxes()
        {
            var selectedCategory = (Category)categoryComboBox.SelectedItem;
            if (selectedCategory != null)
            {
                var budgets = _budgetManager.ReadAllUserBudgets();
                var budget = budgets.FirstOrDefault(b => b.CategoryId == selectedCategory.Id);

                if (budget != null)
                {
                    UpdateLabel(budget);
                    spentTextBox.Text = budget.Spent.ToString();
                    limitTextBox.Text = budget.Limit.ToString();
                }
                else
                {
                    spentTextBox.Text = "0";
                    limitTextBox.Text = string.Empty;
                    UpdateLabel(null);
                }

                categoryTextBox.Text = selectedCategory.Name;
            }

            UpdateButtonStatus();
        }

        private void addBudgetBtn_Click(object sender, EventArgs e)
        {
            if(categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show(Properties.Resources.SelectCat);
                return;
            }

            if(!float.TryParse(limitTextBox.Text, out float limit) || limit < 0)
            {                    
                MessageBox.Show(Properties.Resources.GreaterAmount);
                return;
            }

            if(!float.TryParse(spentTextBox.Text, out float spent) || spent < 0)
            {
                spent = 0;
            }

            var category = (Category)categoryComboBox.SelectedItem;

            var budget = new Budget(SessionManager.currentUserId, limit, spent, category.Id);

            _budgetManager.CreateBudget(budget);

            UpdateLabel(budget);
            UpdateButtonStatus();
        }

        private void UpdateButtonStatus()
        {
            var category = (Category)categoryComboBox.SelectedItem;
            var catHasBudget = _budgetManager.ReadAllUserBudgets().Any(b => b.CategoryId == category.Id);

            if (catHasBudget)
            {
                editBudgetBtn.Enabled = true;
                delBudgetBtn.Enabled = true;
                addBudgetBtn.Enabled = false;
            }
            else
            {
                editBudgetBtn.Enabled = false;
                delBudgetBtn.Enabled = false;
                addBudgetBtn.Enabled = true;
            }

            CheckIfCategoryIsSavings(category);
        }

        private void editBudgetBtn_Click(object sender, EventArgs e)
        {
            if (categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show(Properties.Resources.SelectCat);
                return;
            }

            if (!float.TryParse(limitTextBox.Text, out float limit) || limit < 0)
            {
                MessageBox.Show(Properties.Resources.GreaterAmount);
                return;
            }

            if (!float.TryParse(spentTextBox.Text, out float spent) || spent < 0)
            {
                spent = 0;
            }

            var category = (Category)categoryComboBox.SelectedItem;

            var budget = _budgetManager.ReadAllUserBudgets().FirstOrDefault(b => b.CategoryId == category.Id);

            if(budget == null)
            {
                return;
            }

            UpdateLabel(_budgetManager.UpdateBudget(budget, limit, spent));
            UpdateButtonStatus();
            UpdateTextBoxes();
        }

        private void delBudgetBtn_Click(object sender, EventArgs e)
        {
            var category = (Category)categoryComboBox.SelectedItem;

            var budget = _budgetManager.ReadAllUserBudgets().FirstOrDefault(b => b.CategoryId == category.Id);

            var confirmResult = MessageBox.Show($"{Properties.Resources.ConfDelBudg} '{category.Name}'?", Properties.Resources.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            _budgetManager.DeleteBudget(budget);
            UpdateLabel(null);
            UpdateTextBoxes();
            UpdateButtonStatus();
        }

        private void CheckIfCategoryIsSavings(Category category)
        {
            if(category != null && category.Name.ToLower() != "savings")
            {
                addBudgetBtn.Enabled = true;
            }
            else
            {
                addBudgetBtn.Enabled = false;
            }
        }
    }
}
