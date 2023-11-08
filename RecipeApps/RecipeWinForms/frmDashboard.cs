using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//AF Please design the grid with the count of recipes, meals and cookbooks the way it's displayed in the wireframe

namespace RecipeWinForms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            this.Activated += FrmDashboard_Activated;
            btnRecipeList.Click += BtnRecipeList_Click;
            btnMealList.Click += BtnMealList_Click;
            btnCookbookList.Click += BtnCookbookList_Click;
        }

        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            
            gdata.DataSource = DataMaintenance.GetDashboard();
            gdata.Columns["order"].Visible = false;
           
        }

        private void ShowForm(Type frmtype)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(frmtype);
            }
        }

        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
            ShowForm(typeof(frmCookbookList));
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
            ShowForm(typeof(frmMeals));
        }

        private void BtnRecipeList_Click(object? sender, EventArgs e)
        {
            ShowForm(typeof(frmSearch));

            
        }

    }
}
