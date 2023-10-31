namespace RecipeWinForms
{
    partial class frmAutoCreateCookbook
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
            lstUsers = new ComboBox();
            btnAutoCreateCookbook = new Button();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lstUsers, 0, 0);
            tblMain.Controls.Add(btnAutoCreateCookbook, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(789, 235);
            tblMain.TabIndex = 0;
            // 
            // lstUsers
            // 
            lstUsers.Anchor = AnchorStyles.None;
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(67, 100);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(260, 28);
            lstUsers.TabIndex = 0;
            lstUsers.Text = "Select a User";
            // 
            // btnAutoCreateCookbook
            // 
            btnAutoCreateCookbook.Anchor = AnchorStyles.None;
            btnAutoCreateCookbook.Location = new Point(455, 97);
            btnAutoCreateCookbook.Name = "btnAutoCreateCookbook";
            btnAutoCreateCookbook.Size = new Size(273, 41);
            btnAutoCreateCookbook.TabIndex = 1;
            btnAutoCreateCookbook.Text = "Create Cookbook";
            btnAutoCreateCookbook.UseVisualStyleBackColor = true;
            // 
            // frmAutoCreateCookbook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 235);
            Controls.Add(tblMain);
            Name = "frmAutoCreateCookbook";
            Text = "Auto-Create a Cookbook";
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private ComboBox lstUsers;
        private Button btnAutoCreateCookbook;
    }
}