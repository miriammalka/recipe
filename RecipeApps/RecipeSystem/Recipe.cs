using System.Data;
using System.Data.SqlClient;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipes(string recipe)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipe);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetUsersList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("UsersGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
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
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
