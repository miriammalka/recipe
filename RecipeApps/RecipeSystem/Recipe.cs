using System.Data;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipes(string recipe)
        {
            string sql = "select c.CuisineName, u.UserName, r.* from recipe r " +
            "join Cuisine c on c.CuisineId = r.CuisineId " +
            "join Users u on u.UserId = r.UserId " +
            "where r.RecipeName like '%" + recipe + "%'";
            return SQLUtility.GetDataTable(sql);
        }

        public static DataTable Load(int recipeid)
        {
            string sql = "select * from Recipe r " +
            "join Cuisine c on c.CuisineId = r.CuisineId " +
            "join Users u on u.UserId = r.UserId " +
            "where r.RecipeId =" + recipeid.ToString();
            return SQLUtility.GetDataTable(sql);
        }

        public static DataTable GetCuisineList()
        {
            return SQLUtility.GetDataTable("select * from Cuisine");
        }

        public static DataTable GetUsersList()
        {
            return SQLUtility.GetDataTable("select * from Users");
        }

        public static void Save(DataTable dtrecipe)
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
            $"DateCreated = '{r["DateCreated"]}'", 
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

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["RecipeId"];
            string sql = "delete r from recipe r left join recipeingredient ri on ri.recipeid = r.recipeid where ri.recipeid is null and r.recipeid = " + id;
            SQLUtility.ExecuteSQL(sql);
        }
    }
}
