namespace FinanceApp.Forms
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.startAnalysisBtn = new System.Windows.Forms.Button();
            this.expensesLabel = new System.Windows.Forms.Label();
            this.goalsProgressLabel = new System.Windows.Forms.Label();
            this.summaryTextBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.viewPdfBtn = new System.Windows.Forms.Button();
            this.navbar1 = new FinanceApp.Forms.Navbar();
            this.calculateAvgTransactions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startAnalysisBtn
            // 
            resources.ApplyResources(this.startAnalysisBtn, "startAnalysisBtn");
            this.startAnalysisBtn.Name = "startAnalysisBtn";
            this.startAnalysisBtn.UseVisualStyleBackColor = true;
            this.startAnalysisBtn.Click += new System.EventHandler(this.startAnalysisBtn_Click);
            // 
            // expensesLabel
            // 
            resources.ApplyResources(this.expensesLabel, "expensesLabel");
            this.expensesLabel.Name = "expensesLabel";
            // 
            // goalsProgressLabel
            // 
            resources.ApplyResources(this.goalsProgressLabel, "goalsProgressLabel");
            this.goalsProgressLabel.Name = "goalsProgressLabel";
            // 
            // summaryTextBox
            // 
            resources.ApplyResources(this.summaryTextBox, "summaryTextBox");
            this.summaryTextBox.Name = "summaryTextBox";
            this.summaryTextBox.ReadOnly = true;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // viewPdfBtn
            // 
            resources.ApplyResources(this.viewPdfBtn, "viewPdfBtn");
            this.viewPdfBtn.Name = "viewPdfBtn";
            this.viewPdfBtn.UseVisualStyleBackColor = true;
            this.viewPdfBtn.Click += new System.EventHandler(this.viewPdfBtn_Click);
            // 
            // navbar1
            // 
            resources.ApplyResources(this.navbar1, "navbar1");
            this.navbar1.Name = "navbar1";
            // 
            // calculateAvgTransactions
            // 
            resources.ApplyResources(this.calculateAvgTransactions, "calculateAvgTransactions");
            this.calculateAvgTransactions.Name = "calculateAvgTransactions";
            this.calculateAvgTransactions.UseVisualStyleBackColor = true;
            this.calculateAvgTransactions.Click += new System.EventHandler(this.calculateAvgTransactions_Click);
            // 
            // DashboardForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calculateAvgTransactions);
            this.Controls.Add(this.viewPdfBtn);
            this.Controls.Add(this.navbar1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.summaryTextBox);
            this.Controls.Add(this.goalsProgressLabel);
            this.Controls.Add(this.expensesLabel);
            this.Controls.Add(this.startAnalysisBtn);
            this.Name = "DashboardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startAnalysisBtn;
        private System.Windows.Forms.Label expensesLabel;
        private System.Windows.Forms.Label goalsProgressLabel;
        private System.Windows.Forms.TextBox summaryTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private Navbar navbar1;
        private System.Windows.Forms.Button viewPdfBtn;
        private System.Windows.Forms.Button calculateAvgTransactions;
    }
}