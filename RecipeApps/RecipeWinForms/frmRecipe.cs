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
            string sql = "select * from Recipe r " +
                "join Cuisine c on c.CuisineId = r.CuisineId " +
                "join Users u on u.UserId = r.UserId " +
                "where r.RecipeId =" + recipeid.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtCuisineName.DataBindings.Add("Text", dt, "CuisineName");
            txtUserName.DataBindings.Add("Text", dt, "UserName");
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
