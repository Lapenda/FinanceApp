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
using FinanceApp.Models;
using System.Runtime.CompilerServices;
using FinanceApp.Manager;

namespace FinanceApp.Forms
{
    public partial class AdminForm : Form
    {
        UserManager userManager;

        public AdminForm()
        {
            InitializeComponent();
            userManager = new UserManager();

            FillOutData();
            InitializeDataGrid();
            InitializeComboBox();

            SettingsManager.ApplyTheme(this);
        }

        private void InitializeComboBox()
        {
            userRoleComboBox.Items.Clear();
            userRoleComboBox.Items.AddRange(new[] { "User", "Unprivileged User", "Admin" });
        }

        private void InitializeDataGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var users = userManager.GetAllUsers().Where(u => u.Id != SessionManager.currentUserId).ToList();
            if(users != null )
            {
                dataGridView.DataSource = users;
            }

            dataGridView.Columns["Password"].Visible = false;
        }

        private void FillOutData()
        {
            var user = userManager.GetAllUsers().FirstOrDefault(u => u.Id == SessionManager.currentUserId);

            adminLastNameTxtBox.Text = user.LastName;
            adminNameTxtBox.Text = user.FirstName;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            string adminFirstName = adminNameTxtBox.Text;
            string adminLastName = adminLastNameTxtBox.Text;

            if(string.IsNullOrEmpty(adminFirstName) || string.IsNullOrEmpty(adminLastName))
            {
                MessageBox.Show(Properties.Resources.EmptyField);
                return;
            }

            var success = userManager.EditUser(SessionManager.currentUserId, adminFirstName, adminLastName, SessionManager.currentUserRole);

            if(success)
            {
                MessageBox.Show(Properties.Resources.Success);
            }
            else
            {
                MessageBox.Show(Properties.Resources.Error);
                FillOutData();
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                var user = (User)selectedRow.DataBoundItem;

                userNameTextBox.Text = user.FirstName;
                userLastNameTextBox.Text = user.LastName;
                userRoleComboBox.SelectedItem = user.Role;
            }
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            var name = userNameTextBox.Text;
            var lastName = userLastNameTextBox.Text;
            var role = userRoleComboBox.SelectedItem.ToString();

            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                var user = (User)selectedRow.DataBoundItem;

                var success = userManager.EditUser(user.Id, name, lastName, role);

                if (success)
                {
                    MessageBox.Show(Properties.Resources.Success);
                    userLastNameTextBox.Clear();
                    userNameTextBox.Clear();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.Error);
                }

                InitializeDataGrid();
            }
            else
            {
                MessageBox.Show(Properties.Resources.Error);
            }

        }

        private void delUserBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                var user = (User)selectedRow.DataBoundItem;

                var success = userManager.DeleteUser(user.Id);

                if (success)
                {
                    MessageBox.Show(Properties.Resources.Success);
                    InitializeDataGrid();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.Error);
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            var users = userManager.GetAllUsers().Where(u => u.Id != SessionManager.currentUserId).ToList();

            if (users == null)
            {
                return;
            }

            var usersToShow = users.Where(u => u.LastName.ToLower().StartsWith(searchTextBox.Text.ToLower())).ToList();
            if(usersToShow.Count > 0)
            {
                dataGridView.DataSource = usersToShow;
            }
        }
    }
}
