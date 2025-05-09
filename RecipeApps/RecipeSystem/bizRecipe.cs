﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizRecipe : bizObject<bizRecipe>
    {
        public bizRecipe() 
        {

        }
        private int _recipeId;
        //private string _cuisinename;
        private int _cuisineId;
        //private string _username;
        private int _usersId;
        private string _recipename = "";
        private int _calories;
        private DateTime _datecreated;
        private DateTime? _datepublished;
        private DateTime? _datearchived;
        private bool _vegan;
        private List<bizRecipeIngredient> _lstrecipeingredient;
        private List<bizInstruction> _lstinstruction;

        public List<bizRecipe> Search(string recipenameval, int cuisineid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipenameval);
            SQLUtility.SetParamValue(cmd, "@CuisineId", cuisineid);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }



        //public void CloneRecipe(int baserecipeid)
        //{
        //    SqlCommand cmd = SQLUtility.GetSQLCommand("CloneRecipe");
        //    SQLUtility.SetParamValue(cmd, "@BaseRecipeId", baserecipeid);
        //    SQLUtility.ExecuteSQL(cmd);
        //}

        public bizRecipe CloneRecipe(int baseRecipeId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CloneRecipe");

            SQLUtility.SetParamValue(cmd, "@BaseRecipeId", baseRecipeId);
            SQLUtility.SetParamValue(cmd, "@RecipeId", 0); // Output param
            SQLUtility.SetParamValue(cmd, "@Message", string.Empty);

            SQLUtility.ExecuteSQL(cmd);

            DataTable dtrecipe = SQLUtility.GetDataTable("select * from recipe r order by r.recipeid desc");
            int newRecipeId = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");

            var recipe = new bizRecipe();
            recipe.Load(newRecipeId);

            return recipe;
        }


        public int RecipeId 
        { 
            get { return _recipeId; } 
            set 
            { 
                if (_recipeId != value)
                {
                    _recipeId = value;
                    InvokePropertyChanged();
                }
            } 
        }

        //public string CuisineName
        //{
        //    get { return _cuisinename; }
        //    set
        //    {
        //        if (_cuisinename != value)
        //        {
        //            _cuisinename = value;
        //            InvokePropertyChanged();
        //        }
        //    }
        //}
        public int CuisineId
        {
            get { return _cuisineId; }
            set
            {
                if (_cuisineId != value)
                {
                    _cuisineId = value;
                    InvokePropertyChanged();
                }
            }
        }
        //public string UserName
        //{
        //    get { return _username; }
        //    set
        //    {
        //        if (_username != value)
        //        {
        //            _username = value;
        //            InvokePropertyChanged();
        //        }
        //    }
        //}

        public int UsersId
        {
            get { return _usersId; }
            set
            {
                if (_usersId != value)
                {
                    _usersId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string RecipeName
        {
            get { return _recipename; }
            set
            {
                if (_recipename != value)
                {
                    _recipename = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int Calories
        {
            get { return _calories; }
            set
            {
                if (_calories != value)
                {
                    _calories = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime DateCreated
        {
            get { return _datecreated; }
            set
            {
                if (_datecreated != value)
                {
                    _datecreated = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime? DatePublished
        {
            get { return _datepublished; }
            set
            {
                if (_datepublished != value)
                {
                    _datepublished = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime? DateArchived
        {
            get { return _datearchived; }
            set
            {
                if (_datearchived != value)
                {
                    _datearchived = value;
                    InvokePropertyChanged();
                }
            }
        }

        public bool Vegan
        {
            get { return _vegan; }
            set
            {
                if (_vegan != value)
                {
                    _vegan = value;
                    InvokePropertyChanged();
                }
            }
        }

        public List<bizRecipeIngredient> RecipeIngredientList
        {
            get
            {
                if(_lstrecipeingredient == null)
                {
                    _lstrecipeingredient = new bizRecipeIngredient().LoadByRecipeId(RecipeId);
                }
                return _lstrecipeingredient;
            }
        }

        public List<bizInstruction> InstructionList
        {
            get
            {
                if (_lstinstruction == null)
                {
                    _lstinstruction = new bizInstruction().LoadByRecipeId(RecipeId);
                }
                return _lstinstruction;
            }
        }

    }
}
