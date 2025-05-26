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

namespace FinanceApp.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryManager categoryManager;

        public CategoryForm()
        {
            InitializeComponent();
            categoryManager = new CategoryManager("categories.xml");

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

            if (catDesc == null || catDesc == "" || catName == null || catName == "") 
            {
                MessageBox.Show("Please enter a valid name and description");
                return;
            }
         
            categoryManager.CreateCategory(new Category(catName, catDesc));

            InitializeCategoryComboBox();
            nameOfCatTextBox.Clear();
            descOfCatTextBox.Clear();
        }

        private void deleteCategoryBtn_Click(object sender, EventArgs e)
        {
            var category = (Category)categoriesComboBox.SelectedItem;
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
            var categories = categoryManager.ReadAllCategories();
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
