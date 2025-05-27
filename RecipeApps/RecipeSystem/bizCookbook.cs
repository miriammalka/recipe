using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizCookbook: bizObject<bizCookbook>
    {
        public bizCookbook()
        {

        }

        private int _cookbookId;
        //private string _username;
        private int _usersId;
        private string _cookbookname = "";
        private decimal _price;
        private DateTime _datecreated;
        private bool _active;
        private int _skilllevel;
        //private string _skillleveldesc;
        private List<bizCookbookRecipe> _lstcookbookrecipe;

        public static void AutoCreateCookbook(int usersid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("AutoCreateCookbook");
            SQLUtility.SetParamValue(cmd, "@UsersId", usersid);
            SQLUtility.ExecuteSQL(cmd);
        }
        public int CookbookId
        {
            get { return _cookbookId; }
            set
            {
                if (_cookbookId != value)
                {
                    _cookbookId = value;
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
        //public string Username
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

        public string CookbookName
        {
            get { return _cookbookname; }
            set
            {
                if (_cookbookname != value)
                {
                    _cookbookname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
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

        public int SkillLevel
        {
            get { return _skilllevel; }
            set
            {
                if (_skilllevel != value)
                {
                    _skilllevel = value;
                    InvokePropertyChanged();
                }
            }
        }

        //public string SkillLevelDesc
        //{
        //    get; set;
        //}

        public List<bizCookbookRecipe> CookbookRecipeList
        {
            get
            {
                if (_lstcookbookrecipe == null)
                {
                    _lstcookbookrecipe = new bizCookbookRecipe().LoadCookbookRecipes(CookbookName);
                }
                return _lstcookbookrecipe;
            }
        }
    }
}
