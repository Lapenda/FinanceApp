namespace FinanceApp.Forms
{
    partial class AdminForm
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
            this.navbar1 = new FinanceApp.Forms.Navbar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adminNameTxtBox = new System.Windows.Forms.TextBox();
            this.adminLastNameTxtBox = new System.Windows.Forms.TextBox();
            this.editBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userLastNameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.userRoleComboBox = new System.Windows.Forms.ComboBox();
            this.editUserBtn = new System.Windows.Forms.Button();
            this.delUserBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // navbar1
            // 
            this.navbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbar1.Location = new System.Drawing.Point(0, 0);
            this.navbar1.Name = "navbar1";
            this.navbar1.Size = new System.Drawing.Size(1428, 55);
            this.navbar1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(324, 85);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(769, 571);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "First name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last name:";
            // 
            // adminNameTxtBox
            // 
            this.adminNameTxtBox.Location = new System.Drawing.Point(106, 156);
            this.adminNameTxtBox.Name = "adminNameTxtBox";
            this.adminNameTxtBox.Size = new System.Drawing.Size(198, 26);
            this.adminNameTxtBox.TabIndex = 4;
            // 
            // adminLastNameTxtBox
            // 
            this.adminLastNameTxtBox.Location = new System.Drawing.Point(106, 214);
            this.adminLastNameTxtBox.Name = "adminLastNameTxtBox";
            this.adminLastNameTxtBox.Size = new System.Drawing.Size(198, 26);
            this.adminLastNameTxtBox.TabIndex = 5;
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(106, 292);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(108, 45);
            this.editBtn.TabIndex = 6;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1099, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "First name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Admin pane:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1188, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Users pane:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1099, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Last name:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(1193, 250);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(221, 26);
            this.userNameTextBox.TabIndex = 11;
            // 
            // userLastNameTextBox
            // 
            this.userLastNameTextBox.Location = new System.Drawing.Point(1193, 314);
            this.userLastNameTextBox.Name = "userLastNameTextBox";
            this.userLastNameTextBox.Size = new System.Drawing.Size(221, 26);
            this.userLastNameTextBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1141, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Role:";
            // 
            // userRoleComboBox
            // 
            this.userRoleComboBox.FormattingEnabled = true;
            this.userRoleComboBox.Location = new System.Drawing.Point(1194, 386);
            this.userRoleComboBox.Name = "userRoleComboBox";
            this.userRoleComboBox.Size = new System.Drawing.Size(220, 28);
            this.userRoleComboBox.TabIndex = 15;
            // 
            // editUserBtn
            // 
            this.editUserBtn.Location = new System.Drawing.Point(1192, 490);
            this.editUserBtn.Name = "editUserBtn";
            this.editUserBtn.Size = new System.Drawing.Size(144, 45);
            this.editUserBtn.TabIndex = 16;
            this.editUserBtn.Text = "Edit User";
            this.editUserBtn.UseVisualStyleBackColor = true;
            this.editUserBtn.Click += new System.EventHandler(this.editUserBtn_Click);
            // 
            // delUserBtn
            // 
            this.delUserBtn.Location = new System.Drawing.Point(1192, 591);
            this.delUserBtn.Name = "delUserBtn";
            this.delUserBtn.Size = new System.Drawing.Size(144, 45);
            this.delUserBtn.TabIndex = 17;
            this.delUserBtn.Text = "Delete User";
            this.delUserBtn.UseVisualStyleBackColor = true;
            this.delUserBtn.Click += new System.EventHandler(this.delUserBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1123, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Search:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(1194, 111);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(220, 26);
            this.searchTextBox.TabIndex = 20;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 694);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.delUserBtn);
            this.Controls.Add(this.editUserBtn);
            this.Controls.Add(this.userRoleComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.userLastNameTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.adminLastNameTxtBox);
            this.Controls.Add(this.adminNameTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.navbar1);
            this.MinimumSize = new System.Drawing.Size(1450, 750);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Navbar navbar1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox adminNameTxtBox;
        private System.Windows.Forms.TextBox adminLastNameTxtBox;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox userLastNameTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox userRoleComboBox;
        private System.Windows.Forms.Button editUserBtn;
        private System.Windows.Forms.Button delUserBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}