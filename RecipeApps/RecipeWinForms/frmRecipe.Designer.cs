namespace RecipeWinForms
{
    partial class frmRecipe
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
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.lblCalories = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblDatePublished = new System.Windows.Forms.Label();
            this.lblDateArchived = new System.Windows.Forms.Label();
            this.lblRecipeStatus = new System.Windows.Forms.Label();
            this.lblPicture = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.txtDatePublished = new System.Windows.Forms.TextBox();
            this.txtDateArchived = new System.Windows.Forms.TextBox();
            this.txtRecipeStatus = new System.Windows.Forms.TextBox();
            this.txtPicture = new System.Windows.Forms.TextBox();
            this.tblMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.lblRecipeName, 0, 0);
            this.tblMain.Controls.Add(this.lblCalories, 0, 1);
            this.tblMain.Controls.Add(this.lblDateCreated, 0, 2);
            this.tblMain.Controls.Add(this.lblDatePublished, 0, 3);
            this.tblMain.Controls.Add(this.lblDateArchived, 0, 4);
            this.tblMain.Controls.Add(this.lblRecipeStatus, 0, 5);
            this.tblMain.Controls.Add(this.lblPicture, 0, 6);
            this.tblMain.Controls.Add(this.txtRecipeName, 1, 0);
            this.tblMain.Controls.Add(this.txtCalories, 1, 1);
            this.tblMain.Controls.Add(this.txtDateCreated, 1, 2);
            this.tblMain.Controls.Add(this.txtDatePublished, 1, 3);
            this.tblMain.Controls.Add(this.txtDateArchived, 1, 4);
            this.tblMain.Controls.Add(this.txtRecipeStatus, 1, 5);
            this.tblMain.Controls.Add(this.txtPicture, 1, 6);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(4);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 7;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.Size = new System.Drawing.Size(569, 281);
            this.tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Location = new System.Drawing.Point(4, 6);
            this.lblRecipeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(130, 28);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.Text = "Recipe Name:";
            // 
            // lblCalories
            // 
            this.lblCalories.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCalories.AutoSize = true;
            this.lblCalories.Location = new System.Drawing.Point(4, 46);
            this.lblCalories.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(85, 28);
            this.lblCalories.TabIndex = 1;
            this.lblCalories.Text = "Calories:";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(4, 86);
            this.lblDateCreated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(130, 28);
            this.lblDateCreated.TabIndex = 2;
            this.lblDateCreated.Text = "Date Created:";
            // 
            // lblDatePublished
            // 
            this.lblDatePublished.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDatePublished.AutoSize = true;
            this.lblDatePublished.Location = new System.Drawing.Point(4, 126);
            this.lblDatePublished.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatePublished.Name = "lblDatePublished";
            this.lblDatePublished.Size = new System.Drawing.Size(147, 28);
            this.lblDatePublished.TabIndex = 3;
            this.lblDatePublished.Text = "Date Published:";
            // 
            // lblDateArchived
            // 
            this.lblDateArchived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateArchived.AutoSize = true;
            this.lblDateArchived.Location = new System.Drawing.Point(4, 166);
            this.lblDateArchived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateArchived.Name = "lblDateArchived";
            this.lblDateArchived.Size = new System.Drawing.Size(139, 28);
            this.lblDateArchived.TabIndex = 4;
            this.lblDateArchived.Text = "Date Archived:";
            // 
            // lblRecipeStatus
            // 
            this.lblRecipeStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRecipeStatus.AutoSize = true;
            this.lblRecipeStatus.Location = new System.Drawing.Point(4, 206);
            this.lblRecipeStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecipeStatus.Name = "lblRecipeStatus";
            this.lblRecipeStatus.Size = new System.Drawing.Size(131, 28);
            this.lblRecipeStatus.TabIndex = 5;
            this.lblRecipeStatus.Text = "Recipe Status:";
            // 
            // lblPicture
            // 
            this.lblPicture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPicture.AutoSize = true;
            this.lblPicture.Location = new System.Drawing.Point(4, 246);
            this.lblPicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(76, 28);
            this.lblPicture.TabIndex = 6;
            this.lblPicture.Text = "Picture:";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRecipeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecipeName.Location = new System.Drawing.Point(158, 3);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.ReadOnly = true;
            this.txtRecipeName.Size = new System.Drawing.Size(408, 34);
            this.txtRecipeName.TabIndex = 7;
            // 
            // txtCalories
            // 
            this.txtCalories.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCalories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCalories.Location = new System.Drawing.Point(158, 43);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.ReadOnly = true;
            this.txtCalories.Size = new System.Drawing.Size(408, 34);
            this.txtCalories.TabIndex = 8;
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateCreated.Location = new System.Drawing.Point(158, 83);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.ReadOnly = true;
            this.txtDateCreated.Size = new System.Drawing.Size(408, 34);
            this.txtDateCreated.TabIndex = 9;
            // 
            // txtDatePublished
            // 
            this.txtDatePublished.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDatePublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatePublished.Location = new System.Drawing.Point(158, 123);
            this.txtDatePublished.Name = "txtDatePublished";
            this.txtDatePublished.ReadOnly = true;
            this.txtDatePublished.Size = new System.Drawing.Size(408, 34);
            this.txtDatePublished.TabIndex = 10;
            // 
            // txtDateArchived
            // 
            this.txtDateArchived.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDateArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateArchived.Location = new System.Drawing.Point(158, 163);
            this.txtDateArchived.Name = "txtDateArchived";
            this.txtDateArchived.ReadOnly = true;
            this.txtDateArchived.Size = new System.Drawing.Size(408, 34);
            this.txtDateArchived.TabIndex = 11;
            // 
            // txtRecipeStatus
            // 
            this.txtRecipeStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRecipeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecipeStatus.Location = new System.Drawing.Point(158, 203);
            this.txtRecipeStatus.Name = "txtRecipeStatus";
            this.txtRecipeStatus.ReadOnly = true;
            this.txtRecipeStatus.Size = new System.Drawing.Size(408, 34);
            this.txtRecipeStatus.TabIndex = 12;
            // 
            // txtPicture
            // 
            this.txtPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPicture.Location = new System.Drawing.Point(158, 243);
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.ReadOnly = true;
            this.txtPicture.Size = new System.Drawing.Size(408, 34);
            this.txtPicture.TabIndex = 13;
            // 
            // frmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 281);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRecipe";
            this.Text = "frmRecipe";
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private Label lblCalories;
        private Label lblDateCreated;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private Label lblRecipeStatus;
        private Label lblPicture;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private TextBox txtDateCreated;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private TextBox txtRecipeStatus;
        private TextBox txtPicture;
    }
}