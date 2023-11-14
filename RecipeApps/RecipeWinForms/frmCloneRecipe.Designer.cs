namespace RecipeWinForms
{
    partial class frmCloneRecipe
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
            lstRecipeName = new ComboBox();
            btnClone = new Button();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lstRecipeName, 0, 0);
            tblMain.Controls.Add(btnClone, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(582, 160);
            tblMain.TabIndex = 0;
            // 
            // lstRecipeName
            // 
            lstRecipeName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lstRecipeName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lstRecipeName.FormattingEnabled = true;
            lstRecipeName.Location = new Point(3, 41);
            lstRecipeName.Name = "lstRecipeName";
            lstRecipeName.Size = new Size(294, 36);
            lstRecipeName.TabIndex = 0;
            // 
            // btnClone
            // 
            btnClone.Location = new Point(3, 83);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(146, 47);
            btnClone.TabIndex = 1;
            btnClone.Text = "Clone";
            btnClone.UseVisualStyleBackColor = true;
            // 
            // frmCloneRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 160);
            Controls.Add(tblMain);
            Name = "frmCloneRecipe";
            Text = "Clone Recipe";
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private ComboBox lstRecipeName;
        private Button btnClone;
    }
}