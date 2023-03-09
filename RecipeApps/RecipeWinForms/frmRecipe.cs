using CPUFramework;
using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }
        public void ShowForm(int recipeid)
        {
//AS Include the two fk:Cuisine and User. Display the names not the fk, you will have to do a join to those tables to get back these values.
            string sql = "select * from Recipe r where r.RecipeId =" + recipeid.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtDateCreated.DataBindings.Add("Text", dt, "DateCreated");
            txtDatePublished.DataBindings.Add("Text", dt, "DatePublished");
            txtDateArchived.DataBindings.Add("Text", dt, "DateArchived");
            txtRecipeStatus.DataBindings.Add("Text", dt, "RecipeStatus");
            txtPicture.DataBindings.Add("Text", dt, "Picture");
            this.Show();
        }
    }
}
