namespace CurrencyDLL
{
    partial class CurrencyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyForm));
            this.searchBtn = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.returnBtn = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currFromTextBox = new System.Windows.Forms.TextBox();
            this.currToTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.calcBtn = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchBtn
            // 
            resources.ApplyResources(this.searchBtn, "searchBtn");
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // textBox
            // 
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // returnBtn
            // 
            resources.ApplyResources(this.returnBtn, "returnBtn");
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // resultLabel
            // 
            resources.ApplyResources(this.resultLabel, "resultLabel");
            this.resultLabel.Name = "resultLabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // currFromTextBox
            // 
            resources.ApplyResources(this.currFromTextBox, "currFromTextBox");
            this.currFromTextBox.Name = "currFromTextBox";
            // 
            // currToTextBox
            // 
            resources.ApplyResources(this.currToTextBox, "currToTextBox");
            this.currToTextBox.Name = "currToTextBox";
            // 
            // resultTextBox
            // 
            resources.ApplyResources(this.resultTextBox, "resultTextBox");
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // amountTextBox
            // 
            resources.ApplyResources(this.amountTextBox, "amountTextBox");
            this.amountTextBox.Name = "amountTextBox";
            // 
            // calcBtn
            // 
            resources.ApplyResources(this.calcBtn, "calcBtn");
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.UseVisualStyleBackColor = true;
            this.calcBtn.Click += new System.EventHandler(this.calcBtn_Click);
            // 
            // dateLabel
            // 
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.Name = "dateLabel";
            // 
            // CurrencyForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.calcBtn);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.currToTextBox);
            this.Controls.Add(this.currFromTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Name = "CurrencyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button returnBtn;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox currFromTextBox;
        private System.Windows.Forms.TextBox currToTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.Label dateLabel;
    }
}