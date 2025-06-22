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
using FinanceApp.Manager;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace FinanceApp.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryManager categoryManager;
        private readonly TransactionManager transactionManager;

        public CategoryForm()
        {
            InitializeComponent();
            transactionManager = new TransactionManager();
            categoryManager = new CategoryManager("categories.xml", transactionManager);

            SettingsManager.ApplyTheme(this);

            InitializeCategoryComboBox();
            editCategoryBtn.Enabled = false;
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TransactionForm transactionForm = new TransactionForm();    
            transactionForm.Show();
        }

        private void createCategoryBtn_Click(object sender, EventArgs e)
        {
            var catName = nameOfCatTextBox.Text;
            var catDesc = descOfCatTextBox.Text;

            if (string.IsNullOrEmpty(catDesc) || string.IsNullOrEmpty(catName)) 
            {
                MessageBox.Show(Properties.Resources.ValidNameDesc);
                return;
            }
         
            categoryManager.CreateCategory(new Category(SessionManager.currentUserId, catName, catDesc));

            InitializeCategoryComboBox();
            nameOfCatTextBox.Clear();
            descOfCatTextBox.Clear();
        }

        private void deleteCategoryBtn_Click(object sender, EventArgs e)
        {
            var category = (Category)categoriesComboBox.SelectedItem;

            var confirmResult = MessageBox.Show($"{Properties.Resources.ConfCatDel} '{category.Name}'?", Properties.Resources.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            categoryManager.DeleteCategory(category);
            InitializeCategoryComboBox();
            categoriesComboBox.SelectedIndex = 0;
            var newLastTransactionName = (Category)categoriesComboBox.SelectedItem;

            if (category.Name == SettingsManager.GetSettings().LastTransactionCategory)
            {
                SettingsManager.GetSettings().LastTransactionCategory = newLastTransactionName.Name;
                SettingsManager.GetSettings().Save();
            }
        }

        private void editCategoryBtn_Click(object sender, EventArgs e)
        {
            var newName = newNameTextBox.Text;
            var newDesc = newDescriptionTextBox.Text;

            var category = (Category)categoriesComboBox.SelectedItem;

            categoryManager.UpdateCategory(category, newName, newDesc);

            if(category.Name == SettingsManager.GetSettings().LastTransactionCategory)
            {
                SettingsManager.GetSettings().LastTransactionCategory = newName;
                SettingsManager.GetSettings().Save();
            }
            InitializeCategoryComboBox();
        }

        private void InitializeCategoryComboBox()
        {
            categoriesComboBox.Items.Clear();
            var categories = categoryManager.ReadAllUserCategories();
            if(categories.Count == 0)
            {
                return;
            }

            categoriesComboBox.DisplayMember = "Name";
            
            foreach(var category in categories)
            {
                categoriesComboBox.Items.Add(category);
            }

            categoriesComboBox.SelectedIndex = 0;
        }

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var category = (Category)categoriesComboBox.SelectedItem;
            newNameTextBox.Text = category.Name;
            newDescriptionTextBox.Text = category.Description;
        }

        private void newNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if(newNameTextBox.Text.Length == 0)
            {
                editCategoryBtn.Enabled = false;
            }
            else
            {
                editCategoryBtn.Enabled = true;
            }
        }

        private void newDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if(newDescriptionTextBox.Text.Length == 0)
            {
                editCategoryBtn.Enabled = false;
            }
            else
            {
                editCategoryBtn.Enabled = true;
            }
        }
    }
}
