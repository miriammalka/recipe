using CPUFramework;
using RecipeSystem;
using System.Data;


namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe;
        DataTable dtrecipeingredient = new();
        DataTable dtInstruction = new();
        int recipeid = 0;
        string deletecolname = "deletecol";
        public BindingSource bindsource = new();
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChangeStatus.Click += BtnChangeStatus_Click;
            btnSaveIngredients.Click += BtnSaveIngredients_Click;
            btnSaveInstruction.Click += BtnSaveInstruction_Click;
            gIngredients.CellContentClick += GIngredients_CellContentClick;
            gInstruction.CellContentClick += GInstruction_CellContentClick;
            tabIngedients.Click += TabIngedients_Click;
            tabSteps.Click += TabSteps_Click;
            this.FormClosing += FrmRecipe_FormClosing;
            
        }


        public void LoadRecipeForm(int recipeidval)
        {
            recipeid = recipeidval;
            this.Tag = recipeid;
            dtrecipe = Recipe.Load(recipeid);
            bindsource.DataSource = dtrecipe;
            if (recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }
            DataTable dtcuisine = Recipe.GetCuisineList();
            WindowsFormsUtility.SetListBinding(lstCuisineName, dtcuisine, dtrecipe, "Cuisine");

            DataTable dtusers = Recipe.GetUsersList();
            WindowsFormsUtility.SetListBinding(lstUsers, dtusers, dtrecipe, "Users");
         
            WindowsFormsUtility.SetControlBinding(txtRecipeName, bindsource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, bindsource);

            LoadRecipeIngredients();
            LoadRecipeInstructions();
            SetButtonsEnabledBasedOnNewRecord();
            this.Text = GetRecipeDesc();
           
        }

        private string GetRecipeDesc()
        {
            string value = "New Recipe";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");
            if (pkvalue > 0)
            {
                value = "Recipe - " + SQLUtility.GetValueFromFirstRowAsString(dtrecipe, "RecipeName");
            }
            return value;
        }

        private void LoadRecipeIngredients()
        {
            dtrecipeingredient = RecipeIngredient.LoadByRecipeId(recipeid);
            gIngredients.Columns.Clear();
            gIngredients.DataSource = dtrecipeingredient;
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, DataMaintenance.GetDataList("Ingredient"), "Ingredient", "IngredientName");
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, DataMaintenance.GetDataList("MeasurementType"), "MeasurementType", "MeasurementType");
            WindowsFormsUtility.AddDeleteButtonToGrid(gIngredients, deletecolname);
            WindowsFormsUtility.FormatGridForEdit(gIngredients, "RecipeIngredient");
            
        }

        private void LoadRecipeInstructions()
        {
            dtInstruction = Instruction.LoadByRecipeId(recipeid);
            gInstruction.Columns.Clear();
            gInstruction.DataSource = dtInstruction;
            WindowsFormsUtility.AddDeleteButtonToGrid(gInstruction, deletecolname);
            WindowsFormsUtility.FormatGridForEdit(gInstruction, "Instruction");
        }

        private void TabSteps_Click(object? sender, EventArgs e)
        {
            tabSteps.Show();
        }

        private void TabIngedients_Click(object? sender, EventArgs e)
        {
            tabIngedients.Show();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtrecipe);
                b = true;
                bindsource.ResetBindings(true);
                recipeid = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");
                this.Tag = recipeid;
                SetButtonsEnabledBasedOnNewRecord();
                this.Text = GetRecipeDesc();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }


        private void SaveRecipeIngredient()
        {
            try
            {
                RecipeIngredient.SaveTable(dtrecipeingredient, recipeid);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void SaveRecipeInstruction()
        {
            try
            {
               Instruction.SaveTable(dtInstruction, recipeid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void BtnSaveIngredients_Click(object? sender, EventArgs e)
        {
            SaveRecipeIngredient();
        }

        private void BtnSaveInstruction_Click(object? sender, EventArgs e)
        {
            SaveRecipeInstruction();
        }

        private void Delete()
        {
            var response = MessageBox.Show("Are you sure you want to delete this recipe?", "RecipeDB", MessageBoxButtons.YesNo); ;
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Delete(dtrecipe);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RecipeDB");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            
        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void DeleteRecipeIngredient(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gIngredients, rowindex, "RecipeIngredientId");
            if(id > 0)
            {
                try
                {
                    RecipeIngredient.Delete(id);
                    LoadRecipeIngredients();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if(id < gIngredients.Rows.Count)
            {
                gIngredients.Rows.RemoveAt(rowindex);
            }
        }

        private void DeleteInstruction(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gInstruction, rowindex, "InstructionId");
            if (id > 0)
            {
                try
                {
                    Instruction.Delete(id);
                    LoadRecipeInstructions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < gInstruction.Rows.Count)
            {
                gInstruction.Rows.RemoveAt(rowindex);
            }
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool b = recipeid == 0 ? false : true;
            btnDelete.Enabled = b;
            btnChangeStatus.Enabled = b;
            btnSaveIngredients.Enabled = b;
            btnSaveInstruction.Enabled = b;
            
        }



        private void GIngredients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteRecipeIngredient(e.RowIndex);
        }

        private void GInstruction_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteInstruction(e.RowIndex);
        }

        private void FrmRecipe_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindsource.EndEdit();
            if (SQLUtility.TableHasChanges(dtrecipe))
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing the form?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if(b == false)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        this.Activate();
                        break;
                }
            }
        }

        private void BtnChangeStatus_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmChangeStatus),recipeid);
                
            }
            
        }
    }
}
