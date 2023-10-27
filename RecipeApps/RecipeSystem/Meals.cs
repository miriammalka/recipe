using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class Meals
    {
        public static DataTable GetMealsList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("MealGet");
            cmd.Parameters["@All"].Value = 1;
            return SQLUtility.GetDataTable(cmd);
        }
    }
}
