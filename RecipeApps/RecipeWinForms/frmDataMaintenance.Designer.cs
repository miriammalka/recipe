namespace RecipeWinForms
{
    partial class frmDataMaintenance
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
            this.btnSave = new System.Windows.Forms.Button();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.optUsers = new System.Windows.Forms.RadioButton();
            this.optCuisines = new System.Windows.Forms.RadioButton();
            this.optIngredients = new System.Windows.Forms.RadioButton();
            this.optMeasurements = new System.Windows.Forms.RadioButton();
            this.optCourses = new System.Windows.Forms.RadioButton();
            this.gData = new System.Windows.Forms.DataGridView();
            this.tblMain.SuspendLayout();
            this.tblButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gData)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblMain.Controls.Add(this.btnSave, 0, 0);
            this.tblMain.Controls.Add(this.tblButtons, 0, 1);
            this.tblMain.Controls.Add(this.gData, 1, 1);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tblMain.Size = new System.Drawing.Size(800, 450);
            this.tblMain.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 39);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tblButtons
            // 
            this.tblButtons.ColumnCount = 1;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.Controls.Add(this.optUsers, 0, 0);
            this.tblButtons.Controls.Add(this.optCuisines, 0, 1);
            this.tblButtons.Controls.Add(this.optIngredients, 0, 2);
            this.tblButtons.Controls.Add(this.optMeasurements, 0, 3);
            this.tblButtons.Controls.Add(this.optCourses, 0, 4);
            this.tblButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblButtons.Location = new System.Drawing.Point(3, 48);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 5;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblButtons.Size = new System.Drawing.Size(234, 399);
            this.tblButtons.TabIndex = 1;
            // 
            // optUsers
            // 
            this.optUsers.AutoSize = true;
            this.optUsers.Checked = true;
            this.optUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optUsers.Location = new System.Drawing.Point(3, 3);
            this.optUsers.Name = "optUsers";
            this.optUsers.Size = new System.Drawing.Size(228, 73);
            this.optUsers.TabIndex = 0;
            this.optUsers.TabStop = true;
            this.optUsers.Text = "Users";
            this.optUsers.UseVisualStyleBackColor = true;
            // 
            // optCuisines
            // 
            this.optCuisines.AutoSize = true;
            this.optCuisines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optCuisines.Location = new System.Drawing.Point(3, 82);
            this.optCuisines.Name = "optCuisines";
            this.optCuisines.Size = new System.Drawing.Size(228, 73);
            this.optCuisines.TabIndex = 1;
            this.optCuisines.Text = "Cuisines";
            this.optCuisines.UseVisualStyleBackColor = true;
            // 
            // optIngredients
            // 
            this.optIngredients.AutoSize = true;
            this.optIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optIngredients.Location = new System.Drawing.Point(3, 161);
            this.optIngredients.Name = "optIngredients";
            this.optIngredients.Size = new System.Drawing.Size(228, 73);
            this.optIngredients.TabIndex = 2;
            this.optIngredients.Text = "Ingredients";
            this.optIngredients.UseVisualStyleBackColor = true;
            // 
            // optMeasurements
            // 
            this.optMeasurements.AutoSize = true;
            this.optMeasurements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optMeasurements.Location = new System.Drawing.Point(3, 240);
            this.optMeasurements.Name = "optMeasurements";
            this.optMeasurements.Size = new System.Drawing.Size(228, 73);
            this.optMeasurements.TabIndex = 3;
            this.optMeasurements.Text = "Measurements";
            this.optMeasurements.UseVisualStyleBackColor = true;
            // 
            // optCourses
            // 
            this.optCourses.AutoSize = true;
            this.optCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optCourses.Location = new System.Drawing.Point(3, 319);
            this.optCourses.Name = "optCourses";
            this.optCourses.Size = new System.Drawing.Size(228, 77);
            this.optCourses.TabIndex = 4;
            this.optCourses.Text = "Courses";
            this.optCourses.UseVisualStyleBackColor = true;
            // 
            // gData
            // 
            this.gData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gData.Location = new System.Drawing.Point(243, 48);
            this.gData.Name = "gData";
            this.gData.RowHeadersWidth = 51;
            this.gData.RowTemplate.Height = 29;
            this.gData.Size = new System.Drawing.Size(554, 399);
            this.gData.TabIndex = 2;
            // 
            // frmDataMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblMain);
            this.Name = "frmDataMaintenance";
            this.Text = "Data Maintenance";
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.tblButtons.ResumeLayout(false);
            this.tblButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnSave;
        private TableLayoutPanel tblButtons;
        private RadioButton optUsers;
        private RadioButton optCuisines;
        private RadioButton optIngredients;
        private RadioButton optMeasurements;
        private RadioButton optCourses;
        private DataGridView gData;
    }
}