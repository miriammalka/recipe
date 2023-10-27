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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblRecipes = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveCookbookRecipe = new System.Windows.Forms.Button();
            this.gRecipes = new System.Windows.Forms.DataGridView();
            this.tblCookbook = new System.Windows.Forms.TableLayoutPanel();
            this.lblCookbookName = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            this.btnSaveCookbook = new System.Windows.Forms.Button();
            this.btnDeleteCookbook = new System.Windows.Forms.Button();
            this.txtCookbookName = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ComboBox();
            this.tblPrice = new System.Windows.Forms.TableLayoutPanel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.tblDateCreated = new System.Windows.Forms.TableLayoutPanel();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.tblRecipes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRecipes)).BeginInit();
            this.tblCookbook.SuspendLayout();
            this.tblPrice.SuspendLayout();
            this.tblDateCreated.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Controls.Add(this.tblRecipes, 0, 1);
            this.tblMain.Controls.Add(this.tblCookbook, 0, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Size = new System.Drawing.Size(807, 670);
            this.tblMain.TabIndex = 0;
            // 
            // tblRecipes
            // 
            this.tblRecipes.ColumnCount = 1;
            this.tblRecipes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRecipes.Controls.Add(this.btnSaveCookbookRecipe, 0, 0);
            this.tblRecipes.Controls.Add(this.gRecipes, 0, 1);
            this.tblRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRecipes.Location = new System.Drawing.Point(3, 338);
            this.tblRecipes.Name = "tblRecipes";
            this.tblRecipes.RowCount = 2;
            this.tblRecipes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblRecipes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tblRecipes.Size = new System.Drawing.Size(801, 329);
            this.tblRecipes.TabIndex = 0;
            // 
            // btnSaveCookbookRecipe
            // 
            this.btnSaveCookbookRecipe.Location = new System.Drawing.Point(3, 3);
            this.btnSaveCookbookRecipe.Name = "btnSaveCookbookRecipe";
            this.btnSaveCookbookRecipe.Size = new System.Drawing.Size(94, 43);
            this.btnSaveCookbookRecipe.TabIndex = 0;
            this.btnSaveCookbookRecipe.Text = "Save";
            this.btnSaveCookbookRecipe.UseVisualStyleBackColor = true;
            // 
            // gRecipes
            // 
            this.gRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gRecipes.Location = new System.Drawing.Point(3, 52);
            this.gRecipes.Name = "gRecipes";
            this.gRecipes.RowHeadersWidth = 51;
            this.gRecipes.RowTemplate.Height = 29;
            this.gRecipes.Size = new System.Drawing.Size(795, 274);
            this.gRecipes.TabIndex = 1;
            // 
            // tblCookbook
            // 
            this.tblCookbook.ColumnCount = 2;
            this.tblCookbook.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblCookbook.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblCookbook.Controls.Add(this.lblCookbookName, 0, 1);
            this.tblCookbook.Controls.Add(this.lblUser, 0, 2);
            this.tblCookbook.Controls.Add(this.lblPrice, 0, 4);
            this.tblCookbook.Controls.Add(this.lblActive, 0, 5);
            this.tblCookbook.Controls.Add(this.btnSaveCookbook, 0, 0);
            this.tblCookbook.Controls.Add(this.btnDeleteCookbook, 1, 0);
            this.tblCookbook.Controls.Add(this.txtCookbookName, 1, 1);
            this.tblCookbook.Controls.Add(this.lstUsers, 1, 2);
            this.tblCookbook.Controls.Add(this.tblPrice, 1, 4);
            this.tblCookbook.Controls.Add(this.chkActive, 1, 5);
            this.tblCookbook.Controls.Add(this.tblDateCreated, 1, 3);
            this.tblCookbook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCookbook.Location = new System.Drawing.Point(3, 3);
            this.tblCookbook.Name = "tblCookbook";
            this.tblCookbook.RowCount = 6;
            this.tblCookbook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCookbook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCookbook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCookbook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCookbook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCookbook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCookbook.Size = new System.Drawing.Size(801, 329);
            this.tblCookbook.TabIndex = 1;
            // 
            // lblCookbookName
            // 
            this.lblCookbookName.AutoSize = true;
            this.lblCookbookName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCookbookName.Location = new System.Drawing.Point(3, 54);
            this.lblCookbookName.Name = "lblCookbookName";
            this.lblCookbookName.Size = new System.Drawing.Size(234, 54);
            this.lblCookbookName.TabIndex = 1;
            this.lblCookbookName.Text = "Cookbook Name";
            this.lblCookbookName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Location = new System.Drawing.Point(3, 108);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(234, 54);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.Location = new System.Drawing.Point(3, 216);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(234, 54);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActive.Location = new System.Drawing.Point(3, 270);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(234, 59);
            this.lblActive.TabIndex = 4;
            this.lblActive.Text = "Active";
            this.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveCookbook
            // 
            this.btnSaveCookbook.Location = new System.Drawing.Point(3, 3);
            this.btnSaveCookbook.Name = "btnSaveCookbook";
            this.btnSaveCookbook.Size = new System.Drawing.Size(158, 48);
            this.btnSaveCookbook.TabIndex = 5;
            this.btnSaveCookbook.Text = "Save";
            this.btnSaveCookbook.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCookbook
            // 
            this.btnDeleteCookbook.Location = new System.Drawing.Point(243, 3);
            this.btnDeleteCookbook.Name = "btnDeleteCookbook";
            this.btnDeleteCookbook.Size = new System.Drawing.Size(146, 48);
            this.btnDeleteCookbook.TabIndex = 6;
            this.btnDeleteCookbook.Text = "Delete";
            this.btnDeleteCookbook.UseVisualStyleBackColor = true;
            // 
            // txtCookbookName
            // 
            this.txtCookbookName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCookbookName.Location = new System.Drawing.Point(243, 57);
            this.txtCookbookName.Name = "txtCookbookName";
            this.txtCookbookName.Size = new System.Drawing.Size(555, 27);
            this.txtCookbookName.TabIndex = 7;
            // 
            // lstUsers
            // 
            this.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(243, 111);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(555, 28);
            this.lstUsers.TabIndex = 8;
            // 
            // tblPrice
            // 
            this.tblPrice.ColumnCount = 2;
            this.tblPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPrice.Controls.Add(this.txtPrice, 0, 0);
            this.tblPrice.Controls.Add(this.txtDateCreated, 1, 0);
            this.tblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPrice.Location = new System.Drawing.Point(243, 219);
            this.tblPrice.Name = "tblPrice";
            this.tblPrice.RowCount = 1;
            this.tblPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPrice.Size = new System.Drawing.Size(555, 48);
            this.tblPrice.TabIndex = 10;
            // 
            // txtPrice
            // 
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Location = new System.Drawing.Point(3, 3);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(271, 27);
            this.txtPrice.TabIndex = 0;
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateCreated.Enabled = false;
            this.txtDateCreated.Location = new System.Drawing.Point(280, 3);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.Size = new System.Drawing.Size(272, 27);
            this.txtDateCreated.TabIndex = 1;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkActive.Location = new System.Drawing.Point(243, 273);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(555, 53);
            this.chkActive.TabIndex = 11;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // tblDateCreated
            // 
            this.tblDateCreated.ColumnCount = 2;
            this.tblDateCreated.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDateCreated.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDateCreated.Controls.Add(this.lblDateCreated, 1, 0);
            this.tblDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDateCreated.Location = new System.Drawing.Point(243, 165);
            this.tblDateCreated.Name = "tblDateCreated";
            this.tblDateCreated.RowCount = 1;
            this.tblDateCreated.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDateCreated.Size = new System.Drawing.Size(555, 48);
            this.tblDateCreated.TabIndex = 12;
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateCreated.Location = new System.Drawing.Point(280, 0);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(272, 48);
            this.lblDateCreated.TabIndex = 9;
            this.lblDateCreated.Text = "Date Created";
            this.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmCookbook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 670);
            this.Controls.Add(this.tblMain);
            this.Name = "frmCookbook";
            this.Text = "Cookbook";
            this.tblMain.ResumeLayout(false);
            this.tblRecipes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gRecipes)).EndInit();
            this.tblCookbook.ResumeLayout(false);
            this.tblCookbook.PerformLayout();
            this.tblPrice.ResumeLayout(false);
            this.tblPrice.PerformLayout();
            this.tblDateCreated.ResumeLayout(false);
            this.tblDateCreated.PerformLayout();
            this.ResumeLayout(false);

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