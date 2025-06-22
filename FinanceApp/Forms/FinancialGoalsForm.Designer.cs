namespace FinanceApp.Forms
{
    partial class FinancialGoalsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinancialGoalsForm));
            this.goalsDataGridView = new System.Windows.Forms.DataGridView();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.curAmountTextBox = new System.Windows.Forms.TextBox();
            this.tarAmountTextBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.clrTextBtn = new System.Windows.Forms.Button();
            this.returnBtn = new System.Windows.Forms.Button();
            this.navbar1 = new FinanceApp.Forms.Navbar();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.speedComboBox = new System.Windows.Forms.ComboBox();
            this.percentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.goalsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // goalsDataGridView
            // 
            this.goalsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.goalsDataGridView, "goalsDataGridView");
            this.goalsDataGridView.Name = "goalsDataGridView";
            this.goalsDataGridView.RowTemplate.Height = 28;
            this.goalsDataGridView.SelectionChanged += new System.EventHandler(this.goalsDataGridView_SelectionChanged);
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
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
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // curAmountTextBox
            // 
            resources.ApplyResources(this.curAmountTextBox, "curAmountTextBox");
            this.curAmountTextBox.Name = "curAmountTextBox";
            this.curAmountTextBox.TextChanged += new System.EventHandler(this.curAmountTextBox_TextChanged);
            // 
            // tarAmountTextBox
            // 
            resources.ApplyResources(this.tarAmountTextBox, "tarAmountTextBox");
            this.tarAmountTextBox.Name = "tarAmountTextBox";
            this.tarAmountTextBox.TextChanged += new System.EventHandler(this.tarAmountTextBox_TextChanged);
            // 
            // addBtn
            // 
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            resources.ApplyResources(this.editBtn, "editBtn");
            this.editBtn.Name = "editBtn";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // delBtn
            // 
            resources.ApplyResources(this.delBtn, "delBtn");
            this.delBtn.Name = "delBtn";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // clrTextBtn
            // 
            resources.ApplyResources(this.clrTextBtn, "clrTextBtn");
            this.clrTextBtn.Name = "clrTextBtn";
            this.clrTextBtn.UseVisualStyleBackColor = true;
            this.clrTextBtn.Click += new System.EventHandler(this.clrTextBtn_Click);
            // 
            // returnBtn
            // 
            resources.ApplyResources(this.returnBtn, "returnBtn");
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // navbar1
            // 
            resources.ApplyResources(this.navbar1, "navbar1");
            this.navbar1.Name = "navbar1";
            // 
            // downloadBtn
            // 
            resources.ApplyResources(this.downloadBtn, "downloadBtn");
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // speedComboBox
            // 
            this.speedComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.speedComboBox, "speedComboBox");
            this.speedComboBox.Name = "speedComboBox";
            // 
            // percentLabel
            // 
            resources.ApplyResources(this.percentLabel, "percentLabel");
            this.percentLabel.Name = "percentLabel";
            // 
            // FinancialGoalsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.speedComboBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.navbar1);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.clrTextBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.tarAmountTextBox);
            this.Controls.Add(this.curAmountTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.goalsDataGridView);
            this.Name = "FinancialGoalsForm";
            ((System.ComponentModel.ISupportInitialize)(this.goalsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView goalsDataGridView;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox curAmountTextBox;
        private System.Windows.Forms.TextBox tarAmountTextBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button clrTextBtn;
        private System.Windows.Forms.Button returnBtn;
        private Navbar navbar1;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox speedComboBox;
        private System.Windows.Forms.Label percentLabel;
    }
}