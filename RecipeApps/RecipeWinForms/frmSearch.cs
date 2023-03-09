using CPUFramework;
using System.Data;

namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
            FormatGrid();
        }

        private void FormatGrid()
        {
            gRecipe.AllowUserToAddRows = false;
            gRecipe.ReadOnly = true;
            gRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SearchForRecipe(string recipe)
        {
            string sql = "select c.CuisineName, u.UserName, r.* " +
                "from recipe r " +
                "join Cuisine c on c.CuisineId = r.CuisineId " +
                "join Users u on u.UserId = r.UserId " +
                "where r.RecipeName like '%" + recipe + "%'";
            DataTable dt = SQLUtility.GetDataTable(sql);
            gRecipe.DataSource = dt;
            gRecipe.Columns["RecipeId"].Visible = false;
            gRecipe.Columns["CuisineId"].Visible = false;
            gRecipe.Columns["UserId"].Visible = false;
        }

        private void ShowRecipeForm(int rowindex)
        {
            int id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
            frmRecipe frm = new();
            frm.ShowForm(id);
        }

        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtRecipe.Text);
        }
    }
}
