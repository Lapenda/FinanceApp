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
using FinanceApp.Forms;
using FinanceApp.Models;
using FinanceApp.Manager;

namespace FinanceApp.Forms
{
    public partial class UsersForm : Form
    {
        UserManager userManager;

        public UsersForm()
        {
            InitializeComponent();

            userManager = new UserManager();

            FillOutData();

            SettingsManager.ApplyTheme(this);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            string newName = firstNameTextBox.Text;
            string newLastName = lastNameTextBox.Text;
            string newRole = roleComboBox.SelectedItem.ToString();

            if(string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newLastName) || string.IsNullOrEmpty(newRole))
            {
                MessageBox.Show(Properties.Resources.EmptyField);
                return;
            }
            
            var confirmResult = MessageBox.Show(Properties.Resources.LogOutConfirm, Properties.Resources.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                FillOutData();
                return;
            }
            
            var success = userManager.EditUser(SessionManager.currentUserId, newName, newLastName, newRole);

            if (success)
            {
                MessageBox.Show(Properties.Resources.Success);
                SessionManager.EndSession();
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }
            else
            {
                MessageBox.Show(Properties.Resources.Error);
                FillOutData();
            }
        }

        private void FillOutData()
        {
            var currentUser = userManager.GetAllUsers().FirstOrDefault(u => u.Id == SessionManager.currentUserId);

            firstNameTextBox.Text = currentUser.FirstName;
            lastNameTextBox.Text = currentUser.LastName;
            usernameTextBox.Text = currentUser.Username;
            roleComboBox.Items.Clear();
            roleComboBox.Items.AddRange(new[] { "User", "Unprivileged User" });
            if(currentUser.Role == "User")
            {
                roleComboBox.SelectedIndex = 0;
            }
            else
            {
                roleComboBox.SelectedIndex = 1;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show(Properties.Resources.ConfDelAcc, Properties.Resources.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(response != DialogResult.Yes)
            {
                return;
            }

            var success = userManager.DeleteUser(SessionManager.currentUserId);

            if(success)
            {
                MessageBox.Show(Properties.Resources.Success);
                SessionManager.EndSession();
                Properties.Settings.Default.JwtToken = null;
                Properties.Settings.Default.Save();
                this.Close();
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
