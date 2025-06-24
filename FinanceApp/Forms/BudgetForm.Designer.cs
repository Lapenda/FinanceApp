namespace FinanceApp.Forms
{
    partial class BudgetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BudgetForm));
            this.label1 = new System.Windows.Forms.Label();
            this.remainingBudgetLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.reportButton = new System.Windows.Forms.Button();
            this.navbar1 = new FinanceApp.Forms.Navbar();
            this.addBudgetBtn = new System.Windows.Forms.Button();
            this.editBudgetBtn = new System.Windows.Forms.Button();
            this.delBudgetBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.spentTextBox = new System.Windows.Forms.TextBox();
            this.limitTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // remainingBudgetLabel
            // 
            resources.ApplyResources(this.remainingBudgetLabel, "remainingBudgetLabel");
            this.remainingBudgetLabel.Name = "remainingBudgetLabel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // categoryComboBox
            // 
            resources.ApplyResources(this.categoryComboBox, "categoryComboBox");
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // reportButton
            // 
            resources.ApplyResources(this.reportButton, "reportButton");
            this.reportButton.Name = "reportButton";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // navbar1
            // 
            resources.ApplyResources(this.navbar1, "navbar1");
            this.navbar1.Name = "navbar1";
            // 
            // addBudgetBtn
            // 
            resources.ApplyResources(this.addBudgetBtn, "addBudgetBtn");
            this.addBudgetBtn.Name = "addBudgetBtn";
            this.addBudgetBtn.UseVisualStyleBackColor = true;
            this.addBudgetBtn.Click += new System.EventHandler(this.addBudgetBtn_Click);
            // 
            // editBudgetBtn
            // 
            resources.ApplyResources(this.editBudgetBtn, "editBudgetBtn");
            this.editBudgetBtn.Name = "editBudgetBtn";
            this.editBudgetBtn.UseVisualStyleBackColor = true;
            this.editBudgetBtn.Click += new System.EventHandler(this.editBudgetBtn_Click);
            // 
            // delBudgetBtn
            // 
            resources.ApplyResources(this.delBudgetBtn, "delBudgetBtn");
            this.delBudgetBtn.Name = "delBudgetBtn";
            this.delBudgetBtn.UseVisualStyleBackColor = true;
            this.delBudgetBtn.Click += new System.EventHandler(this.delBudgetBtn_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // categoryTextBox
            // 
            resources.ApplyResources(this.categoryTextBox, "categoryTextBox");
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.ReadOnly = true;
            // 
            // spentTextBox
            // 
            resources.ApplyResources(this.spentTextBox, "spentTextBox");
            this.spentTextBox.Name = "spentTextBox";
            // 
            // limitTextBox
            // 
            resources.ApplyResources(this.limitTextBox, "limitTextBox");
            this.limitTextBox.Name = "limitTextBox";
            // 
            // BudgetForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.limitTextBox);
            this.Controls.Add(this.spentTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.delBudgetBtn);
            this.Controls.Add(this.editBudgetBtn);
            this.Controls.Add(this.addBudgetBtn);
            this.Controls.Add(this.navbar1);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.remainingBudgetLabel);
            this.Controls.Add(this.label1);
            this.Name = "BudgetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label remainingBudgetLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button reportButton;
        private Navbar navbar1;
        private System.Windows.Forms.Button addBudgetBtn;
        private System.Windows.Forms.Button editBudgetBtn;
        private System.Windows.Forms.Button delBudgetBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox spentTextBox;
        private System.Windows.Forms.TextBox limitTextBox;
    }
}