using System.Data;

namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
            WindowsFormsUtility.FormatGridForSearchResults(gRecipe, "Recipe");
            btnNewRecipe.Click += BtnNewRecipe_Click;
            this.Activated += FrmSearch_Activated;
        }

        private void FrmSearch_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if(rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gRecipe, rowindex, "RecipeId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), id);
            }
        }

        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }

        private void BtnNewRecipe_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);
        }

        private void BindData()
        {
            gRecipe.DataSource = Recipe.GetRecipeList();
            WindowsFormsUtility.FormatGridForSearchResults(gRecipe, "Recipes");
            gRecipe.Columns["DateCreated"].Visible = false;
            gRecipe.Columns["DatePublished"].Visible = false;
            gRecipe.Columns["DateArchived"].Visible = false;
           
        }
    }
}
