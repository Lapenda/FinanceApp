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
            ((System.ComponentModel.ISupportInitialize)(this.goalsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // goalsDataGridView
            // 
            this.goalsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goalsDataGridView.Location = new System.Drawing.Point(294, 75);
            this.goalsDataGridView.Name = "goalsDataGridView";
            this.goalsDataGridView.RowHeadersWidth = 62;
            this.goalsDataGridView.RowTemplate.Height = 28;
            this.goalsDataGridView.Size = new System.Drawing.Size(839, 280);
            this.goalsDataGridView.TabIndex = 0;
            this.goalsDataGridView.SelectionChanged += new System.EventHandler(this.goalsDataGridView_SelectionChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(196, 402);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(91, 20);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Goal name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(583, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1016, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target amount:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(294, 402);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(238, 26);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // curAmountTextBox
            // 
            this.curAmountTextBox.Location = new System.Drawing.Point(713, 402);
            this.curAmountTextBox.Name = "curAmountTextBox";
            this.curAmountTextBox.Size = new System.Drawing.Size(238, 26);
            this.curAmountTextBox.TabIndex = 5;
            this.curAmountTextBox.TextChanged += new System.EventHandler(this.curAmountTextBox_TextChanged);
            // 
            // tarAmountTextBox
            // 
            this.tarAmountTextBox.Location = new System.Drawing.Point(1139, 402);
            this.tarAmountTextBox.Name = "tarAmountTextBox";
            this.tarAmountTextBox.Size = new System.Drawing.Size(238, 26);
            this.tarAmountTextBox.TabIndex = 6;
            this.tarAmountTextBox.TextChanged += new System.EventHandler(this.tarAmountTextBox_TextChanged);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(294, 557);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(145, 40);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "Add Goal";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(645, 557);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(145, 40);
            this.editBtn.TabIndex = 8;
            this.editBtn.Text = "Edit Goal";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(988, 557);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(145, 40);
            this.delBtn.TabIndex = 9;
            this.delBtn.Text = "Delete Goal";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // clrTextBtn
            // 
            this.clrTextBtn.Location = new System.Drawing.Point(645, 473);
            this.clrTextBtn.Name = "clrTextBtn";
            this.clrTextBtn.Size = new System.Drawing.Size(145, 40);
            this.clrTextBtn.TabIndex = 10;
            this.clrTextBtn.Text = "Clear text";
            this.clrTextBtn.UseVisualStyleBackColor = true;
            this.clrTextBtn.Click += new System.EventHandler(this.clrTextBtn_Click);
            // 
            // returnBtn
            // 
            this.returnBtn.Location = new System.Drawing.Point(630, 637);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(183, 43);
            this.returnBtn.TabIndex = 11;
            this.returnBtn.Text = "Return";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // FinancialGoalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 713);
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
            this.Text = "FinancialGoalsForm";
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
    }
}