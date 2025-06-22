namespace FinanceApp.Forms
{
    partial class CategoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameOfCatTextBox = new System.Windows.Forms.TextBox();
            this.descOfCatTextBox = new System.Windows.Forms.TextBox();
            this.createCategoryBtn = new System.Windows.Forms.Button();
            this.editCategoryBtn = new System.Windows.Forms.Button();
            this.returnBtn = new System.Windows.Forms.Button();
            this.categoriesComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.newDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.deleteCategoryBtn = new System.Windows.Forms.Button();
            this.navbar1 = new FinanceApp.Forms.Navbar();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // nameOfCatTextBox
            // 
            resources.ApplyResources(this.nameOfCatTextBox, "nameOfCatTextBox");
            this.nameOfCatTextBox.Name = "nameOfCatTextBox";
            // 
            // descOfCatTextBox
            // 
            resources.ApplyResources(this.descOfCatTextBox, "descOfCatTextBox");
            this.descOfCatTextBox.Name = "descOfCatTextBox";
            // 
            // createCategoryBtn
            // 
            resources.ApplyResources(this.createCategoryBtn, "createCategoryBtn");
            this.createCategoryBtn.Name = "createCategoryBtn";
            this.createCategoryBtn.UseVisualStyleBackColor = true;
            this.createCategoryBtn.Click += new System.EventHandler(this.createCategoryBtn_Click);
            // 
            // editCategoryBtn
            // 
            resources.ApplyResources(this.editCategoryBtn, "editCategoryBtn");
            this.editCategoryBtn.Name = "editCategoryBtn";
            this.editCategoryBtn.UseVisualStyleBackColor = true;
            this.editCategoryBtn.Click += new System.EventHandler(this.editCategoryBtn_Click);
            // 
            // returnBtn
            // 
            resources.ApplyResources(this.returnBtn, "returnBtn");
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // categoriesComboBox
            // 
            resources.ApplyResources(this.categoriesComboBox, "categoriesComboBox");
            this.categoriesComboBox.FormattingEnabled = true;
            this.categoriesComboBox.Name = "categoriesComboBox";
            this.categoriesComboBox.SelectedIndexChanged += new System.EventHandler(this.categoriesComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // newDescriptionTextBox
            // 
            resources.ApplyResources(this.newDescriptionTextBox, "newDescriptionTextBox");
            this.newDescriptionTextBox.Name = "newDescriptionTextBox";
            this.newDescriptionTextBox.TextChanged += new System.EventHandler(this.newDescriptionTextBox_TextChanged);
            // 
            // newNameTextBox
            // 
            resources.ApplyResources(this.newNameTextBox, "newNameTextBox");
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.TextChanged += new System.EventHandler(this.newNameTextBox_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // deleteCategoryBtn
            // 
            resources.ApplyResources(this.deleteCategoryBtn, "deleteCategoryBtn");
            this.deleteCategoryBtn.Name = "deleteCategoryBtn";
            this.deleteCategoryBtn.UseVisualStyleBackColor = true;
            this.deleteCategoryBtn.Click += new System.EventHandler(this.deleteCategoryBtn_Click);
            // 
            // navbar1
            // 
            resources.ApplyResources(this.navbar1, "navbar1");
            this.navbar1.Name = "navbar1";
            // 
            // CategoryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navbar1);
            this.Controls.Add(this.deleteCategoryBtn);
            this.Controls.Add(this.categoriesComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.newDescriptionTextBox);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.editCategoryBtn);
            this.Controls.Add(this.createCategoryBtn);
            this.Controls.Add(this.descOfCatTextBox);
            this.Controls.Add(this.nameOfCatTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CategoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameOfCatTextBox;
        private System.Windows.Forms.TextBox descOfCatTextBox;
        private System.Windows.Forms.Button createCategoryBtn;
        private System.Windows.Forms.Button editCategoryBtn;
        private System.Windows.Forms.Button returnBtn;
        private System.Windows.Forms.ComboBox categoriesComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox newDescriptionTextBox;
        private System.Windows.Forms.TextBox newNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button deleteCategoryBtn;
        private Navbar navbar1;
    }
}