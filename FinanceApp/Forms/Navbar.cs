﻿using FinanceApp.Manager;
using FinanceApp.Managers;
using System;
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    public partial class Navbar : UserControl
    {
        public Navbar()
        {
            InitializeComponent();

        }

        private Form GetParentForm()
        {
            Control current = this;
            while(current != null && !(current is Form)) 
            {
                current = current.Parent;
            }
            return current as Form;
        }

        private void NavigateForm<T>() where T : Form, new()
        {
            Form currentForm = GetParentForm();
            if(currentForm != null)
            {
                T newForm = new T();
                newForm.Show();
                currentForm.Hide();
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Form currentForm = GetParentForm();
            if(currentForm != null)
            {
                Properties.Settings.Default.JwtToken = null;
                Properties.Settings.Default.Save();
                SessionManager.EndSession();

                MessageBox.Show("Goodbye!");

                currentForm.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void budgeBtn_Click(object sender, EventArgs e)
        {
            NavigateForm<BudgetForm>();
        }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            NavigateForm<CategoryForm>();
        }

        private void dasboardBtn_Click(object sender, EventArgs e)
        {
            NavigateForm<DashboardForm>();
        }

        private void finGoalsBtn_Click(object sender, EventArgs e)
        {
            NavigateForm<FinancialGoalsForm>();
        }

        private void transactionsBtn_Click(object sender, EventArgs e)
        {
            NavigateForm<TransactionForm>();
        }


        private void settingsBtn_Click(object sender, EventArgs e)
        {
            NavigateForm<SettingsForm>();
        }

        private void currencyBtn_Click(object sender, EventArgs e)
        {
            var language = SettingsManager.GetSettings().Language;
            var cultureInfo = SettingsManager.GetSupportedCultures()[language];
            CurrencyDLL.CurrencyForm currencyForm = new CurrencyDLL.CurrencyForm(cultureInfo);
            currencyForm.ShowDialog();
        }

        private void UpdateButtonStates()
        {
            Form currentForm = GetParentForm();
            if (currentForm == null) return;

            budgeBtn.Enabled = true;
            categoryBtn.Enabled = true;
            dasboardBtn.Enabled = true;
            finGoalsBtn.Enabled = true;
            transactionsBtn.Enabled = true;
            settingsBtn.Enabled = true;

            if (currentForm is BudgetForm)
                budgeBtn.Enabled = false;
            else if (currentForm is CategoryForm)
                categoryBtn.Enabled = false;
            else if (currentForm is DashboardForm)
                dasboardBtn.Enabled = false;
            else if (currentForm is FinancialGoalsForm)
                finGoalsBtn.Enabled = false;
            else if (currentForm is TransactionForm)
                transactionsBtn.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateButtonStates();
        }
    }
}
