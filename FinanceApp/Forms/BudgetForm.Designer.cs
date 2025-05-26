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
            this.finGoalsBtn = new System.Windows.Forms.Button();
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
            this.categoryComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.categoryComboBox, "categoryComboBox");
            this.categoryComboBox.Name = "categoryComboBox";
            // 
            // reportButton
            // 
            resources.ApplyResources(this.reportButton, "reportButton");
            this.reportButton.Name = "reportButton";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // finGoalsBtn
            // 
            resources.ApplyResources(this.finGoalsBtn, "finGoalsBtn");
            this.finGoalsBtn.Name = "finGoalsBtn";
            this.finGoalsBtn.UseVisualStyleBackColor = true;
            this.finGoalsBtn.Click += new System.EventHandler(this.finGoalsBtn_Click);
            // 
            // BudgetForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.finGoalsBtn);
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
        private System.Windows.Forms.Button finGoalsBtn;
    }
}