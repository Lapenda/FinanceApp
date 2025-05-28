namespace FinanceApp.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.backButton = new System.Windows.Forms.Button();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageComboLabel = new System.Windows.Forms.Label();
            this.applyLanguage = new System.Windows.Forms.Button();
            this.themeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // backButton
            // 
            resources.ApplyResources(this.backButton, "backButton");
            this.backButton.Name = "backButton";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // languageComboBox
            // 
            this.languageComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.languageComboBox, "languageComboBox");
            this.languageComboBox.Name = "languageComboBox";
            // 
            // languageComboLabel
            // 
            resources.ApplyResources(this.languageComboLabel, "languageComboLabel");
            this.languageComboLabel.Name = "languageComboLabel";
            // 
            // applyLanguage
            // 
            resources.ApplyResources(this.applyLanguage, "applyLanguage");
            this.applyLanguage.Name = "applyLanguage";
            this.applyLanguage.UseVisualStyleBackColor = true;
            this.applyLanguage.Click += new System.EventHandler(this.applyLanguage_Click);
            // 
            // themeComboBox
            // 
            this.themeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.themeComboBox, "themeComboBox");
            this.themeComboBox.Name = "themeComboBox";
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
            // currencyComboBox
            // 
            this.currencyComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.currencyComboBox, "currencyComboBox");
            this.currencyComboBox.Name = "currencyComboBox";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.themeComboBox);
            this.Controls.Add(this.applyLanguage);
            this.Controls.Add(this.languageComboLabel);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.backButton);
            this.Name = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageComboLabel;
        private System.Windows.Forms.Button applyLanguage;
        private System.Windows.Forms.ComboBox themeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox currencyComboBox;
    }
}