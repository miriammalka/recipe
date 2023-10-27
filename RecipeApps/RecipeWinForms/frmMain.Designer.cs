namespace RecipeWinForms
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecipes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecipesList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloneARecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMeals = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMealsList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCookbooks = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCookbooksList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewCookbook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAutoCreateCookbook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.mnuTile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuRecipes,
            this.mnuMeals,
            this.mnuCookbooks,
            this.mnuDataMaintenance,
            this.mnuWindows});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.mnuMain.Size = new System.Drawing.Size(1100, 38);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDashboard});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(56, 32);
            this.mnuFile.Text = "File";
            // 
            // mnuDashboard
            // 
            this.mnuDashboard.Name = "mnuDashboard";
            this.mnuDashboard.Size = new System.Drawing.Size(194, 32);
            this.mnuDashboard.Text = "Dashboard";
            // 
            // mnuRecipes
            // 
            this.mnuRecipes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRecipesList,
            this.mnuNewRecipe,
            this.mnuCloneARecipe});
            this.mnuRecipes.Name = "mnuRecipes";
            this.mnuRecipes.Size = new System.Drawing.Size(91, 32);
            this.mnuRecipes.Text = "Recipes";
            // 
            // mnuRecipesList
            // 
            this.mnuRecipesList.Name = "mnuRecipesList";
            this.mnuRecipesList.Size = new System.Drawing.Size(225, 32);
            this.mnuRecipesList.Text = "List";
            // 
            // mnuNewRecipe
            // 
            this.mnuNewRecipe.Name = "mnuNewRecipe";
            this.mnuNewRecipe.Size = new System.Drawing.Size(225, 32);
            this.mnuNewRecipe.Text = "New Recipe";
            // 
            // mnuCloneARecipe
            // 
            this.mnuCloneARecipe.Name = "mnuCloneARecipe";
            this.mnuCloneARecipe.Size = new System.Drawing.Size(225, 32);
            this.mnuCloneARecipe.Text = "Clone a Recipe";
            // 
            // mnuMeals
            // 
            this.mnuMeals.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMealsList});
            this.mnuMeals.Name = "mnuMeals";
            this.mnuMeals.Size = new System.Drawing.Size(77, 32);
            this.mnuMeals.Text = "Meals";
            // 
            // mnuMealsList
            // 
            this.mnuMealsList.Name = "mnuMealsList";
            this.mnuMealsList.Size = new System.Drawing.Size(127, 32);
            this.mnuMealsList.Text = "List";
            // 
            // mnuCookbooks
            // 
            this.mnuCookbooks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCookbooksList,
            this.mnuNewCookbook,
            this.mnuAutoCreateCookbook});
            this.mnuCookbooks.Name = "mnuCookbooks";
            this.mnuCookbooks.Size = new System.Drawing.Size(126, 32);
            this.mnuCookbooks.Text = "Cookbooks";
            // 
            // mnuCookbooksList
            // 
            this.mnuCookbooksList.Name = "mnuCookbooksList";
            this.mnuCookbooksList.Size = new System.Drawing.Size(234, 32);
            this.mnuCookbooksList.Text = "List";
            // 
            // mnuNewCookbook
            // 
            this.mnuNewCookbook.Name = "mnuNewCookbook";
            this.mnuNewCookbook.Size = new System.Drawing.Size(234, 32);
            this.mnuNewCookbook.Text = "New Cookbook";
            // 
            // mnuAutoCreateCookbook
            // 
            this.mnuAutoCreateCookbook.Name = "mnuAutoCreateCookbook";
            this.mnuAutoCreateCookbook.Size = new System.Drawing.Size(234, 32);
            this.mnuAutoCreateCookbook.Text = "Auto-Create";
            // 
            // mnuDataMaintenance
            // 
            this.mnuDataMaintenance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditData});
            this.mnuDataMaintenance.Name = "mnuDataMaintenance";
            this.mnuDataMaintenance.Size = new System.Drawing.Size(184, 32);
            this.mnuDataMaintenance.Text = "Data Maintenance";
            // 
            // mnuEditData
            // 
            this.mnuEditData.Name = "mnuEditData";
            this.mnuEditData.Size = new System.Drawing.Size(178, 32);
            this.mnuEditData.Text = "Edit Data";
            // 
            // mnuWindows
            // 
            this.mnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTile,
            this.mnuCascade});
            this.mnuWindows.Name = "mnuWindows";
            this.mnuWindows.Size = new System.Drawing.Size(107, 32);
            this.mnuWindows.Text = "Windows";
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Location = new System.Drawing.Point(0, 38);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1100, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // mnuTile
            // 
            this.mnuTile.Name = "mnuTile";
            this.mnuTile.Size = new System.Drawing.Size(224, 32);
            this.mnuTile.Text = "Tile";
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(224, 32);
            this.mnuCascade.Text = "Cascade";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 630);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Hearty Hearth";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuDashboard;
        private ToolStripMenuItem mnuRecipes;
        private ToolStripMenuItem mnuRecipesList;
        private ToolStripMenuItem mnuNewRecipe;
        private ToolStripMenuItem mnuCloneARecipe;
        private ToolStripMenuItem mnuMeals;
        private ToolStripMenuItem mnuMealsList;
        private ToolStripMenuItem mnuCookbooks;
        private ToolStripMenuItem mnuCookbooksList;
        private ToolStripMenuItem mnuNewCookbook;
        private ToolStripMenuItem mnuAutoCreateCookbook;
        private ToolStripMenuItem mnuDataMaintenance;
        private ToolStripMenuItem mnuEditData;
        private ToolStripMenuItem mnuWindows;
        private ToolStrip tsMain;
        private ToolStripMenuItem mnuTile;
        private ToolStripMenuItem mnuCascade;
    }
}