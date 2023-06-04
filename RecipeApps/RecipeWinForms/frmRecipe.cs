using System.Data;


namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe;
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        public void ShowForm(int recipeid)
        {
            dtrecipe = Recipe.Load(recipeid);
            if (recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }
            DataTable dtcuisine = Recipe.GetCuisineList();
            WindowsFormsUtility.SetListBinding(lstCuisineName, dtcuisine, dtrecipe, "Cuisine");

            DataTable dtusers = Recipe.GetUsersList();
            WindowsFormsUtility.SetListBinding(lstUserName, dtusers, dtrecipe, "User");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, dtrecipe);
            WindowsFormsUtility.SetControlBinding(lblDatePublished, dtrecipe);
            WindowsFormsUtility.SetControlBinding(lblDateArchived, dtrecipe);

            this.Show();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtrecipe);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "RecipeDB");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
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

        private void txtPicture_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
