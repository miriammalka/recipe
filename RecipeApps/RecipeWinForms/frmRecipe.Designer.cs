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
            this.lblDateArchived1 = new System.Windows.Forms.Label();
            this.lblDatePublished1 = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblCalories = new System.Windows.Forms.Label();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.lblCuisineName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstCuisineName = new System.Windows.Forms.ComboBox();
            this.lstUserName = new System.Windows.Forms.ComboBox();
            this.lblDatePublished = new System.Windows.Forms.Label();
            this.lblDateArchived = new System.Windows.Forms.Label();
            this.dtpDateCreated = new System.Windows.Forms.DateTimePicker();
            this.tblMain.SuspendLayout();
            this.tblButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.lblDateArchived1, 0, 6);
            this.tblMain.Controls.Add(this.lblDatePublished1, 0, 5);
            this.tblMain.Controls.Add(this.lblDateCreated, 0, 4);
            this.tblMain.Controls.Add(this.lblCalories, 0, 3);
            this.tblMain.Controls.Add(this.txtCalories, 1, 3);
            this.tblMain.Controls.Add(this.lblRecipeName, 0, 2);
            this.tblMain.Controls.Add(this.txtRecipeName, 1, 2);
            this.tblMain.Controls.Add(this.lblCuisineName, 0, 0);
            this.tblMain.Controls.Add(this.lblUserName, 0, 1);
            this.tblMain.Controls.Add(this.tblButtons, 1, 9);
            this.tblMain.Controls.Add(this.lstCuisineName, 1, 0);
            this.tblMain.Controls.Add(this.lstUserName, 1, 1);
            this.tblMain.Controls.Add(this.lblDatePublished, 1, 5);
            this.tblMain.Controls.Add(this.lblDateArchived, 1, 6);
            this.tblMain.Controls.Add(this.dtpDateCreated, 1, 4);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(4);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 8;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Size = new System.Drawing.Size(569, 391);
            this.tblMain.TabIndex = 0;
            // 
            // lblDateArchived1
            // 
            this.lblDateArchived1.AutoSize = true;
            this.lblDateArchived1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateArchived1.Location = new System.Drawing.Point(4, 240);
            this.lblDateArchived1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateArchived1.Name = "lblDateArchived1";
            this.lblDateArchived1.Size = new System.Drawing.Size(147, 40);
            this.lblDateArchived1.TabIndex = 4;
            this.lblDateArchived1.Text = "Date Archived:";
            // 
            // lblDatePublished1
            // 
            this.lblDatePublished1.AutoSize = true;
            this.lblDatePublished1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDatePublished1.Location = new System.Drawing.Point(4, 200);
            this.lblDatePublished1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatePublished1.Name = "lblDatePublished1";
            this.lblDatePublished1.Size = new System.Drawing.Size(147, 40);
            this.lblDatePublished1.TabIndex = 3;
            this.lblDatePublished1.Text = "Date Published:";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateCreated.Location = new System.Drawing.Point(4, 160);
            this.lblDateCreated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(147, 40);
            this.lblDateCreated.TabIndex = 2;
            this.lblDateCreated.Text = "Date Created:";
            // 
            // lblCalories
            // 
            this.lblCalories.AutoSize = true;
            this.lblCalories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCalories.Location = new System.Drawing.Point(4, 120);
            this.lblCalories.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(147, 40);
            this.lblCalories.TabIndex = 1;
            this.lblCalories.Text = "Calories:";
            // 
            // txtCalories
            // 
            this.txtCalories.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCalories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCalories.Location = new System.Drawing.Point(158, 123);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(408, 34);
            this.txtCalories.TabIndex = 8;
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecipeName.Location = new System.Drawing.Point(4, 80);
            this.lblRecipeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(147, 40);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.Text = "Recipe Name:";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRecipeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecipeName.Location = new System.Drawing.Point(158, 83);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(408, 34);
            this.txtRecipeName.TabIndex = 7;
            // 
            // lblCuisineName
            // 
            this.lblCuisineName.AutoSize = true;
            this.lblCuisineName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCuisineName.Location = new System.Drawing.Point(3, 0);
            this.lblCuisineName.Name = "lblCuisineName";
            this.lblCuisineName.Size = new System.Drawing.Size(149, 40);
            this.lblCuisineName.TabIndex = 14;
            this.lblCuisineName.Text = "Cuisine Name:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserName.Location = new System.Drawing.Point(3, 40);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(149, 40);
            this.lblUserName.TabIndex = 15;
            this.lblUserName.Text = "User Name:";
            // 
            // tblButtons
            // 
            this.tblButtons.ColumnCount = 2;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblButtons.Controls.Add(this.btnSave, 0, 0);
            this.tblButtons.Controls.Add(this.btnDelete, 1, 0);
            this.tblButtons.Location = new System.Drawing.Point(158, 343);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblButtons.Size = new System.Drawing.Size(250, 45);
            this.tblButtons.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(128, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 38);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lstCuisineName
            // 
            this.lstCuisineName.FormattingEnabled = true;
            this.lstCuisineName.Location = new System.Drawing.Point(158, 3);
            this.lstCuisineName.Name = "lstCuisineName";
            this.lstCuisineName.Size = new System.Drawing.Size(232, 36);
            this.lstCuisineName.TabIndex = 22;
            // 
            // lstUserName
            // 
            this.lstUserName.FormattingEnabled = true;
            this.lstUserName.Location = new System.Drawing.Point(158, 43);
            this.lstUserName.Name = "lstUserName";
            this.lstUserName.Size = new System.Drawing.Size(232, 36);
            this.lstUserName.TabIndex = 23;
            // 
            // lblDatePublished
            // 
            this.lblDatePublished.AutoSize = true;
            this.lblDatePublished.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDatePublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDatePublished.Location = new System.Drawing.Point(158, 200);
            this.lblDatePublished.Name = "lblDatePublished";
            this.lblDatePublished.Size = new System.Drawing.Size(408, 40);
            this.lblDatePublished.TabIndex = 25;
            // 
            // lblDateArchived
            // 
            this.lblDateArchived.AutoSize = true;
            this.lblDateArchived.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDateArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateArchived.Location = new System.Drawing.Point(158, 240);
            this.lblDateArchived.Name = "lblDateArchived";
            this.lblDateArchived.Size = new System.Drawing.Size(408, 40);
            this.lblDateArchived.TabIndex = 26;
            // 
            // dtpDateCreated
            // 
            this.dtpDateCreated.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpDateCreated.Enabled = false;
            this.dtpDateCreated.Location = new System.Drawing.Point(158, 163);
            this.dtpDateCreated.Name = "dtpDateCreated";
            this.dtpDateCreated.Size = new System.Drawing.Size(336, 34);
            this.dtpDateCreated.TabIndex = 27;
            // 
            // frmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 391);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRecipe";
            this.Text = "frmRecipe";
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.tblButtons.ResumeLayout(false);
            this.tblButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private Label lblCalories;
        private Label lblDateCreated;
        private Label lblDatePublished1;
        private Label lblDateArchived1;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private Label lblCuisineName;
        private Label lblUserName;
        private TableLayoutPanel tblButtons;
        private Button btnSave;
        private Button btnDelete;
        private ComboBox lstCuisineName;
        private ComboBox lstUserName;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private DateTimePicker dtpDateCreated;
    }
}