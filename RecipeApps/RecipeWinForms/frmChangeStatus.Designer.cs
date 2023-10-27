namespace RecipeWinForms
{
    partial class frmChangeStatus
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
            this.tblStatusDates = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatusDates = new System.Windows.Forms.Label();
            this.lblDrafted = new System.Windows.Forms.Label();
            this.lblPublished = new System.Windows.Forms.Label();
            this.lblArchived = new System.Windows.Forms.Label();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.txtDatePublished = new System.Windows.Forms.TextBox();
            this.txtDateArchived = new System.Windows.Forms.TextBox();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnDraft = new System.Windows.Forms.Button();
            this.btnPublished = new System.Windows.Forms.Button();
            this.btnArchived = new System.Windows.Forms.Button();
            this.tblStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblRecipeStatus = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.tblStatusDates.SuspendLayout();
            this.tblButtons.SuspendLayout();
            this.tblStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Controls.Add(this.lblRecipeName, 0, 0);
            this.tblMain.Controls.Add(this.tblStatusDates, 0, 2);
            this.tblMain.Controls.Add(this.tblButtons, 0, 3);
            this.tblMain.Controls.Add(this.tblStatus, 0, 1);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 4;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMain.Size = new System.Drawing.Size(800, 450);
            this.tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecipeName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRecipeName.Location = new System.Drawing.Point(3, 0);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(794, 112);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblStatusDates
            // 
            this.tblStatusDates.ColumnCount = 4;
            this.tblStatusDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblStatusDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblStatusDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblStatusDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblStatusDates.Controls.Add(this.lblStatusDates, 0, 0);
            this.tblStatusDates.Controls.Add(this.lblDrafted, 1, 0);
            this.tblStatusDates.Controls.Add(this.lblPublished, 2, 0);
            this.tblStatusDates.Controls.Add(this.lblArchived, 3, 0);
            this.tblStatusDates.Controls.Add(this.txtDateCreated, 1, 1);
            this.tblStatusDates.Controls.Add(this.txtDatePublished, 2, 1);
            this.tblStatusDates.Controls.Add(this.txtDateArchived, 3, 1);
            this.tblStatusDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStatusDates.Location = new System.Drawing.Point(3, 227);
            this.tblStatusDates.Name = "tblStatusDates";
            this.tblStatusDates.RowCount = 2;
            this.tblStatusDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatusDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatusDates.Size = new System.Drawing.Size(794, 106);
            this.tblStatusDates.TabIndex = 2;
            // 
            // lblStatusDates
            // 
            this.lblStatusDates.AutoSize = true;
            this.lblStatusDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusDates.Location = new System.Drawing.Point(3, 0);
            this.lblStatusDates.Name = "lblStatusDates";
            this.tblStatusDates.SetRowSpan(this.lblStatusDates, 2);
            this.lblStatusDates.Size = new System.Drawing.Size(192, 106);
            this.lblStatusDates.TabIndex = 0;
            this.lblStatusDates.Text = "Status Dates:";
            this.lblStatusDates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDrafted
            // 
            this.lblDrafted.AutoSize = true;
            this.lblDrafted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDrafted.Location = new System.Drawing.Point(201, 0);
            this.lblDrafted.Name = "lblDrafted";
            this.lblDrafted.Size = new System.Drawing.Size(192, 53);
            this.lblDrafted.TabIndex = 1;
            this.lblDrafted.Text = "Drafted";
            this.lblDrafted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            this.lblPublished.AutoSize = true;
            this.lblPublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPublished.Location = new System.Drawing.Point(399, 0);
            this.lblPublished.Name = "lblPublished";
            this.lblPublished.Size = new System.Drawing.Size(192, 53);
            this.lblPublished.TabIndex = 2;
            this.lblPublished.Text = "Published";
            this.lblPublished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            this.lblArchived.AutoSize = true;
            this.lblArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblArchived.Location = new System.Drawing.Point(597, 0);
            this.lblArchived.Name = "lblArchived";
            this.lblArchived.Size = new System.Drawing.Size(194, 53);
            this.lblArchived.TabIndex = 3;
            this.lblArchived.Text = "Archived";
            this.lblArchived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateCreated.Location = new System.Drawing.Point(201, 56);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.Size = new System.Drawing.Size(192, 27);
            this.txtDateCreated.TabIndex = 4;
            // 
            // txtDatePublished
            // 
            this.txtDatePublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatePublished.Location = new System.Drawing.Point(399, 56);
            this.txtDatePublished.Name = "txtDatePublished";
            this.txtDatePublished.Size = new System.Drawing.Size(192, 27);
            this.txtDatePublished.TabIndex = 5;
            // 
            // txtDateArchived
            // 
            this.txtDateArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateArchived.Location = new System.Drawing.Point(597, 56);
            this.txtDateArchived.Name = "txtDateArchived";
            this.txtDateArchived.Size = new System.Drawing.Size(194, 27);
            this.txtDateArchived.TabIndex = 6;
            // 
            // tblButtons
            // 
            this.tblButtons.ColumnCount = 3;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.Controls.Add(this.btnDraft, 0, 0);
            this.tblButtons.Controls.Add(this.btnPublished, 1, 0);
            this.tblButtons.Controls.Add(this.btnArchived, 2, 0);
            this.tblButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblButtons.Location = new System.Drawing.Point(3, 339);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tblButtons.Size = new System.Drawing.Size(794, 108);
            this.tblButtons.TabIndex = 3;
            // 
            // btnDraft
            // 
            this.btnDraft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDraft.Location = new System.Drawing.Point(3, 3);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(258, 102);
            this.btnDraft.TabIndex = 0;
            this.btnDraft.Text = "Draft";
            this.btnDraft.UseVisualStyleBackColor = true;
            // 
            // btnPublished
            // 
            this.btnPublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPublished.Location = new System.Drawing.Point(267, 3);
            this.btnPublished.Name = "btnPublished";
            this.btnPublished.Size = new System.Drawing.Size(258, 102);
            this.btnPublished.TabIndex = 1;
            this.btnPublished.Text = "Publish";
            this.btnPublished.UseVisualStyleBackColor = true;
            // 
            // btnArchived
            // 
            this.btnArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArchived.Location = new System.Drawing.Point(531, 3);
            this.btnArchived.Name = "btnArchived";
            this.btnArchived.Size = new System.Drawing.Size(260, 102);
            this.btnArchived.TabIndex = 2;
            this.btnArchived.Text = "Archive";
            this.btnArchived.UseVisualStyleBackColor = true;
            // 
            // tblStatus
            // 
            this.tblStatus.ColumnCount = 2;
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.Controls.Add(this.lblCurrentStatus, 0, 0);
            this.tblStatus.Controls.Add(this.lblRecipeStatus, 1, 0);
            this.tblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStatus.Location = new System.Drawing.Point(3, 115);
            this.tblStatus.Name = "tblStatus";
            this.tblStatus.RowCount = 1;
            this.tblStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.Size = new System.Drawing.Size(794, 106);
            this.tblStatus.TabIndex = 4;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentStatus.Location = new System.Drawing.Point(3, 0);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(391, 106);
            this.lblCurrentStatus.TabIndex = 0;
            this.lblCurrentStatus.Text = "Current Status:";
            this.lblCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecipeStatus
            // 
            this.lblRecipeStatus.AutoSize = true;
            this.lblRecipeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecipeStatus.Location = new System.Drawing.Point(400, 0);
            this.lblRecipeStatus.Name = "lblRecipeStatus";
            this.lblRecipeStatus.Size = new System.Drawing.Size(391, 106);
            this.lblRecipeStatus.TabIndex = 1;
            this.lblRecipeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmChangeStatus";
            this.Text = "Change Status";
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.tblStatusDates.ResumeLayout(false);
            this.tblStatusDates.PerformLayout();
            this.tblButtons.ResumeLayout(false);
            this.tblStatus.ResumeLayout(false);
            this.tblStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private TableLayoutPanel tblStatusDates;
        private Label lblStatusDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TextBox txtDateCreated;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private TableLayoutPanel tblButtons;
        private Button btnDraft;
        private Button btnPublished;
        private Button btnArchived;
        private TableLayoutPanel tblStatus;
        private Label lblCurrentStatus;
        private Label lblRecipeStatus;
    }
}