using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//AF Please improve the page design, the button is very far from the dropdown

namespace RecipeWinForms
{
    public partial class frmCloneRecipe : Form
    {
        DataTable dtrecipe;
        public frmCloneRecipe()
        {
            InitializeComponent();
            BindData();
            btnClone.Click += BtnClone_Click;
        }

        private void BindData()
        {
            WindowsFormsUtility.SetListBinding(lstRecipeName, DataMaintenance.GetDataList("Recipe", true), dtrecipe, "Recipe");
        }

        private void CloneRecipe()
        {
            int basedonid = WindowsFormsUtility.GetIdFromComboBox(lstRecipeName);
            Cursor = Cursors.WaitCursor;
            try
            {
                Recipe.CloneRecipe(basedonid);
               
                /*AF here and any other places in this project where you passed in a SQL statement to get all should be refactored.  It's not good to have
                a sql statement hardcoded in, it's more prone to mistakes.  Instead, in the Recipe class, you can add a method to get all recipes 
                (which uses the sproc name and passes in the parameter @all = 1
                */
                //MM How will that help? I am trying to access the most recent recipe created. I already have a procedure in the recipe class that returns a list of all the recipes
                dtrecipe = SQLUtility.GetDataTable("select * from recipe r order by r.recipeid desc");
                int newrecipeid = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");

                if (this.MdiParent != null && this.MdiParent is frmMain)
                {
                   ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), newrecipeid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnClone_Click(object? sender, EventArgs e)
        {
            CloneRecipe();
        }
    }
}
