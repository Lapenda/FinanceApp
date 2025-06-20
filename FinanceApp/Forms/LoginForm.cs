using FinanceApp.Manager;
using FinanceApp.Managers;
using FinanceApp.Models;
using FinanceApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
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

            var resourceManager = new ResourceManager("LogoDLL.Resources", typeof(LogoDLL.Class1).Assembly);
            var logo = (Bitmap)resourceManager.GetObject("logo");

            pictureBox.Image = logo;

            var timer = new System.Windows.Forms.Timer { Interval = 2000 };
            timer.Tick += (s, e) =>
            {
                pictureBox.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var userManager = new UserManager();

                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;

                string jwtToken = userManager.Login(username, password);

                if(!string.IsNullOrEmpty(jwtToken))
                {
                    Settings.Default.JwtToken = jwtToken;
                    Settings.Default.Save();

                    userManager.ValidateToken(jwtToken, out var claimsPrincipal);
                    SessionManager.StartSession(claimsPrincipal);

                    MessageBox.Show(Resources.LoginSuccessfulMessage);
                    this.Hide();

                    TransactionForm transactionForm = new TransactionForm();
                    transactionForm.Show();
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Login Error: " + ex.Message);
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

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }
}
