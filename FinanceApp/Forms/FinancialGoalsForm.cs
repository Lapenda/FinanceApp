﻿using FinanceApp.Manager;
using FinanceApp.Managers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    public partial class FinancialGoalsForm : Form
    {
        private readonly FinancialGoalManager financialGoalManager;
         
        public FinancialGoalsForm()
        {
            InitializeComponent();

            financialGoalManager = new FinancialGoalManager();
            goalsDataGridView.MultiSelect = false;

            LoadDataGrid();

            SettingsManager.ApplyTheme(this);

            UpdateButtonStates();

            speedComboBox.Items.AddRange(new[] { "1 MB/s", "2 MB/s", "4 MB/s", Properties.Resources.NoLimit });
            speedComboBox.SelectedIndex = 3;
        }

        private void clrTextBtn_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void LoadDataGrid()
        {
            goalsDataGridView.DataSource = null;
            goalsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var goals = financialGoalManager.ReadAllUserGoals();
            if(goals.Count == 0 )
            {
                MessageBox.Show($"{Properties.Resources.NoFinGoal}");
            }
            goalsDataGridView.DataSource = goals;
            UpdateButtonStates();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            var tarAmount = tarAmountTextBox.Text;
            var curAmount = curAmountTextBox.Text;

            if(!float.TryParse(curAmount, out float currentAmount)){
                MessageBox.Show(Properties.Resources.ValidCurrAm);
                return;
            }

            if (!float.TryParse(tarAmount, out float targetAmount))
            {
                MessageBox.Show(Properties.Resources.ValidTarAm);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(Properties.Resources.ValidName);
                return;
            }

            var goals = financialGoalManager.ReadAllUserGoals();

            if(goals.Any(g => g.Name.Trim() == name.Trim()))
            {
                MessageBox.Show(Properties.Resources.GoalExists);
                return;
            }

            financialGoalManager.CreateGoal(new Models.FinancialGoal(SessionManager.currentUserId, name, currentAmount, targetAmount));

            LoadDataGrid();

            ClearInputs();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (goalsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Properties.Resources.SelectGoal);
                return;
            }

            var selectedRow = goalsDataGridView.SelectedRows[0];

            var name = nameTextBox.Text;
            var tarAmount = tarAmountTextBox.Text;
            var curAmount = curAmountTextBox.Text;

            if (!float.TryParse(curAmount, out float currentAmount))
            {
                MessageBox.Show(Properties.Resources.ValidCurrAm);
                return;
            }

            if (!float.TryParse(tarAmount, out float targetAmount))
            {
                MessageBox.Show(Properties.Resources.ValidTarAm);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(Properties.Resources.ValidName);
                return;
            }

            var goals = financialGoalManager.ReadAllUserGoals();

            var existingGoal = goals.FirstOrDefault(g => g.Id == int.Parse(selectedRow.Cells["Id"].Value.ToString()));

            financialGoalManager.UpdateGoal(existingGoal, name, targetAmount, currentAmount);

            LoadDataGrid();

            ClearInputs();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (goalsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Properties.Resources.SelectGoal);
                return;
            }

            var selectedRow = goalsDataGridView.SelectedRows[0];

            var goalName = selectedRow.Cells["Name"].Value.ToString();

            var confirmResult = MessageBox.Show($"{Properties.Resources.ConfirmGoalDelete} '{goalName}'?", Properties.Resources.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            var goals = financialGoalManager.ReadAllUserGoals();

            var existingGoal = goals.FirstOrDefault(g => g.Id == int.Parse(selectedRow.Cells["Id"].Value.ToString()));

            financialGoalManager.DeleteGoal(existingGoal);
            LoadDataGrid();
            ClearInputs();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void curAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void tarAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasGoals = financialGoalManager.ReadAllUserGoals().Count > 0;
            bool hasSelection = goalsDataGridView.SelectedRows.Count > 0;
            bool hasNameInput = !string.IsNullOrWhiteSpace(nameTextBox.Text);

            addBtn.Enabled = hasNameInput;

            editBtn.Enabled = hasGoals && hasSelection && hasNameInput;
            delBtn.Enabled = hasGoals && hasSelection;
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm();
            transactionForm.Show();
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
            UpdateButtonStates();
        }

        private void ClearInputs()
        {
            goalsDataGridView.ClearSelection();
            nameTextBox.Clear();
            tarAmountTextBox.Clear();
            curAmountTextBox.Clear();
            UpdateButtonStates();
        }

        private async void downloadBtn_Click(object sender, EventArgs e)
        {
            downloadBtn.Enabled = false;
            var client = new HttpNewsClient();
            var progress = new Progress<int>(percent =>
            {
                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke(new Action(() => progressBar.Value = percent));
                    percentLabel.Invoke(new Action(() => percentLabel.Text = $"{percent}%"));
                }
                else
                {
                    progressBar.Value = percent;
                    percentLabel.Text = $"{percent}%";
                }
            });

            int? speedLimit = null;
            int selectedIndex = speedComboBox.SelectedIndex;
            if (selectedIndex == 0) speedLimit = 1024;
            else if (selectedIndex == 1) speedLimit = 2048;
            else if (selectedIndex == 2) speedLimit = 4096;
            else speedLimit = null;

            string destinationPath = @"C:\Users\Borna\Desktop\projekt.zip";

            await client.DownloadNewsAsync("https://github.com/Lapenda/projektProba/releases/download/v0.1.0-alpha/projekt.zip", destinationPath, progress, speedLimit);
            MessageBox.Show(Properties.Resources.DownloadSucceeded);
            downloadBtn.Enabled = true;
        }
    }
}
