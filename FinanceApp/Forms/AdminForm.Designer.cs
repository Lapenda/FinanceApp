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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
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
            resources.ApplyResources(this.navbar1, "navbar1");
            this.navbar1.Name = "navbar1";
            // 
            // dataGridView
            // 
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
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
            // adminNameTxtBox
            // 
            resources.ApplyResources(this.adminNameTxtBox, "adminNameTxtBox");
            this.adminNameTxtBox.Name = "adminNameTxtBox";
            // 
            // adminLastNameTxtBox
            // 
            resources.ApplyResources(this.adminLastNameTxtBox, "adminLastNameTxtBox");
            this.adminLastNameTxtBox.Name = "adminLastNameTxtBox";
            // 
            // editBtn
            // 
            resources.ApplyResources(this.editBtn, "editBtn");
            this.editBtn.Name = "editBtn";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // userNameTextBox
            // 
            resources.ApplyResources(this.userNameTextBox, "userNameTextBox");
            this.userNameTextBox.Name = "userNameTextBox";
            // 
            // userLastNameTextBox
            // 
            resources.ApplyResources(this.userLastNameTextBox, "userLastNameTextBox");
            this.userLastNameTextBox.Name = "userLastNameTextBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // userRoleComboBox
            // 
            resources.ApplyResources(this.userRoleComboBox, "userRoleComboBox");
            this.userRoleComboBox.FormattingEnabled = true;
            this.userRoleComboBox.Name = "userRoleComboBox";
            // 
            // editUserBtn
            // 
            resources.ApplyResources(this.editUserBtn, "editUserBtn");
            this.editUserBtn.Name = "editUserBtn";
            this.editUserBtn.UseVisualStyleBackColor = true;
            this.editUserBtn.Click += new System.EventHandler(this.editUserBtn_Click);
            // 
            // delUserBtn
            // 
            resources.ApplyResources(this.delUserBtn, "delUserBtn");
            this.delUserBtn.Name = "delUserBtn";
            this.delUserBtn.UseVisualStyleBackColor = true;
            this.delUserBtn.Click += new System.EventHandler(this.delUserBtn_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // searchTextBox
            // 
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // AdminForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "AdminForm";
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