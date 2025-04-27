using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizDashboard: bizObject<bizDashboard>
    {
        private int _order = 0;
        private string _type = "";
        private int _number = 0;

        public int Order
        {
            get { return _order; }
            set
            {
                if(_order != value)
                {
                    _order = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
