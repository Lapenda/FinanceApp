namespace FinanceApp.Forms
{
    partial class Navbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Navbar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.transactionsBtn = new System.Windows.Forms.Button();
            this.finGoalsBtn = new System.Windows.Forms.Button();
            this.dasboardBtn = new System.Windows.Forms.Button();
            this.categoryBtn = new System.Windows.Forms.Button();
            this.budgeBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.settingsBtn);
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Controls.Add(this.transactionsBtn);
            this.panel1.Controls.Add(this.finGoalsBtn);
            this.panel1.Controls.Add(this.dasboardBtn);
            this.panel1.Controls.Add(this.categoryBtn);
            this.panel1.Controls.Add(this.budgeBtn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // settingsBtn
            // 
            resources.ApplyResources(this.settingsBtn, "settingsBtn");
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.ForeColor = System.Drawing.Color.IndianRed;
            resources.ApplyResources(this.logoutBtn, "logoutBtn");
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // transactionsBtn
            // 
            resources.ApplyResources(this.transactionsBtn, "transactionsBtn");
            this.transactionsBtn.Name = "transactionsBtn";
            this.transactionsBtn.UseVisualStyleBackColor = true;
            this.transactionsBtn.Click += new System.EventHandler(this.transactionsBtn_Click);
            // 
            // finGoalsBtn
            // 
            resources.ApplyResources(this.finGoalsBtn, "finGoalsBtn");
            this.finGoalsBtn.Name = "finGoalsBtn";
            this.finGoalsBtn.UseVisualStyleBackColor = true;
            this.finGoalsBtn.Click += new System.EventHandler(this.finGoalsBtn_Click);
            // 
            // dasboardBtn
            // 
            resources.ApplyResources(this.dasboardBtn, "dasboardBtn");
            this.dasboardBtn.Name = "dasboardBtn";
            this.dasboardBtn.UseVisualStyleBackColor = true;
            this.dasboardBtn.Click += new System.EventHandler(this.dasboardBtn_Click);
            // 
            // categoryBtn
            // 
            resources.ApplyResources(this.categoryBtn, "categoryBtn");
            this.categoryBtn.Name = "categoryBtn";
            this.categoryBtn.UseVisualStyleBackColor = true;
            this.categoryBtn.Click += new System.EventHandler(this.categoryBtn_Click);
            // 
            // budgeBtn
            // 
            resources.ApplyResources(this.budgeBtn, "budgeBtn");
            this.budgeBtn.Name = "budgeBtn";
            this.budgeBtn.UseVisualStyleBackColor = true;
            this.budgeBtn.Click += new System.EventHandler(this.budgeBtn_Click);
            // 
            // Navbar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Navbar";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button transactionsBtn;
        private System.Windows.Forms.Button finGoalsBtn;
        private System.Windows.Forms.Button dasboardBtn;
        private System.Windows.Forms.Button categoryBtn;
        private System.Windows.Forms.Button budgeBtn;
        private System.Windows.Forms.Button settingsBtn;
    }
}
