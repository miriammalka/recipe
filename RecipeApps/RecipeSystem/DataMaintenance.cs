﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class DataMaintenance
    {
        public static DataTable GetDashboard()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("DashboardGet");
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable GetDataList(string tablename, bool includeblank = false)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand(tablename + "Get");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            if (includeblank == true)
            {
                SQLUtility.SetParamValue(cmd, "@IncludeBlank", includeblank);
            }
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveDataList(DataTable dt, string tablename)
        {
            SQLUtility.SaveDataTable(dt, tablename + "Update");
        }

        public static void DeleteRow(string tablename, int id)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(tablename + "Delete");
            SQLUtility.SetParamValue(cmd, $"@{tablename}Id", id);
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
