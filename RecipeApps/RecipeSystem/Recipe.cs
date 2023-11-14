using System.Data;
using System.Data.SqlClient;

namespace RecipeSystem
{
    public class Recipe
    {

        public static DataTable GetRecipeList(int recipeid = 0)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            return SQLUtility.GetDataTable(cmd);
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
            if(dtrecipe.Rows.Count == 0)
            {
                throw new Exception("Cannot call Recipe Save method because there are no rows in the recipe table");
            }
            DataRow r = dtrecipe.Rows[0];
            SQLUtility.SaveDataRow(r, "RecipeUpdate");
        }

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["RecipeId"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static void CloneRecipe(int baserecipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CloneRecipe");            
            SQLUtility.SetParamValue(cmd, "@BaseRecipeId", baserecipeid);
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
