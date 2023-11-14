namespace RecipeWinForms
{
    partial class frmDashboard
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
            lblTitle = new Label();
            lblWelcome = new Label();
            gdata = new DataGridView();
            tblButtons = new TableLayoutPanel();
            btnRecipeList = new Button();
            btnMealList = new Button();
            btnCookbookList = new Button();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gdata).BeginInit();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblTitle, 0, 0);
            tblMain.Controls.Add(lblWelcome, 0, 1);
            tblMain.Controls.Add(gdata, 0, 2);
            tblMain.Controls.Add(tblButtons, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.Size = new Size(1100, 630);
            tblMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(4, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1092, 126);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hearty Hearth Desktop App";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Dock = DockStyle.Fill;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome.Location = new Point(4, 126);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(1092, 126);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome to the Hearty Hearth Desktop App. In this app you can create recipes and cookbooks and edit them.";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gdata
            // 
            gdata.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gdata.Location = new Point(100, 256);
            gdata.Margin = new Padding(100, 4, 100, 4);
            gdata.Name = "gdata";
            gdata.RowHeadersWidth = 52;
            gdata.RowTemplate.Height = 29;
            gdata.Size = new Size(900, 307);
            gdata.TabIndex = 2;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblButtons.Controls.Add(btnRecipeList, 0, 0);
            tblButtons.Controls.Add(btnMealList, 1, 0);
            tblButtons.Controls.Add(btnCookbookList, 2, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(4, 571);
            tblButtons.Margin = new Padding(4);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 151F));
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 151F));
            tblButtons.Size = new Size(1092, 55);
            tblButtons.TabIndex = 3;
            // 
            // btnRecipeList
            // 
            btnRecipeList.Dock = DockStyle.Fill;
            btnRecipeList.Location = new Point(3, 3);
            btnRecipeList.Name = "btnRecipeList";
            btnRecipeList.Size = new Size(358, 49);
            btnRecipeList.TabIndex = 0;
            btnRecipeList.Text = "Recipe List";
            btnRecipeList.UseVisualStyleBackColor = true;
            // 
            // btnMealList
            // 
            btnMealList.Dock = DockStyle.Fill;
            btnMealList.Location = new Point(367, 3);
            btnMealList.Name = "btnMealList";
            btnMealList.Size = new Size(358, 49);
            btnMealList.TabIndex = 1;
            btnMealList.Text = "Meal List";
            btnMealList.UseVisualStyleBackColor = true;
            // 
            // btnCookbookList
            // 
            btnCookbookList.Dock = DockStyle.Fill;
            btnCookbookList.Location = new Point(731, 3);
            btnCookbookList.Name = "btnCookbookList";
            btnCookbookList.Size = new Size(358, 49);
            btnCookbookList.TabIndex = 2;
            btnCookbookList.Text = "Cookbook List";
            btnCookbookList.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 630);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmDashboard";
            Text = "Dashboard";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gdata).EndInit();
            tblButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private Label lblWelcome;
        private DataGridView gdata;
        private TableLayoutPanel tblButtons;
        private Button btnRecipeList;
        private Button btnMealList;
        private Button btnCookbookList;
    }
}