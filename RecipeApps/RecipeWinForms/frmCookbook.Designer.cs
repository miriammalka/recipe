namespace RecipeWinForms
{
    partial class frmCookbook
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
            tblMain = new TableLayoutPanel();
            tblRecipes = new TableLayoutPanel();
            btnSaveCookbookRecipe = new Button();
            gRecipes = new DataGridView();
            tblCookbook = new TableLayoutPanel();
            lblCookbookName = new Label();
            lblUser = new Label();
            lblPrice = new Label();
            lblActive = new Label();
            btnSaveCookbook = new Button();
            btnDeleteCookbook = new Button();
            txtCookbookName = new TextBox();
            lstUsers = new ComboBox();
            tblPrice = new TableLayoutPanel();
            txtPrice = new TextBox();
            txtDateCreated = new TextBox();
            chkActive = new CheckBox();
            tblDateCreated = new TableLayoutPanel();
            lblDateCreated = new Label();
            tblMain.SuspendLayout();
            tblRecipes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).BeginInit();
            tblCookbook.SuspendLayout();
            tblPrice.SuspendLayout();
            tblDateCreated.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblMain.Controls.Add(tblRecipes, 0, 1);
            tblMain.Controls.Add(tblCookbook, 0, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(807, 670);
            tblMain.TabIndex = 0;
            // 
            // tblRecipes
            // 
            tblRecipes.ColumnCount = 1;
            tblRecipes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRecipes.Controls.Add(btnSaveCookbookRecipe, 0, 0);
            tblRecipes.Controls.Add(gRecipes, 0, 1);
            tblRecipes.Dock = DockStyle.Fill;
            tblRecipes.Location = new Point(3, 338);
            tblRecipes.Name = "tblRecipes";
            tblRecipes.RowCount = 2;
            tblRecipes.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblRecipes.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tblRecipes.Size = new Size(801, 329);
            tblRecipes.TabIndex = 0;
            // 
            // btnSaveCookbookRecipe
            // 
            btnSaveCookbookRecipe.Location = new Point(3, 3);
            btnSaveCookbookRecipe.Name = "btnSaveCookbookRecipe";
            btnSaveCookbookRecipe.Size = new Size(94, 43);
            btnSaveCookbookRecipe.TabIndex = 0;
            btnSaveCookbookRecipe.Text = "Save";
            btnSaveCookbookRecipe.UseVisualStyleBackColor = true;
            // 
            // gRecipes
            // 
            gRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipes.Dock = DockStyle.Fill;
            gRecipes.Location = new Point(3, 52);
            gRecipes.Name = "gRecipes";
            gRecipes.RowHeadersWidth = 51;
            gRecipes.RowTemplate.Height = 29;
            gRecipes.Size = new Size(795, 274);
            gRecipes.TabIndex = 1;
            // 
            // tblCookbook
            // 
            tblCookbook.ColumnCount = 2;
            tblCookbook.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblCookbook.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblCookbook.Controls.Add(lblCookbookName, 0, 1);
            tblCookbook.Controls.Add(lblUser, 0, 2);
            tblCookbook.Controls.Add(lblPrice, 0, 4);
            tblCookbook.Controls.Add(lblActive, 0, 5);
            tblCookbook.Controls.Add(btnSaveCookbook, 0, 0);
            tblCookbook.Controls.Add(btnDeleteCookbook, 1, 0);
            tblCookbook.Controls.Add(txtCookbookName, 1, 1);
            tblCookbook.Controls.Add(lstUsers, 1, 2);
            tblCookbook.Controls.Add(tblPrice, 1, 4);
            tblCookbook.Controls.Add(chkActive, 1, 5);
            tblCookbook.Controls.Add(tblDateCreated, 1, 3);
            tblCookbook.Dock = DockStyle.Fill;
            tblCookbook.Location = new Point(3, 3);
            tblCookbook.Name = "tblCookbook";
            tblCookbook.RowCount = 6;
            tblCookbook.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblCookbook.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblCookbook.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblCookbook.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblCookbook.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblCookbook.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblCookbook.Size = new Size(801, 329);
            tblCookbook.TabIndex = 1;
            // 
            // lblCookbookName
            // 
            lblCookbookName.AutoSize = true;
            lblCookbookName.Dock = DockStyle.Fill;
            lblCookbookName.Location = new Point(3, 54);
            lblCookbookName.Name = "lblCookbookName";
            lblCookbookName.Size = new Size(234, 54);
            lblCookbookName.TabIndex = 1;
            lblCookbookName.Text = "Cookbook Name";
            lblCookbookName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(3, 108);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(234, 54);
            lblUser.TabIndex = 2;
            lblUser.Text = "User";
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Dock = DockStyle.Fill;
            lblPrice.Location = new Point(3, 216);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(234, 54);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price";
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Dock = DockStyle.Fill;
            lblActive.Location = new Point(3, 270);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(234, 59);
            lblActive.TabIndex = 4;
            lblActive.Text = "Active";
            lblActive.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSaveCookbook
            // 
            btnSaveCookbook.Location = new Point(3, 3);
            btnSaveCookbook.Name = "btnSaveCookbook";
            btnSaveCookbook.Size = new Size(158, 48);
            btnSaveCookbook.TabIndex = 5;
            btnSaveCookbook.Text = "Save";
            btnSaveCookbook.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCookbook
            // 
            btnDeleteCookbook.Location = new Point(243, 3);
            btnDeleteCookbook.Name = "btnDeleteCookbook";
            btnDeleteCookbook.Size = new Size(146, 48);
            btnDeleteCookbook.TabIndex = 6;
            btnDeleteCookbook.Text = "Delete";
            btnDeleteCookbook.UseVisualStyleBackColor = true;
            // 
            // txtCookbookName
            // 
            txtCookbookName.Dock = DockStyle.Fill;
            txtCookbookName.Location = new Point(243, 57);
            txtCookbookName.Name = "txtCookbookName";
            txtCookbookName.Size = new Size(555, 27);
            txtCookbookName.TabIndex = 7;
            // 
            // lstUsers
            // 
            lstUsers.Dock = DockStyle.Fill;
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(243, 111);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(555, 28);
            lstUsers.TabIndex = 8;
            // 
            // tblPrice
            // 
            tblPrice.ColumnCount = 2;
            tblPrice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPrice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPrice.Controls.Add(txtPrice, 0, 0);
            tblPrice.Controls.Add(txtDateCreated, 1, 0);
            tblPrice.Dock = DockStyle.Fill;
            tblPrice.Location = new Point(243, 219);
            tblPrice.Name = "tblPrice";
            tblPrice.RowCount = 1;
            tblPrice.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblPrice.Size = new Size(555, 48);
            tblPrice.TabIndex = 10;
            // 
            // txtPrice
            // 
            txtPrice.Dock = DockStyle.Fill;
            txtPrice.Location = new Point(3, 3);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(271, 27);
            txtPrice.TabIndex = 0;
            // 
            // txtDateCreated
            // 
            txtDateCreated.Dock = DockStyle.Fill;
            txtDateCreated.Enabled = false;
            txtDateCreated.Location = new Point(280, 3);
            txtDateCreated.Name = "txtDateCreated";
            txtDateCreated.Size = new Size(272, 27);
            txtDateCreated.TabIndex = 1;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Dock = DockStyle.Fill;
            chkActive.Location = new Point(243, 273);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(555, 53);
            chkActive.TabIndex = 11;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // tblDateCreated
            // 
            tblDateCreated.ColumnCount = 2;
            tblDateCreated.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDateCreated.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDateCreated.Controls.Add(lblDateCreated, 1, 0);
            tblDateCreated.Dock = DockStyle.Fill;
            tblDateCreated.Location = new Point(243, 165);
            tblDateCreated.Name = "tblDateCreated";
            tblDateCreated.RowCount = 1;
            tblDateCreated.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDateCreated.Size = new Size(555, 48);
            tblDateCreated.TabIndex = 12;
            // 
            // lblDateCreated
            // 
            lblDateCreated.AutoSize = true;
            lblDateCreated.Dock = DockStyle.Fill;
            lblDateCreated.Location = new Point(280, 0);
            lblDateCreated.Name = "lblDateCreated";
            lblDateCreated.Size = new Size(272, 48);
            lblDateCreated.TabIndex = 9;
            lblDateCreated.Text = "Date Created";
            lblDateCreated.TextAlign = ContentAlignment.BottomCenter;
            // 
            // frmCookbook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 670);
            Controls.Add(tblMain);
            Name = "frmCookbook";
            Text = "Cookbook";
            tblMain.ResumeLayout(false);
            tblRecipes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gRecipes).EndInit();
            tblCookbook.ResumeLayout(false);
            tblCookbook.PerformLayout();
            tblPrice.ResumeLayout(false);
            tblPrice.PerformLayout();
            tblDateCreated.ResumeLayout(false);
            tblDateCreated.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblRecipes;
        private Button btnSaveRecipe;
        private DataGridView gRecipes;
        private TableLayoutPanel tblCookbook;
        private Label lblCookbookName;
        private Label lblUser;
        private Label lblPrice;
        private Label lblActive;
        private Button btnSaveCookbook;
        private Button btnDeleteCookbook;
        private TextBox txtCookbookName;
        private ComboBox lstUsers;
        private TableLayoutPanel tblPrice;
        private TextBox txtPrice;
        private TextBox txtDateCreated;
        private CheckBox chkActive;
        private TableLayoutPanel tblDateCreated;
        private Label lblDateCreated;
        private Button btnSaveCookbookRecipe;
    }
}