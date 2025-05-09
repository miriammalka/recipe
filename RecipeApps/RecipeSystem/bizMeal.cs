﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizMeal: bizObject<bizMeal>
    {
        public bizMeal()
        {

        }
        //need to find out if have to change to match result of mealget sproc
        private int _mealId;
        private string _username;
        private string _mealname = "";
        private DateTime _datecreated;
        private bool _active;
        private int _numcalories;
        private int _numcourses;
        private int _numrecipes;
        private string _mealdesc;

        public int MealId
        {
            get { return _mealId; }
            set
            {
                if (_mealId != value)
                {
                    _mealId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MealName
        {
            get { return _mealname; }
            set
            {
                if (_mealname != value)
                {
                    _mealname = value;
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

        public bool Active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumCalories
        {
            get { return _numcalories; }
            set
            {
                if (_numcalories != value)
                {
                    _numcalories = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumCourses
        {
            get { return _numcourses; }
            set
            {
                if (_numcourses != value)
                {
                    _numcourses = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumRecipes
        {
            get { return _numrecipes; }
            set
            {
                if (_numrecipes != value)
                {
                    _numrecipes = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MealDesc
        {
            get { return _mealdesc; }
            set
            {
                if (_mealdesc != value)
                {
                    _mealdesc = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
