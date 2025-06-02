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
            this.startAnalysisBtn = new System.Windows.Forms.Button();
            this.expensesLabel = new System.Windows.Forms.Label();
            this.goalsProgressLabel = new System.Windows.Forms.Label();
            this.summaryTextBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.navbar1 = new FinanceApp.Forms.Navbar();
            this.viewPdfBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startAnalysisBtn
            // 
            this.startAnalysisBtn.Location = new System.Drawing.Point(605, 582);
            this.startAnalysisBtn.Name = "startAnalysisBtn";
            this.startAnalysisBtn.Size = new System.Drawing.Size(174, 48);
            this.startAnalysisBtn.TabIndex = 0;
            this.startAnalysisBtn.Text = "Start analysis";
            this.startAnalysisBtn.UseVisualStyleBackColor = true;
            this.startAnalysisBtn.Click += new System.EventHandler(this.startAnalysisBtn_Click);
            // 
            // expensesLabel
            // 
            this.expensesLabel.AutoSize = true;
            this.expensesLabel.Location = new System.Drawing.Point(556, 94);
            this.expensesLabel.Name = "expensesLabel";
            this.expensesLabel.Size = new System.Drawing.Size(205, 20);
            this.expensesLabel.TabIndex = 1;
            this.expensesLabel.Text = "Total expenses by category:";
            // 
            // goalsProgressLabel
            // 
            this.goalsProgressLabel.AutoSize = true;
            this.goalsProgressLabel.Location = new System.Drawing.Point(947, 94);
            this.goalsProgressLabel.Name = "goalsProgressLabel";
            this.goalsProgressLabel.Size = new System.Drawing.Size(121, 20);
            this.goalsProgressLabel.TabIndex = 2;
            this.goalsProgressLabel.Text = "Goals progress:";
            // 
            // summaryTextBox
            // 
            this.summaryTextBox.Location = new System.Drawing.Point(37, 94);
            this.summaryTextBox.Multiline = true;
            this.summaryTextBox.Name = "summaryTextBox";
            this.summaryTextBox.ReadOnly = true;
            this.summaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.summaryTextBox.Size = new System.Drawing.Size(424, 425);
            this.summaryTextBox.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(90, 595);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(307, 35);
            this.progressBar.TabIndex = 4;
            // 
            // navbar1
            // 
            this.navbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbar1.Location = new System.Drawing.Point(0, 0);
            this.navbar1.MinimumSize = new System.Drawing.Size(1430, 0);
            this.navbar1.Name = "navbar1";
            this.navbar1.Size = new System.Drawing.Size(2884, 83);
            this.navbar1.TabIndex = 6;
            // 
            // viewPdfBtn
            // 
            this.viewPdfBtn.Location = new System.Drawing.Point(852, 582);
            this.viewPdfBtn.Name = "viewPdfBtn";
            this.viewPdfBtn.Size = new System.Drawing.Size(116, 47);
            this.viewPdfBtn.TabIndex = 7;
            this.viewPdfBtn.Text = "View PDF";
            this.viewPdfBtn.UseVisualStyleBackColor = true;
            this.viewPdfBtn.Click += new System.EventHandler(this.viewPdfBtn_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2884, 1590);
            this.Controls.Add(this.viewPdfBtn);
            this.Controls.Add(this.navbar1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.summaryTextBox);
            this.Controls.Add(this.goalsProgressLabel);
            this.Controls.Add(this.expensesLabel);
            this.Controls.Add(this.startAnalysisBtn);
            this.MinimumSize = new System.Drawing.Size(1430, 750);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
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
    }
}