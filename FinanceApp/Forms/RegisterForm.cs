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

        public RegisterForm()
        {
            InitializeComponent();

            userManager = new UserManager();
            InitializeComboBoX();
        }

        private void InitializeComboBoX()
        {
            privilegedComboBox.Items.Clear();
            privilegedComboBox.Items.AddRange(new[] { Properties.Resources.Yes, Properties.Resources.No });
            privilegedComboBox.SelectedIndex = 0;
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
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;


            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatedPass) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) 
            {
                MessageBox.Show(Properties.Resources.EmptyField);
                return;
            }

            if(password != repeatedPass)
            {
                MessageBox.Show(Properties.Resources.PassNoMatch);
                return;
            }

            var allUsers = userManager.GetAllUsers().ToList();
            if(allUsers.Count == 0) 
            {
                registered = userManager.Register(firstName, lastName, username, password, "Admin");
            }
            else if(privilegedComboBox.SelectedIndex == 0)
            {
                registered = userManager.Register(firstName, lastName, username, password, "User");
            }
            else
            {
                registered = userManager.Register(firstName, lastName, username, password, "Unprivileged User");
            }

            if(registered)
            {
                MessageBox.Show(Properties.Resources.Success);
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                repeatPassTextBox.Clear();

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show(Properties.Resources.Error);
            }
        }
    }
}
