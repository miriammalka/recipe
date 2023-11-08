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
            tblMain = new TableLayoutPanel();
            lblRecipeName = new Label();
            txtRecipeName = new TextBox();
            tbcntrlChildTable = new TabControl();
            tabIngedients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredients = new Button();
            gIngredients = new DataGridView();
            tabSteps = new TabPage();
            tblInstruction = new TableLayoutPanel();
            btnSaveInstruction = new Button();
            gInstruction = new DataGridView();
            tblButtons = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            btnChangeStatus = new Button();
            lblStatusDates = new Label();
            tblStatusDates = new TableLayoutPanel();
            txtDateCreated = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            tblStatusTitles = new TableLayoutPanel();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            lblCurrentStatus = new Label();
            txtRecipeStatus = new TextBox();
            lblCalories = new Label();
            txtCalories = new TextBox();
            lblCuisineName = new Label();
            lstCuisineName = new ComboBox();
            lblUser = new Label();
            lstUsers = new ComboBox();
            tblMain.SuspendLayout();
            tbcntrlChildTable.SuspendLayout();
            tabIngedients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            tabSteps.SuspendLayout();
            tblInstruction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gInstruction).BeginInit();
            tblButtons.SuspendLayout();
            tblStatusDates.SuspendLayout();
            tblStatusTitles.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.AutoSize = true;
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(tbcntrlChildTable, 0, 8);
            tblMain.Controls.Add(tblButtons, 1, 7);
            tblMain.Controls.Add(lblStatusDates, 0, 5);
            tblMain.Controls.Add(tblStatusDates, 1, 6);
            tblMain.Controls.Add(tblStatusTitles, 1, 5);
            tblMain.Controls.Add(lblCurrentStatus, 0, 4);
            tblMain.Controls.Add(txtRecipeStatus, 1, 4);
            tblMain.Controls.Add(lblCalories, 0, 3);
            tblMain.Controls.Add(txtCalories, 1, 3);
            tblMain.Controls.Add(lblCuisineName, 0, 2);
            tblMain.Controls.Add(lstCuisineName, 1, 2);
            tblMain.Controls.Add(lblUser, 0, 1);
            tblMain.Controls.Add(lstUsers, 1, 1);
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15.78947F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 84.21053F));
            tblMain.Size = new Size(569, 635);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Location = new Point(4, 0);
            lblRecipeName.Margin = new Padding(4, 0, 4, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(133, 40);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name:";
            // 
            // txtRecipeName
            // 
            txtRecipeName.BackColor = SystemColors.ControlLightLight;
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(144, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(422, 34);
            txtRecipeName.TabIndex = 1;
            // 
            // tbcntrlChildTable
            // 
            tblMain.SetColumnSpan(tbcntrlChildTable, 2);
            tbcntrlChildTable.Controls.Add(tabIngedients);
            tbcntrlChildTable.Controls.Add(tabSteps);
            tbcntrlChildTable.Dock = DockStyle.Fill;
            tbcntrlChildTable.Location = new Point(3, 339);
            tbcntrlChildTable.Name = "tbcntrlChildTable";
            tbcntrlChildTable.SelectedIndex = 0;
            tbcntrlChildTable.Size = new Size(563, 293);
            tbcntrlChildTable.TabIndex = 11;
            // 
            // tabIngedients
            // 
            tabIngedients.Controls.Add(tblIngredients);
            tabIngedients.Location = new Point(4, 37);
            tabIngedients.Name = "tabIngedients";
            tabIngedients.Padding = new Padding(3);
            tabIngedients.Size = new Size(555, 252);
            tabIngedients.TabIndex = 0;
            tabIngedients.Text = "Ingedients";
            tabIngedients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblIngredients.Controls.Add(btnSaveIngredients, 0, 0);
            tblIngredients.Controls.Add(gIngredients, 0, 1);
            tblIngredients.Dock = DockStyle.Fill;
            tblIngredients.Location = new Point(3, 3);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle());
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblIngredients.Size = new Size(549, 246);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredients
            // 
            btnSaveIngredients.Dock = DockStyle.Left;
            btnSaveIngredients.Location = new Point(3, 3);
            btnSaveIngredients.Name = "btnSaveIngredients";
            btnSaveIngredients.Size = new Size(94, 35);
            btnSaveIngredients.TabIndex = 0;
            btnSaveIngredients.Text = "Save";
            btnSaveIngredients.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredients.Dock = DockStyle.Fill;
            gIngredients.Location = new Point(3, 44);
            gIngredients.Name = "gIngredients";
            gIngredients.RowHeadersWidth = 51;
            gIngredients.RowTemplate.Height = 29;
            gIngredients.Size = new Size(543, 199);
            gIngredients.TabIndex = 1;
            // 
            // tabSteps
            // 
            tabSteps.Controls.Add(tblInstruction);
            tabSteps.Location = new Point(4, 29);
            tabSteps.Name = "tabSteps";
            tabSteps.Padding = new Padding(3);
            tabSteps.Size = new Size(555, 260);
            tabSteps.TabIndex = 1;
            tabSteps.Text = "Steps";
            tabSteps.UseVisualStyleBackColor = true;
            // 
            // tblInstruction
            // 
            tblInstruction.ColumnCount = 1;
            tblInstruction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblInstruction.Controls.Add(btnSaveInstruction, 0, 0);
            tblInstruction.Controls.Add(gInstruction, 0, 1);
            tblInstruction.Dock = DockStyle.Fill;
            tblInstruction.Location = new Point(3, 3);
            tblInstruction.Name = "tblInstruction";
            tblInstruction.RowCount = 2;
            tblInstruction.RowStyles.Add(new RowStyle());
            tblInstruction.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblInstruction.Size = new Size(549, 254);
            tblInstruction.TabIndex = 0;
            // 
            // btnSaveInstruction
            // 
            btnSaveInstruction.Dock = DockStyle.Left;
            btnSaveInstruction.Location = new Point(3, 3);
            btnSaveInstruction.Name = "btnSaveInstruction";
            btnSaveInstruction.Size = new Size(109, 44);
            btnSaveInstruction.TabIndex = 0;
            btnSaveInstruction.Text = "Save";
            btnSaveInstruction.UseVisualStyleBackColor = true;
            // 
            // gInstruction
            // 
            gInstruction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gInstruction.Dock = DockStyle.Fill;
            gInstruction.Location = new Point(3, 53);
            gInstruction.Name = "gInstruction";
            gInstruction.RowHeadersWidth = 51;
            gInstruction.RowTemplate.Height = 29;
            gInstruction.Size = new Size(543, 198);
            gInstruction.TabIndex = 1;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.06635F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.25118F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.68246F));
            tblButtons.Controls.Add(btnSave, 0, 0);
            tblButtons.Controls.Add(btnDelete, 1, 0);
            tblButtons.Controls.Add(btnChangeStatus, 2, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(144, 283);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(422, 50);
            tblButtons.TabIndex = 20;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 44);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(113, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(108, 44);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.AutoSize = true;
            btnChangeStatus.Dock = DockStyle.Fill;
            btnChangeStatus.Location = new Point(227, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(192, 44);
            btnChangeStatus.TabIndex = 2;
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // lblStatusDates
            // 
            lblStatusDates.AutoSize = true;
            lblStatusDates.Dock = DockStyle.Fill;
            lblStatusDates.Location = new Point(3, 200);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(135, 40);
            lblStatusDates.TabIndex = 10;
            lblStatusDates.Text = "Status Dates";
            lblStatusDates.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblStatusDates
            // 
            tblStatusDates.ColumnCount = 3;
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblStatusDates.Controls.Add(txtDateCreated, 0, 0);
            tblStatusDates.Controls.Add(txtDatePublished, 1, 0);
            tblStatusDates.Controls.Add(txtDateArchived, 2, 0);
            tblStatusDates.Dock = DockStyle.Fill;
            tblStatusDates.Location = new Point(144, 243);
            tblStatusDates.Name = "tblStatusDates";
            tblStatusDates.RowCount = 1;
            tblStatusDates.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStatusDates.Size = new Size(422, 34);
            tblStatusDates.TabIndex = 19;
            // 
            // txtDateCreated
            // 
            txtDateCreated.BackColor = SystemColors.ControlDark;
            txtDateCreated.Dock = DockStyle.Fill;
            txtDateCreated.Enabled = false;
            txtDateCreated.Location = new Point(3, 3);
            txtDateCreated.Name = "txtDateCreated";
            txtDateCreated.Size = new Size(134, 34);
            txtDateCreated.TabIndex = 0;
            // 
            // txtDatePublished
            // 
            txtDatePublished.BackColor = SystemColors.ControlDark;
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Enabled = false;
            txtDatePublished.Location = new Point(143, 3);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(134, 34);
            txtDatePublished.TabIndex = 1;
            // 
            // txtDateArchived
            // 
            txtDateArchived.BackColor = SystemColors.ControlDark;
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Enabled = false;
            txtDateArchived.Location = new Point(283, 3);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(136, 34);
            txtDateArchived.TabIndex = 2;
            // 
            // tblStatusTitles
            // 
            tblStatusTitles.ColumnCount = 3;
            tblStatusTitles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblStatusTitles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblStatusTitles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblStatusTitles.Controls.Add(lblDrafted, 0, 0);
            tblStatusTitles.Controls.Add(lblPublished, 1, 0);
            tblStatusTitles.Controls.Add(lblArchived, 2, 0);
            tblStatusTitles.Dock = DockStyle.Fill;
            tblStatusTitles.Location = new Point(144, 203);
            tblStatusTitles.Name = "tblStatusTitles";
            tblStatusTitles.RowCount = 1;
            tblStatusTitles.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStatusTitles.Size = new Size(422, 34);
            tblStatusTitles.TabIndex = 18;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Location = new Point(3, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(134, 34);
            lblDrafted.TabIndex = 0;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(143, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(134, 34);
            lblPublished.TabIndex = 1;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(283, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(136, 34);
            lblArchived.TabIndex = 2;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Dock = DockStyle.Fill;
            lblCurrentStatus.Location = new Point(3, 160);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(135, 40);
            lblCurrentStatus.TabIndex = 8;
            lblCurrentStatus.Text = "Current Status";
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Enabled = false;
            txtRecipeStatus.Location = new Point(144, 163);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(422, 34);
            txtRecipeStatus.TabIndex = 9;
            // 
            // lblCalories
            // 
            lblCalories.AutoSize = true;
            lblCalories.Dock = DockStyle.Fill;
            lblCalories.Location = new Point(4, 120);
            lblCalories.Margin = new Padding(4, 0, 4, 0);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(133, 40);
            lblCalories.TabIndex = 6;
            lblCalories.Text = "Calories:";
            // 
            // txtCalories
            // 
            txtCalories.BackColor = SystemColors.ControlLightLight;
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(144, 123);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(422, 34);
            txtCalories.TabIndex = 7;
            // 
            // lblCuisineName
            // 
            lblCuisineName.AutoSize = true;
            lblCuisineName.Dock = DockStyle.Fill;
            lblCuisineName.Location = new Point(3, 80);
            lblCuisineName.Name = "lblCuisineName";
            lblCuisineName.Size = new Size(135, 40);
            lblCuisineName.TabIndex = 4;
            lblCuisineName.Text = "Cuisine Name:";
            // 
            // lstCuisineName
            // 
            lstCuisineName.Dock = DockStyle.Fill;
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(144, 83);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(422, 36);
            lstCuisineName.TabIndex = 5;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(3, 40);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(135, 40);
            lblUser.TabIndex = 2;
            lblUser.Text = "User:";
            // 
            // lstUsers
            // 
            lstUsers.Dock = DockStyle.Fill;
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(144, 43);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(422, 36);
            lstUsers.TabIndex = 3;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 633);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "frmRecipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tbcntrlChildTable.ResumeLayout(false);
            tabIngedients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            tabSteps.ResumeLayout(false);
            tblInstruction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gInstruction).EndInit();
            tblButtons.ResumeLayout(false);
            tblButtons.PerformLayout();
            tblStatusDates.ResumeLayout(false);
            tblStatusDates.PerformLayout();
            tblStatusTitles.ResumeLayout(false);
            tblStatusTitles.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private Label lblCalories;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private Label lblCuisineName;
        private ComboBox lstCuisineName;
        private Label lblCurrentStatus;
        private TextBox txtRecipeStatus;
        private Label lblStatusDates;
        private TableLayoutPanel tblStatusTitles;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TableLayoutPanel tblStatusDates;
        private TextBox txtDateCreated;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private TableLayoutPanel tblButtons;
        private Button btnSave;
        private Button btnDelete;
        private Button btnChangeStatus;
        private TabControl tbcntrlChildTable;
        private TabPage tabIngedients;
        private TabPage tabSteps;
        private TableLayoutPanel tblInstruction;
        private Button btnSaveInstruction;
        private DataGridView gInstruction;
        private TableLayoutPanel tblIngredients;
        private Button btnSaveIngredients;
        private DataGridView gIngredients;
        private Label lblUser;
        private ComboBox lstUsers;
    }
}