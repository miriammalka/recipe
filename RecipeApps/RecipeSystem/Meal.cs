using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class Meal
    {
        public static DataTable GetMealsList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("MealGet");
            cmd.Parameters["@All"].Value = 1;
            return SQLUtility.GetDataTable(cmd);
        }
    }
}
