using FinanceApp.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserManager userManager;
        private readonly string connectionString;
        private readonly string jwtSecretKey;

        public RegisterForm()
        {
            InitializeComponent();

            connectionString = Environment.GetEnvironmentVariable("FINANCEAPP_CONNECTION_STRING");
            jwtSecretKey = Environment.GetEnvironmentVariable("FINANCEAPP_JWT_SECRET");

            userManager = new UserManager(connectionString, jwtSecretKey);
        }

        private void backToLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            bool registered = false;

            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string repeatedPass = repeatPassTextBox.Text;

            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatedPass)) 
            {
                MessageBox.Show("Enter all fields");
                return;
            }

            if(password != repeatedPass)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            var allUsers = userManager.GetAllUsers().ToList();
            if(allUsers.Count == 0) 
            {
                registered = userManager.Register(username, password, "Admin");
            }
            else
            {
                registered = userManager.Register(username, password, "User");
            }

            if(registered)
            {
                MessageBox.Show("Success!");
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                repeatPassTextBox.Clear();

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}
