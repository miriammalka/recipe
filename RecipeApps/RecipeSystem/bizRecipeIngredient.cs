using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizRecipeIngredient: bizObject<bizRecipeIngredient>
    {
        private int _recipeingredientId;
        private int _recipeId;
        private int _ingredientId;
        private int _measurementtypeId;
        private decimal _amount;
        private int _sequenceorder;

        public List<bizRecipeIngredient> LoadByRecipeId(int recipeid)
        {

            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeIngredientGet");
            cmd.Parameters["@RecipeId"].Value = recipeid;
            var dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int RecipeIngredientId
        {
            get { return _recipeingredientId; }
            set
            {
                if(_recipeingredientId != value)
                {
                    _recipeingredientId = value;
                    InvokePropertyChanged();
                }
            }
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

        public int IngredientId
        {
            get { return _ingredientId; }
            set
            {
                if (_ingredientId != value)
                {
                    _ingredientId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int MeasurementTypeId
        {
            get { return _measurementtypeId; }
            set
            {
                if (_measurementtypeId!= value)
                {
                    _measurementtypeId = value;
                    InvokePropertyChanged();
                }
            }
        }
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int SequenceOrder
        {
            get { return _sequenceorder; }
            set
            {
                if (_sequenceorder != value)
                {
                    _sequenceorder = value;
                    InvokePropertyChanged();
                }
            }
        }

    }
}
