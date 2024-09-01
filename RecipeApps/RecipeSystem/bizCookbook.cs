using System;
using System.Collections.Generic;
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
        private string _username;
        private string _cookbookname = "";
        private decimal _price;
        private DateTime _datecreated;
        private bool _active;
        private string _skillleveldesc;

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

        public string SkillLevelDesc
        {
            get { return _skillleveldesc; }
            set
            {
                if (_skillleveldesc != value)
                {
                    _skillleveldesc = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
