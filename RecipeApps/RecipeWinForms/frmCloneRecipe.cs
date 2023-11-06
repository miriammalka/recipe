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

        private void CloneARecipe()
        {
            int basedonid = WindowsFormsUtility.GetIdFromComboBox(lstRecipeName);       
            Cursor = Cursors.WaitCursor;
            try
            {
                Recipe.CloneARecipe(basedonid);               
                dtrecipe = SQLUtility.GetDataTable("select * from recipe r order by r.recipeid desc");
                int newrecipeid = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");
                
                    if(this.MdiParent != null && this.MdiParent is frmMain)
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
            CloneARecipe();
        }
    }
}
