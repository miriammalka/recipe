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
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.tbcntrlChildTable = new System.Windows.Forms.TabControl();
            this.tabIngedients = new System.Windows.Forms.TabPage();
            this.tblIngredients = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveIngredients = new System.Windows.Forms.Button();
            this.gIngredients = new System.Windows.Forms.DataGridView();
            this.tabSteps = new System.Windows.Forms.TabPage();
            this.tblInstruction = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveInstruction = new System.Windows.Forms.Button();
            this.gInstruction = new System.Windows.Forms.DataGridView();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.lblStatusDates = new System.Windows.Forms.Label();
            this.tblStatusDates = new System.Windows.Forms.TableLayoutPanel();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.txtDatePublished = new System.Windows.Forms.TextBox();
            this.txtDateArchived = new System.Windows.Forms.TextBox();
            this.tblStatusTitles = new System.Windows.Forms.TableLayoutPanel();
            this.lblDrafted = new System.Windows.Forms.Label();
            this.lblPublished = new System.Windows.Forms.Label();
            this.lblArchived = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.txtRecipeStatus = new System.Windows.Forms.TextBox();
            this.lblCalories = new System.Windows.Forms.Label();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.lblCuisineName = new System.Windows.Forms.Label();
            this.lstCuisineName = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ComboBox();
            this.tblMain.SuspendLayout();
            this.tbcntrlChildTable.SuspendLayout();
            this.tabIngedients.SuspendLayout();
            this.tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gIngredients)).BeginInit();
            this.tabSteps.SuspendLayout();
            this.tblInstruction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gInstruction)).BeginInit();
            this.tblButtons.SuspendLayout();
            this.tblStatusDates.SuspendLayout();
            this.tblStatusTitles.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.AutoSize = true;
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.lblRecipeName, 0, 0);
            this.tblMain.Controls.Add(this.txtRecipeName, 1, 0);
            this.tblMain.Controls.Add(this.tbcntrlChildTable, 0, 8);
            this.tblMain.Controls.Add(this.tblButtons, 1, 7);
            this.tblMain.Controls.Add(this.lblStatusDates, 0, 5);
            this.tblMain.Controls.Add(this.tblStatusDates, 1, 6);
            this.tblMain.Controls.Add(this.tblStatusTitles, 1, 5);
            this.tblMain.Controls.Add(this.lblCurrentStatus, 0, 4);
            this.tblMain.Controls.Add(this.txtRecipeStatus, 1, 4);
            this.tblMain.Controls.Add(this.lblCalories, 0, 3);
            this.tblMain.Controls.Add(this.txtCalories, 1, 3);
            this.tblMain.Controls.Add(this.lblCuisineName, 0, 2);
            this.tblMain.Controls.Add(this.lstCuisineName, 1, 2);
            this.tblMain.Controls.Add(this.lblUser, 0, 1);
            this.tblMain.Controls.Add(this.lstUsers, 1, 1);
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(4);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 9;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.21053F));
            this.tblMain.Size = new System.Drawing.Size(569, 635);
            this.tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecipeName.Location = new System.Drawing.Point(4, 0);
            this.lblRecipeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(133, 40);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.Text = "Recipe Name:";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRecipeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecipeName.Location = new System.Drawing.Point(144, 3);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(422, 34);
            this.txtRecipeName.TabIndex = 1;
            // 
            // tbcntrlChildTable
            // 
            this.tblMain.SetColumnSpan(this.tbcntrlChildTable, 2);
            this.tbcntrlChildTable.Controls.Add(this.tabIngedients);
            this.tbcntrlChildTable.Controls.Add(this.tabSteps);
            this.tbcntrlChildTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcntrlChildTable.Location = new System.Drawing.Point(3, 339);
            this.tbcntrlChildTable.Name = "tbcntrlChildTable";
            this.tbcntrlChildTable.SelectedIndex = 0;
            this.tbcntrlChildTable.Size = new System.Drawing.Size(563, 293);
            this.tbcntrlChildTable.TabIndex = 11;
            // 
            // tabIngedients
            // 
            this.tabIngedients.Controls.Add(this.tblIngredients);
            this.tabIngedients.Location = new System.Drawing.Point(4, 37);
            this.tabIngedients.Name = "tabIngedients";
            this.tabIngedients.Padding = new System.Windows.Forms.Padding(3);
            this.tabIngedients.Size = new System.Drawing.Size(555, 252);
            this.tabIngedients.TabIndex = 0;
            this.tabIngedients.Text = "Ingedients";
            this.tabIngedients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            this.tblIngredients.ColumnCount = 1;
            this.tblIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblIngredients.Controls.Add(this.btnSaveIngredients, 0, 0);
            this.tblIngredients.Controls.Add(this.gIngredients, 0, 1);
            this.tblIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblIngredients.Location = new System.Drawing.Point(3, 3);
            this.tblIngredients.Name = "tblIngredients";
            this.tblIngredients.RowCount = 2;
            this.tblIngredients.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblIngredients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblIngredients.Size = new System.Drawing.Size(549, 246);
            this.tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredients
            // 
            this.btnSaveIngredients.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveIngredients.Location = new System.Drawing.Point(3, 3);
            this.btnSaveIngredients.Name = "btnSaveIngredients";
            this.btnSaveIngredients.Size = new System.Drawing.Size(94, 35);
            this.btnSaveIngredients.TabIndex = 0;
            this.btnSaveIngredients.Text = "Save";
            this.btnSaveIngredients.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            this.gIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gIngredients.Location = new System.Drawing.Point(3, 44);
            this.gIngredients.Name = "gIngredients";
            this.gIngredients.RowHeadersWidth = 51;
            this.gIngredients.RowTemplate.Height = 29;
            this.gIngredients.Size = new System.Drawing.Size(543, 199);
            this.gIngredients.TabIndex = 1;
            // 
            // tabSteps
            // 
            this.tabSteps.Controls.Add(this.tblInstruction);
            this.tabSteps.Location = new System.Drawing.Point(4, 29);
            this.tabSteps.Name = "tabSteps";
            this.tabSteps.Padding = new System.Windows.Forms.Padding(3);
            this.tabSteps.Size = new System.Drawing.Size(555, 260);
            this.tabSteps.TabIndex = 1;
            this.tabSteps.Text = "Steps";
            this.tabSteps.UseVisualStyleBackColor = true;
            // 
            // tblInstruction
            // 
            this.tblInstruction.ColumnCount = 1;
            this.tblInstruction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblInstruction.Controls.Add(this.btnSaveInstruction, 0, 0);
            this.tblInstruction.Controls.Add(this.gInstruction, 0, 1);
            this.tblInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblInstruction.Location = new System.Drawing.Point(3, 3);
            this.tblInstruction.Name = "tblInstruction";
            this.tblInstruction.RowCount = 2;
            this.tblInstruction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblInstruction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblInstruction.Size = new System.Drawing.Size(549, 254);
            this.tblInstruction.TabIndex = 0;
            // 
            // btnSaveInstruction
            // 
            this.btnSaveInstruction.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveInstruction.Location = new System.Drawing.Point(3, 3);
            this.btnSaveInstruction.Name = "btnSaveInstruction";
            this.btnSaveInstruction.Size = new System.Drawing.Size(109, 44);
            this.btnSaveInstruction.TabIndex = 0;
            this.btnSaveInstruction.Text = "Save";
            this.btnSaveInstruction.UseVisualStyleBackColor = true;
            // 
            // gInstruction
            // 
            this.gInstruction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gInstruction.Location = new System.Drawing.Point(3, 53);
            this.gInstruction.Name = "gInstruction";
            this.gInstruction.RowHeadersWidth = 51;
            this.gInstruction.RowTemplate.Height = 29;
            this.gInstruction.Size = new System.Drawing.Size(543, 198);
            this.gInstruction.TabIndex = 1;
            // 
            // tblButtons
            // 
            this.tblButtons.ColumnCount = 3;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.06635F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.25118F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.68246F));
            this.tblButtons.Controls.Add(this.btnSave, 0, 0);
            this.tblButtons.Controls.Add(this.btnDelete, 1, 0);
            this.tblButtons.Controls.Add(this.btnChangeStatus, 2, 0);
            this.tblButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblButtons.Location = new System.Drawing.Point(144, 283);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.Size = new System.Drawing.Size(422, 50);
            this.tblButtons.TabIndex = 20;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 44);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(113, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 44);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.AutoSize = true;
            this.btnChangeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeStatus.Location = new System.Drawing.Point(227, 3);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(192, 44);
            this.btnChangeStatus.TabIndex = 2;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // lblStatusDates
            // 
            this.lblStatusDates.AutoSize = true;
            this.lblStatusDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusDates.Location = new System.Drawing.Point(3, 200);
            this.lblStatusDates.Name = "lblStatusDates";
            this.lblStatusDates.Size = new System.Drawing.Size(135, 40);
            this.lblStatusDates.TabIndex = 10;
            this.lblStatusDates.Text = "Status Dates";
            this.lblStatusDates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblStatusDates
            // 
            this.tblStatusDates.ColumnCount = 3;
            this.tblStatusDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStatusDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStatusDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStatusDates.Controls.Add(this.txtDateCreated, 0, 0);
            this.tblStatusDates.Controls.Add(this.txtDatePublished, 1, 0);
            this.tblStatusDates.Controls.Add(this.txtDateArchived, 2, 0);
            this.tblStatusDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStatusDates.Location = new System.Drawing.Point(144, 243);
            this.tblStatusDates.Name = "tblStatusDates";
            this.tblStatusDates.RowCount = 1;
            this.tblStatusDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblStatusDates.Size = new System.Drawing.Size(422, 34);
            this.tblStatusDates.TabIndex = 19;
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateCreated.Enabled = false;
            this.txtDateCreated.Location = new System.Drawing.Point(3, 3);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.Size = new System.Drawing.Size(134, 34);
            this.txtDateCreated.TabIndex = 0;
            // 
            // txtDatePublished
            // 
            this.txtDatePublished.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtDatePublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatePublished.Enabled = false;
            this.txtDatePublished.Location = new System.Drawing.Point(143, 3);
            this.txtDatePublished.Name = "txtDatePublished";
            this.txtDatePublished.Size = new System.Drawing.Size(134, 34);
            this.txtDatePublished.TabIndex = 1;
            // 
            // txtDateArchived
            // 
            this.txtDateArchived.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtDateArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateArchived.Enabled = false;
            this.txtDateArchived.Location = new System.Drawing.Point(283, 3);
            this.txtDateArchived.Name = "txtDateArchived";
            this.txtDateArchived.Size = new System.Drawing.Size(136, 34);
            this.txtDateArchived.TabIndex = 2;
            // 
            // tblStatusTitles
            // 
            this.tblStatusTitles.ColumnCount = 3;
            this.tblStatusTitles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStatusTitles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStatusTitles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStatusTitles.Controls.Add(this.lblDrafted, 0, 0);
            this.tblStatusTitles.Controls.Add(this.lblPublished, 1, 0);
            this.tblStatusTitles.Controls.Add(this.lblArchived, 2, 0);
            this.tblStatusTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStatusTitles.Location = new System.Drawing.Point(144, 203);
            this.tblStatusTitles.Name = "tblStatusTitles";
            this.tblStatusTitles.RowCount = 1;
            this.tblStatusTitles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblStatusTitles.Size = new System.Drawing.Size(422, 34);
            this.tblStatusTitles.TabIndex = 18;
            // 
            // lblDrafted
            // 
            this.lblDrafted.AutoSize = true;
            this.lblDrafted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDrafted.Location = new System.Drawing.Point(3, 0);
            this.lblDrafted.Name = "lblDrafted";
            this.lblDrafted.Size = new System.Drawing.Size(134, 34);
            this.lblDrafted.TabIndex = 0;
            this.lblDrafted.Text = "Drafted";
            this.lblDrafted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            this.lblPublished.AutoSize = true;
            this.lblPublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPublished.Location = new System.Drawing.Point(143, 0);
            this.lblPublished.Name = "lblPublished";
            this.lblPublished.Size = new System.Drawing.Size(134, 34);
            this.lblPublished.TabIndex = 1;
            this.lblPublished.Text = "Published";
            this.lblPublished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            this.lblArchived.AutoSize = true;
            this.lblArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblArchived.Location = new System.Drawing.Point(283, 0);
            this.lblArchived.Name = "lblArchived";
            this.lblArchived.Size = new System.Drawing.Size(136, 34);
            this.lblArchived.TabIndex = 2;
            this.lblArchived.Text = "Archived";
            this.lblArchived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentStatus.Location = new System.Drawing.Point(3, 160);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(135, 40);
            this.lblCurrentStatus.TabIndex = 8;
            this.lblCurrentStatus.Text = "Current Status";
            // 
            // txtRecipeStatus
            // 
            this.txtRecipeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecipeStatus.Enabled = false;
            this.txtRecipeStatus.Location = new System.Drawing.Point(144, 163);
            this.txtRecipeStatus.Name = "txtRecipeStatus";
            this.txtRecipeStatus.Size = new System.Drawing.Size(422, 34);
            this.txtRecipeStatus.TabIndex = 9;
            // 
            // lblCalories
            // 
            this.lblCalories.AutoSize = true;
            this.lblCalories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCalories.Location = new System.Drawing.Point(4, 120);
            this.lblCalories.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(133, 40);
            this.lblCalories.TabIndex = 6;
            this.lblCalories.Text = "Calories:";
            // 
            // txtCalories
            // 
            this.txtCalories.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCalories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCalories.Location = new System.Drawing.Point(144, 123);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(422, 34);
            this.txtCalories.TabIndex = 7;
            // 
            // lblCuisineName
            // 
            this.lblCuisineName.AutoSize = true;
            this.lblCuisineName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCuisineName.Location = new System.Drawing.Point(3, 80);
            this.lblCuisineName.Name = "lblCuisineName";
            this.lblCuisineName.Size = new System.Drawing.Size(135, 40);
            this.lblCuisineName.TabIndex = 4;
            this.lblCuisineName.Text = "Cuisine Name:";
            // 
            // lstCuisineName
            // 
            this.lstCuisineName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCuisineName.FormattingEnabled = true;
            this.lstCuisineName.Location = new System.Drawing.Point(144, 83);
            this.lstCuisineName.Name = "lstCuisineName";
            this.lstCuisineName.Size = new System.Drawing.Size(422, 36);
            this.lstCuisineName.TabIndex = 5;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Location = new System.Drawing.Point(3, 40);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(135, 40);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User:";
            // 
            // lstUsers
            // 
            this.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(144, 43);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(422, 36);
            this.lstUsers.TabIndex = 3;
            // 
            // frmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 633);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRecipe";
            this.Text = "frmRecipe";
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.tbcntrlChildTable.ResumeLayout(false);
            this.tabIngedients.ResumeLayout(false);
            this.tblIngredients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gIngredients)).EndInit();
            this.tabSteps.ResumeLayout(false);
            this.tblInstruction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gInstruction)).EndInit();
            this.tblButtons.ResumeLayout(false);
            this.tblButtons.PerformLayout();
            this.tblStatusDates.ResumeLayout(false);
            this.tblStatusDates.PerformLayout();
            this.tblStatusTitles.ResumeLayout(false);
            this.tblStatusTitles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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