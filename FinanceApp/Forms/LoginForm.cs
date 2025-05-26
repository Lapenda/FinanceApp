using FinanceApp.Manager;
using FinanceApp.Models;
using FinanceApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SettingsManager.LanguageChanged += (s, e) => SettingsManager.UpdateFormLanguage(this);
            InitializeLanguageComboBox();
            SettingsManager.ApplyTheme(this);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            User user = new User(2, usernameTextBox.Text, passwordTextBox.Text);
            if(user.Login(usernameTextBox.Text, passwordTextBox.Text))
            {
                MessageBox.Show(Resources.LoginSuccessfulMessage);
                this.Hide();

                TransactionForm txForm = new TransactionForm();
                txForm.Show();
            }
            else
            {
                MessageBox.Show(Resources.InvalidCredentialsMessage);
            }
        }

        private void InitializeLanguageComboBox()
        {
            languageComboBox.Items.Clear();

            foreach(var culture in SettingsManager.GetSupportedCultures())
            {
                languageComboBox.Items.Add(culture.Key);
            }

            var currentCulture = Thread.CurrentThread.CurrentUICulture;
            var selectedLanguage = SettingsManager.GetSupportedCultures()
                .FirstOrDefault(c => c.Value.Name == currentCulture.Name)
                .Key;

            languageComboBox.SelectedItem = selectedLanguage ?? Properties.Resources.English;
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageComboBox.SelectedItem != null)
            {
                SettingsManager.SetLanguage(languageComboBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show(
                    "Please select a language.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }
    }
}
