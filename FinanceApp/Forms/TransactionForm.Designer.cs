namespace FinanceApp.Forms
{
    partial class TransactionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.editCategoriesBtn = new System.Windows.Forms.Button();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.budgetLabel = new System.Windows.Forms.Label();
            this.navbar1 = new FinanceApp.Forms.Navbar();
            this.seeTransBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // welcomeLabel
            // 
            resources.ApplyResources(this.welcomeLabel, "welcomeLabel");
            this.welcomeLabel.Name = "welcomeLabel";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.categoryComboBox, "categoryComboBox");
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // amountTextBox
            // 
            resources.ApplyResources(this.amountTextBox, "amountTextBox");
            this.amountTextBox.Name = "amountTextBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // datePicker
            // 
            resources.ApplyResources(this.datePicker, "datePicker");
            this.datePicker.Name = "datePicker";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editCategoriesBtn
            // 
            resources.ApplyResources(this.editCategoriesBtn, "editCategoriesBtn");
            this.editCategoriesBtn.Name = "editCategoriesBtn";
            this.editCategoriesBtn.UseVisualStyleBackColor = true;
            this.editCategoriesBtn.Click += new System.EventHandler(this.editCategoriesBtn_Click);
            // 
            // descTextBox
            // 
            resources.ApplyResources(this.descTextBox, "descTextBox");
            this.descTextBox.Name = "descTextBox";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // budgetLabel
            // 
            resources.ApplyResources(this.budgetLabel, "budgetLabel");
            this.budgetLabel.Name = "budgetLabel";
            // 
            // navbar1
            // 
            resources.ApplyResources(this.navbar1, "navbar1");
            this.navbar1.Name = "navbar1";
            // 
            // seeTransBtn
            // 
            resources.ApplyResources(this.seeTransBtn, "seeTransBtn");
            this.seeTransBtn.Name = "seeTransBtn";
            this.seeTransBtn.UseVisualStyleBackColor = true;
            this.seeTransBtn.Click += new System.EventHandler(this.seeTransBtn_Click);
            // 
            // TransactionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.seeTransBtn);
            this.Controls.Add(this.budgetLabel);
            this.Controls.Add(this.navbar1);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.editCategoriesBtn);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.label1);
            this.Name = "TransactionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button editCategoriesBtn;
        private System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.Label label6;
        private Navbar navbar1;
        private System.Windows.Forms.Label budgetLabel;
        private System.Windows.Forms.Button seeTransBtn;
    }
}