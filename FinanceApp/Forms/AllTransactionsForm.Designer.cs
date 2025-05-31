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
            this.transDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transDataGridView.Location = new System.Drawing.Point(260, 26);
            this.transDataGridView.MultiSelect = false;
            this.transDataGridView.Name = "transDataGridView";
            this.transDataGridView.ReadOnly = true;
            this.transDataGridView.RowHeadersWidth = 62;
            this.transDataGridView.RowTemplate.Height = 28;
            this.transDataGridView.Size = new System.Drawing.Size(1018, 367);
            this.transDataGridView.TabIndex = 0;
            this.transDataGridView.SelectionChanged += new System.EventHandler(this.transDataGridView_SelectionChanged);
            // 
            // returnBtn
            // 
            this.returnBtn.Location = new System.Drawing.Point(569, 603);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(137, 38);
            this.returnBtn.TabIndex = 1;
            this.returnBtn.Text = "Return";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 551);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category:";
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
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 551);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Currency:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(755, 453);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Transaction Date:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(177, 450);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(187, 26);
            this.amountTextBox.TabIndex = 7;
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(177, 548);
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(187, 26);
            this.descTextBox.TabIndex = 8;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(526, 450);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(180, 28);
            this.categoryComboBox.TabIndex = 9;
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Location = new System.Drawing.Point(525, 548);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(181, 28);
            this.currencyComboBox.TabIndex = 10;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(896, 451);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker.TabIndex = 11;
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(1174, 442);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(117, 42);
            this.editBtn.TabIndex = 12;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(1174, 541);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(117, 40);
            this.delBtn.TabIndex = 13;
            this.delBtn.Text = "Delete";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // sortBtn
            // 
            this.sortBtn.Location = new System.Drawing.Point(12, 114);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(174, 45);
            this.sortBtn.TabIndex = 14;
            this.sortBtn.Text = "Sort";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.sortBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sort by:";
            // 
            // sortByComboBox
            // 
            this.sortByComboBox.FormattingEnabled = true;
            this.sortByComboBox.Location = new System.Drawing.Point(12, 59);
            this.sortByComboBox.Name = "sortByComboBox";
            this.sortByComboBox.Size = new System.Drawing.Size(174, 28);
            this.sortByComboBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Filter:";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(12, 258);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(195, 26);
            this.filterTextBox.TabIndex = 18;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // calculatedTextBox
            // 
            this.calculatedTextBox.Location = new System.Drawing.Point(12, 343);
            this.calculatedTextBox.MinimumSize = new System.Drawing.Size(4, 50);
            this.calculatedTextBox.Name = "calculatedTextBox";
            this.calculatedTextBox.ReadOnly = true;
            this.calculatedTextBox.Size = new System.Drawing.Size(195, 26);
            this.calculatedTextBox.TabIndex = 19;
            // 
            // receiptPictureBox
            // 
            this.receiptPictureBox.Location = new System.Drawing.Point(1440, 26);
            this.receiptPictureBox.Name = "receiptPictureBox";
            this.receiptPictureBox.Size = new System.Drawing.Size(470, 367);
            this.receiptPictureBox.TabIndex = 20;
            this.receiptPictureBox.TabStop = false;
            // 
            // uploadReceiptBtn
            // 
            this.uploadReceiptBtn.Location = new System.Drawing.Point(1605, 436);
            this.uploadReceiptBtn.Name = "uploadReceiptBtn";
            this.uploadReceiptBtn.Size = new System.Drawing.Size(185, 48);
            this.uploadReceiptBtn.TabIndex = 21;
            this.uploadReceiptBtn.Text = "Upload New Receipt";
            this.uploadReceiptBtn.UseVisualStyleBackColor = true;
            this.uploadReceiptBtn.Click += new System.EventHandler(this.uploadReceiptBtn_Click);
            // 
            // AllTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2078, 694);
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
            this.MinimumSize = new System.Drawing.Size(2100, 750);
            this.Name = "AllTransactionsForm";
            this.Text = "AllTransactionsForm";
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