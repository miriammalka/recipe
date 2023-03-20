using CPUFramework;
using System.Data;
using CPUWindowsFormsFramework;

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
            string sql = "select * from Recipe r " +
                "join Cuisine c on c.CuisineId = r.CuisineId " +
                "join Users u on u.UserId = r.UserId " +
                "where r.RecipeId =" + recipeid.ToString();
            dtrecipe = SQLUtility.GetDataTable(sql);
            if (recipeid == 0)
            {
                dtrecipe.Rows.Add();
                //is there a way to make the textboxes of the recipe status and picture automatically be filled in based on my sql code? I don't think we learned how to do this yet.
            }
            DataTable dtcuisine = SQLUtility.GetDataTable("select * from Cuisine");
            WindowsFormsUtility.SetListBinding(lstCuisineName, dtcuisine, dtrecipe, "Cuisine");

            DataTable dtusers = SQLUtility.GetDataTable("select * from Users");
            WindowsFormsUtility.SetListBinding(lstUserName, dtusers, dtrecipe, "User");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, dtrecipe);
            WindowsFormsUtility.SetControlBinding(lblDatePublished, dtrecipe);
            WindowsFormsUtility.SetControlBinding(lblDateArchived, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtPicture, dtrecipe);
            this.Show();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            DataRow r = dtrecipe.Rows[0];
            int id = (int)r["RecipeId"];
            string sql;
            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
            $"CuisineId = '{r["CuisineId"]}',",
            $"UserId = '{r["UserId"]}',",
            $"RecipeName = '{r["RecipeName"]}',",
            $"Calories = '{r["Calories"]}',",
            $"DateCreated = '{r["DateCreated"]}'", //got rid of comma here to test out without the nullable columns
          //  $"DatePublished = '{r["DatePublished"]}',",
          //  $"DateArchived = '{r["DateArchived"]}'",
            $"where RecipeId = '{r["RecipeId"]}'");
                SQLUtility.ExecuteSQL(sql);
            }
            else
            {
                sql = "Insert Recipe(CuisineId, UserId, RecipeName, Calories, DateCreated)";
                sql += $"select '{r["CuisineId"]}', '{r["UserId"]}', '{r["RecipeName"]}', '{r["Calories"]}', '{r["DateCreated"]}'";
                SQLUtility.ExecuteSQL(sql);
            }
        }

        private void Delete()
        {
            int id = (int)dtrecipe.Rows[0]["RecipeId"];
            string sql = "delete recipe where RecipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
            this.Close();
        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

    }
}
