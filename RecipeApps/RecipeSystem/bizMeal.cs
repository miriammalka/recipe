using System;
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
        private int _usersId;
        private string _mealname = "";
        private DateTime _datecreated;
        private bool _active;
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
