namespace FinanceApp.Forms
{
    partial class AllTransactionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllTransactionsForm));
            this.transDataGridView = new System.Windows.Forms.DataGridView();
            this.returnBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.editBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.sortBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.sortByComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.calculatedTextBox = new System.Windows.Forms.TextBox();
            this.receiptPictureBox = new System.Windows.Forms.PictureBox();
            this.uploadReceiptBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // transDataGridView
            // 
            resources.ApplyResources(this.transDataGridView, "transDataGridView");
            this.transDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transDataGridView.MultiSelect = false;
            this.transDataGridView.Name = "transDataGridView";
            this.transDataGridView.ReadOnly = true;
            this.transDataGridView.RowTemplate.Height = 28;
            this.transDataGridView.SelectionChanged += new System.EventHandler(this.transDataGridView_SelectionChanged);
            // 
            // returnBtn
            // 
            resources.ApplyResources(this.returnBtn, "returnBtn");
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
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
            // amountTextBox
            // 
            resources.ApplyResources(this.amountTextBox, "amountTextBox");
            this.amountTextBox.Name = "amountTextBox";
            // 
            // descTextBox
            // 
            resources.ApplyResources(this.descTextBox, "descTextBox");
            this.descTextBox.Name = "descTextBox";
            // 
            // categoryComboBox
            // 
            resources.ApplyResources(this.categoryComboBox, "categoryComboBox");
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Name = "categoryComboBox";
            // 
            // currencyComboBox
            // 
            resources.ApplyResources(this.currencyComboBox, "currencyComboBox");
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Name = "currencyComboBox";
            // 
            // dateTimePicker
            // 
            resources.ApplyResources(this.dateTimePicker, "dateTimePicker");
            this.dateTimePicker.Name = "dateTimePicker";
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
            // sortBtn
            // 
            resources.ApplyResources(this.sortBtn, "sortBtn");
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.sortBtn_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // sortByComboBox
            // 
            resources.ApplyResources(this.sortByComboBox, "sortByComboBox");
            this.sortByComboBox.FormattingEnabled = true;
            this.sortByComboBox.Name = "sortByComboBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // filterTextBox
            // 
            resources.ApplyResources(this.filterTextBox, "filterTextBox");
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // calculatedTextBox
            // 
            resources.ApplyResources(this.calculatedTextBox, "calculatedTextBox");
            this.calculatedTextBox.Name = "calculatedTextBox";
            this.calculatedTextBox.ReadOnly = true;
            this.calculatedTextBox.TextChanged += new System.EventHandler(this.calculatedTextBox_TextChanged);
            // 
            // receiptPictureBox
            // 
            resources.ApplyResources(this.receiptPictureBox, "receiptPictureBox");
            this.receiptPictureBox.Name = "receiptPictureBox";
            this.receiptPictureBox.TabStop = false;
            // 
            // uploadReceiptBtn
            // 
            resources.ApplyResources(this.uploadReceiptBtn, "uploadReceiptBtn");
            this.uploadReceiptBtn.Name = "uploadReceiptBtn";
            this.uploadReceiptBtn.UseVisualStyleBackColor = true;
            this.uploadReceiptBtn.Click += new System.EventHandler(this.uploadReceiptBtn_Click);
            // 
            // AllTransactionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadReceiptBtn);
            this.Controls.Add(this.receiptPictureBox);
            this.Controls.Add(this.calculatedTextBox);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sortByComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sortBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.transDataGridView);
            this.Name = "AllTransactionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.transDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView transDataGridView;
        private System.Windows.Forms.Button returnBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox currencyComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button sortBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox sortByComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.TextBox calculatedTextBox;
        private System.Windows.Forms.PictureBox receiptPictureBox;
        private System.Windows.Forms.Button uploadReceiptBtn;
    }
}