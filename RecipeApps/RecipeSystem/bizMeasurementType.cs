using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizMeasurementType:bizObject<bizMeasurementType>
    {
        public bizMeasurementType()
        {

        }
        private int _measurementtypeId;
        private string _measurementtype;

        public int MeasurementTypeId
        {
            get { return _measurementtypeId; }
            set
            {
                if (_measurementtypeId != value)
                {
                    _measurementtypeId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MeasurementType
        {
            get { return _measurementtype; }
            set
            {
                if (_measurementtype != value)
                {
                    _measurementtype = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
