using FinanceApp.Manager;
using FinanceApp.Managers;
using FinanceApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FinanceApp.Forms
{
    public partial class AllTransactionsForm : Form
    {
        private readonly CategoryManager categoryManager;
        private readonly TransactionManager transactionManager;
        //private readonly IReadOnlyCollection<Transaction> transactions;
        private bool ascendingSort = true;

        public AllTransactionsForm()
        {
            InitializeComponent();
            SettingsManager.ApplyTheme(this);

            transactionManager = new TransactionManager();
            categoryManager = new CategoryManager("categories.xml", transactionManager);

            InitializeCategoryComboBox();
            InitializeCurrencyComboBox();
            LoadDataGrid();
            UpdateButtonStates();
            InitializeSortComboBox();

            //transactions = new List<Transaction>();
            //transactions = transactionManager.GetAllTransactions();
            CalculateExpenses();

            transDataGridView.CellFormatting += transDataGridView_CellFormatting;
        }

        private void InitializeCurrencyComboBox()
        {
            var currencies = new[] { "HRK", "EUR", "USD" };
            currencyComboBox.Items.Clear();
            currencyComboBox.Items.AddRange(currencies);
            currencyComboBox.SelectedIndex = 0;
        }

        private void InitializeSortComboBox()
        {
            var sortingBy = new[] { "By description", "By amount", "By date"};
            sortByComboBox.Items.Clear();
            sortByComboBox.Items.AddRange(sortingBy);
            sortByComboBox.SelectedIndex = 0;
        }

        private void LoadDataGrid()
        {
            var transactions = transactionManager.GetAllTransactions();
            if(transactions != null)
            {
                SetDataSource(transactions);
            }
            amountTextBox.Clear();
            descTextBox.Clear();
            categoryComboBox.SelectedIndex = 0;
            currencyComboBox.SelectedIndex = 0;
            dateTimePicker.Value = DateTime.Now;
        }

        private void SetDataSource(IEnumerable<Transaction> transactions)
        {
            transDataGridView.DataSource = null;
            transDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            transDataGridView.DataSource = transactions;

            transDataGridView.Columns["Id"].Visible = false;
            transDataGridView.Columns["UserID"].Visible = false;
            UpdateButtonStates();
        }

        private void transDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (transDataGridView.Columns[e.ColumnIndex].Name == "Category" && e.RowIndex >= 0)
            {
                var transaction = (Transaction)transDataGridView.Rows[e.RowIndex].DataBoundItem;
                if (transaction != null)
                {
                    e.Value = transaction.Category?.Name ?? "Unknown";
                    e.FormattingApplied = true;
                }
            }
        }

        private void InitializeCategoryComboBox()
        {
            var categories = categoryManager.ReadAllUserCategories().ToArray();
            categoryComboBox.Items.Clear();
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.Items.AddRange(categories);
            categoryComboBox.SelectedIndex = 0;
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm();
            transactionForm.Show();
            this.Hide();
        }

        private void transDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (transDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = transDataGridView.SelectedRows[0];
                var transaction = (Transaction)selectedRow.DataBoundItem;

                amountTextBox.Text = transaction.Amount.ToString();
                descTextBox.Text = transaction.Description;
                categoryComboBox.SelectedItem = categoryComboBox.Items.Cast<Category>().FirstOrDefault(c => c.Id == transaction.Category.Id);
                currencyComboBox.SelectedItem = transaction.Currency;
                dateTimePicker.Value = transaction.Date;
            }
            
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            if(transDataGridView.SelectedRows.Count > 0)
            {
                editBtn.Enabled = true;
                delBtn.Enabled = true;
            }
            else
            {
                editBtn.Enabled = false;
                delBtn.Enabled = false;
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if(transDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var selectedRow = transDataGridView.SelectedRows[0];
            var transaction = (Transaction)selectedRow.DataBoundItem;

            var result = MessageBox.Show($"Are you sure you want to delete transaction '{transaction.Description}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(!(result == DialogResult.Yes))
            {
                return;
            }

            transactionManager.DeleteTransaction(transaction);

            LoadDataGrid();
            CalculateExpenses();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (transDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var selectedRow = transDataGridView.SelectedRows[0];
            var transaction = (Transaction)selectedRow.DataBoundItem;

            transaction.Currency = currencyComboBox.Text;
            if(!float.TryParse(amountTextBox.Text, out float amount))
            {
                MessageBox.Show("Enter valid amount!");
                return;
            }

            BudgetForm budgetForm = new BudgetForm();

            budgetForm.UpdateBudget(-transaction.Amount, transaction.Category);

            transaction.Date = dateTimePicker.Value;
            transaction.Amount = amount;
            transaction.Description = descTextBox.Text;
            transaction.Category = (Category)categoryComboBox.SelectedItem;

            if(transaction.Category.Name.ToLower() == "savings")
            {
                TransactionForm transactionForm = new TransactionForm();
                transactionForm.CheckIfCategoryIsSavings(transaction.Category.Name, amount);
                transactionManager.EditTransaction(transaction);
            }
            else
            {
                var transactionSuccessfull = budgetForm.UpdateBudget(amount, transaction.Category);
                if (transactionSuccessfull)
                {
                    transactionManager.EditTransaction(transaction);
                }
            }

            LoadDataGrid();
            CalculateExpenses();
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            var transactions = transactionManager.GetAllTransactions();

            if (transactions == null)
            {
                return;
            }

            var transactionsToShow = transactions.Where(t => t.Description.ToLower().Contains(filterTextBox.Text.ToLower()));
            if (transactionsToShow.Count() > 0)
            {
                SetDataSource(transactionsToShow.ToList());
            }
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            var transactions = transactionManager.GetAllTransactions();

            sortBtn.Text = ascendingSort ? "Sort ascending" : "Sort descending";
            ascendingSort = !ascendingSort;

            if(sortByComboBox.SelectedItem.ToString() == "By amount")
            {
                var transactionsToShow = ascendingSort ? transactions.OrderBy(t => t.Amount).ToList() : transactions.OrderByDescending(t => t.Amount).ToList();
                SetDataSource(transactionsToShow);
            }

            if (sortByComboBox.SelectedItem.ToString() == "By description")
            {
                var transactionsToShow = ascendingSort ? transactions.OrderBy(t => t.Description).ToList() : transactions.OrderByDescending(t => t.Description).ToList();
                SetDataSource(transactionsToShow);
            }

            if (sortByComboBox.SelectedItem.ToString() == "By date")
            {
                var transactionsToShow = ascendingSort ? transactions.OrderBy(t => t.Date).ToList() : transactions.OrderByDescending(t => t.Date).ToList();
                SetDataSource(transactionsToShow);
            }
        }

        private void CalculateExpenses()
        {
            var transactions = transactionManager.GetAllTransactions();
            var totalSpent = transactions.Sum(t => t.Amount);
            
            calculatedTextBox.Multiline = true;

            calculatedTextBox.Text = "All expenses so far: \n" +  totalSpent.ToString();
        }
    }
}
