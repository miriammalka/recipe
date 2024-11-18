using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizCuisine: bizObject<bizCuisine>
    {
        public bizCuisine()
        {

        }

        private int _cuisineId;
        private string _cuisinename;

        public int CuisineId
        {
            get { return _cuisineId; }
            set
            {
                if ( _cuisineId != value)
                {
                    _cuisineId = value;
                    InvokePropertyChanged();
                }
            }
        }

    public string CuisineName
        {
            get { return _cuisinename; }
            set
            {
                if(_cuisinename != value)
                {
                    _cuisinename = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
