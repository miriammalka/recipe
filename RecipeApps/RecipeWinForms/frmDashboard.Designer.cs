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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.gdata = new System.Windows.Forms.DataGridView();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnRecipeList = new System.Windows.Forms.Button();
            this.btnMealList = new System.Windows.Forms.Button();
            this.btnCookbookList = new System.Windows.Forms.Button();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdata)).BeginInit();
            this.tblButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblMain.Controls.Add(this.lblWelcome, 0, 1);
            this.tblMain.Controls.Add(this.gdata, 0, 2);
            this.tblMain.Controls.Add(this.tblButtons, 0, 3);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 4;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.Size = new System.Drawing.Size(1100, 630);
            this.tblMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(4, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1092, 126);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hearty Hearth Desktop App";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(4, 126);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(1092, 126);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome...";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gdata
            // 
            this.gdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdata.Location = new System.Drawing.Point(100, 256);
            this.gdata.Margin = new System.Windows.Forms.Padding(100, 4, 100, 4);
            this.gdata.Name = "gdata";
            this.gdata.RowHeadersWidth = 51;
            this.gdata.RowTemplate.Height = 29;
            this.gdata.Size = new System.Drawing.Size(900, 307);
            this.gdata.TabIndex = 2;
            // 
            // tblButtons
            // 
            this.tblButtons.ColumnCount = 3;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.Controls.Add(this.btnRecipeList, 0, 0);
            this.tblButtons.Controls.Add(this.btnMealList, 1, 0);
            this.tblButtons.Controls.Add(this.btnCookbookList, 2, 0);
            this.tblButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblButtons.Location = new System.Drawing.Point(4, 571);
            this.tblButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tblButtons.Size = new System.Drawing.Size(1092, 55);
            this.tblButtons.TabIndex = 3;
            // 
            // btnRecipeList
            // 
            this.btnRecipeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipeList.Location = new System.Drawing.Point(3, 3);
            this.btnRecipeList.Name = "btnRecipeList";
            this.btnRecipeList.Size = new System.Drawing.Size(358, 49);
            this.btnRecipeList.TabIndex = 0;
            this.btnRecipeList.Text = "Recipe List";
            this.btnRecipeList.UseVisualStyleBackColor = true;
            // 
            // btnMealList
            // 
            this.btnMealList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMealList.Location = new System.Drawing.Point(367, 3);
            this.btnMealList.Name = "btnMealList";
            this.btnMealList.Size = new System.Drawing.Size(358, 49);
            this.btnMealList.TabIndex = 1;
            this.btnMealList.Text = "Meal List";
            this.btnMealList.UseVisualStyleBackColor = true;
            // 
            // btnCookbookList
            // 
            this.btnCookbookList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCookbookList.Location = new System.Drawing.Point(731, 3);
            this.btnCookbookList.Name = "btnCookbookList";
            this.btnCookbookList.Size = new System.Drawing.Size(358, 49);
            this.btnCookbookList.TabIndex = 2;
            this.btnCookbookList.Text = "Cookbook List";
            this.btnCookbookList.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 630);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdata)).EndInit();
            this.tblButtons.ResumeLayout(false);
            this.ResumeLayout(false);

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