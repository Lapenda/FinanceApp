using FinanceApp.Manager;
using FinanceApp.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinanceApp.Forms
{
    public partial class FinancialGoalsForm : Form
    {
        private readonly FinancialGoalManager financialGoalManager;
         
        public FinancialGoalsForm()
        {
            InitializeComponent();

            financialGoalManager = new FinancialGoalManager();

            LoadDataGrid();

            SettingsManager.ApplyTheme(this);

            addBtn.Enabled = false;
            delBtn.Enabled = false;
            editBtn.Enabled = false;
        }

        private void clrTextBtn_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void LoadDataGrid()
        {
            goalsDataGridView.DataSource = null;
            goalsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var goals = financialGoalManager.ReadAllGoals();
            if(goals.Count == 0 )
            {
                MessageBox.Show($"You don't have any goals yet, please enter some");
            }
            goalsDataGridView.DataSource = goals;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            var tarAmount = tarAmountTextBox.Text;
            var curAmount = curAmountTextBox.Text;

            if(!float.TryParse(curAmount, out float currentAmount)){
                MessageBox.Show("Please enter a valid current amount.");
                return;
            }

            if (!float.TryParse(tarAmount, out float targetAmount))
            {
                MessageBox.Show("Please enter a valid target amount.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name");
                return;
            }

            var goals = financialGoalManager.ReadAllGoals();

            if(goals.Any(g => g.Name.Trim() == name.Trim()))
            {
                MessageBox.Show($"Goal with that name already exists, please choose a different one");
                return;
            }

            financialGoalManager.CreateGoal(new Models.FinancialGoal(name, currentAmount, targetAmount));

            LoadDataGrid();

            ClearInputs();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var selectedRow = goalsDataGridView.SelectedRows[0];

            var name = nameTextBox.Text;
            var tarAmount = tarAmountTextBox.Text;
            var curAmount = curAmountTextBox.Text;

            if (!float.TryParse(curAmount, out float currentAmount))
            {
                MessageBox.Show("Please enter a valid current amount.");
                return;
            }

            if (!float.TryParse(tarAmount, out float targetAmount))
            {
                MessageBox.Show("Please enter a valid target amount.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name");
                return;
            }

            var goals = financialGoalManager.ReadAllGoals();

            var existingGoal = goals.FirstOrDefault(g => g.Id == int.Parse(selectedRow.Cells["Id"].Value.ToString()));

            financialGoalManager.UpdateGoal(existingGoal, name, targetAmount, currentAmount);

            LoadDataGrid();

            ClearInputs();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            var selectedRow = goalsDataGridView.SelectedRows[0];

            var goals = financialGoalManager.ReadAllGoals();

            var existingGoal = goals.FirstOrDefault(g => g.Id == int.Parse(selectedRow.Cells["Id"].Value.ToString()));

            financialGoalManager.DeleteGoal(existingGoal);
            LoadDataGrid();

            ClearInputs();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if(nameTextBox.Text.Length == 0)
            {
                addBtn.Enabled = false;
                editBtn.Enabled = false;
                delBtn.Enabled = false;
            }
            else
            {
                addBtn.Enabled = true;
                editBtn.Enabled = true;
                delBtn.Enabled = true;
            }
        }

        private void curAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (curAmountTextBox.Text.Length == 0)
            {
                addBtn.Enabled = false;
                editBtn.Enabled = false;
                delBtn.Enabled = false;
            }
            else
            {
                addBtn.Enabled = true;
                editBtn.Enabled = true;
                delBtn.Enabled = true;
            }
        }

        private void tarAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (tarAmountTextBox.Text.Length == 0)
            {
                addBtn.Enabled = false;
                editBtn.Enabled = false;
                delBtn.Enabled = false;
            }
            else
            {
                addBtn.Enabled = true;
                editBtn.Enabled = true;
                delBtn.Enabled = true;
            }
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            BudgetForm budgetForm = new BudgetForm();
            budgetForm.Show();
            this.Hide();
        }

        private void goalsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(goalsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = goalsDataGridView.SelectedRows[0];
                nameTextBox.Text = selectedRow.Cells["Name"].Value.ToString();
                curAmountTextBox.Text = selectedRow.Cells["CurrentAmount"].Value.ToString();
                tarAmountTextBox.Text = selectedRow.Cells["TargetAmount"].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            goalsDataGridView.ClearSelection();
            nameTextBox.Clear();
            tarAmountTextBox.Clear();
            curAmountTextBox.Clear();
        }
    }
}
