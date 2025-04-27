using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizInstruction: bizObject<bizInstruction>
    {
        private int _instructionId;
        private int _recipeId;
        private string _instruction = "";
        private int _sequenceorder;

        public List<bizInstruction> LoadByRecipeId(int recipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("InstructionGet");
            cmd.Parameters["@RecipeId"].Value = recipeid;
            var dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);

        }

        public int InstructionId
        {
            get { return _instructionId; }
            set
            {
                if(_instructionId != value)
                {
                    _instructionId = value;
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

        public string Instruction
        {
            get { return _instruction; }
            set
            {
                if (_instruction != value)
                {
                    _instruction = value;
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
