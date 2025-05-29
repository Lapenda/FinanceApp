using FinanceApp.Manager;
using FinanceApp.Managers;
using FinanceApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    public partial class TransactionForm : Form
    {
        private readonly CategoryManager categoryManager;
        private readonly TransactionManager transactionManager;
        private readonly BudgetManager budgetManager;

        public TransactionForm()
        {
            InitializeComponent();

            categoryManager = new CategoryManager("categories.xml");
            transactionManager = new TransactionManager();
            budgetManager = new BudgetManager();

            if (!SessionManager.isLoggedIn)
            {
                MessageBox.Show("Invalid or expired session. Please log in again.");

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }

            InitializeForm();
        }

        private void InitializeForm()
        {
            SettingsManager.ApplyTheme(this);
            InitializeCategoryComboBox();

             welcomeLabel.Text = $"Transaction Form - Welcome, {SessionManager.currentUsername} ({SessionManager.currentUserRole})";
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            if(categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a category");
                return;
            }

            Category selectedCategory = (Category)categoryComboBox.SelectedItem;

            if (!float.TryParse(amountTextBox.Text, out float amount) || amount < 0)
            {
                MessageBox.Show("Please enter a valid amount!");
                return;
            }

            var description = descTextBox.Text.Trim();

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please enter description");
                return;
            }

            if (selectedCategory.Name.ToLower() == "savings")
            {
                FinancialGoalManager goalManager = new FinancialGoalManager();
                var goals = goalManager.ReadAllUserGoals();
                if (goals.Count == 0)
                {
                    MessageBox.Show("No financial goals found. Please create a goal first.");
                    FinancialGoalsForm financialGoalsForm = new FinancialGoalsForm();
                    financialGoalsForm.Show();
                    return;
                }
                else
                {
                    using (var goalSelectionForm = new Form())
                    {
                        goalSelectionForm.Text = "Select Financial Goal";
                        goalSelectionForm.Size = new Size(300, 150);
                        ComboBox goalComboBox = new ComboBox { Location = new Point(20, 20), Width = 200 };
                        goalComboBox.Items.AddRange(goals.Select(g => g.Name).ToArray());
                        goalComboBox.SelectedIndex = 0;
                        Button confirmButton = new Button { Text = "Confirm", Location = new Point(20, 60) };
                        confirmButton.Click += (s, ev) =>
                        {
                            if (goalComboBox.SelectedItem != null)
                            {
                                var selectedGoal = goals.First(g => g.Name == goalComboBox.SelectedItem.ToString());
                                selectedGoal.UpdateProgress(amount);
                                goalManager.UpdateGoal(selectedGoal, selectedGoal.Name, selectedGoal.TargetAmount, selectedGoal.CurrentAmount);
                                goalSelectionForm.Close();
                            }
                        };
                        goalSelectionForm.Controls.Add(goalComboBox);
                        goalSelectionForm.Controls.Add(confirmButton);
                        goalSelectionForm.ShowDialog();
                    }
                }
            }

            Transaction tx = new Transaction(SessionManager.currentUserId, amount, description, selectedCategory, SettingsManager.GetSettings().DefaultCurrency, datePicker.Value);
            BudgetForm budgetForm = new BudgetForm();
            var transactionSuccessfull = budgetForm.UpdateBudget(tx.Amount, tx.Category);

            if (transactionSuccessfull)
            {
                transactionManager.Save(tx);
                SettingsManager.GetSettings().LastTransactionCategory = selectedCategory.Name;
                SettingsManager.GetSettings().Save();

                budgetForm.Show();
                this.Hide();
            }
        }

        private void InitializeCategoryComboBox()
        {
            
            categoryComboBox.Items.Clear();

            categoryComboBox.DisplayMember = "Name";

            var categories = categoryManager.ReadAllUserCategories();


            var savingsCategoryExists = categories.Any(c => c.Name.ToLower() == "savings");

            if (!savingsCategoryExists)
            {
                Category savingsCat = new Category(SessionManager.currentUserId, "Savings", "Savings category");
                categoryManager.CreateCategory(savingsCat);
                categories = categoryManager.ReadAllUserCategories();
            }

            if (categories.Count == 0)
            {
                MessageBox.Show("You have no categories yet so please enter a category first.");
                return;
            }

            categoryComboBox.Items.AddRange(categories.ToArray());


            var lastCategory = SettingsManager.GetSettings().LastTransactionCategory;
            categoryComboBox.SelectedItem = categories.FirstOrDefault(c => c.Name ==  lastCategory);

            if (categoryComboBox.SelectedItem == null && categoryComboBox.Items.Count > 0)
            {
                categoryComboBox.SelectedIndex = 0;
            }
        }

        private void editCategoriesBtn_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.Show();
            this.Hide();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = (Category)categoryComboBox.SelectedItem;

            var budget = budgetManager.ReadAllUserBudgets().FirstOrDefault(b => b.CategoryId == selectedCategory.Id);
            
            if (budget != null)
            {
                budgetLabel.Text = $"Remaining budget for the selected category is: {budget.CalculateRemaining()}";
            }
            else
            {
                budgetLabel.Text = "There is no budget for the selected category";
            }
        }
    }
}
