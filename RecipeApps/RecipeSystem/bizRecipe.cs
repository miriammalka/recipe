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
        private int _cuisineId;
        private int _usersId;
        private string _recipename = "";
        private int _calories;
        private DateTime _datecreated;
        private DateTime? _datepublished;
        private DateTime? _datearchived;

        public List<bizRecipe> Search(string recipenameval)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipenameval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
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

    }
}
