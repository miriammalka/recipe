using CPUFramework;
using RecipeSystem;
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
    public partial class frmCookbook : Form
    {
        BindingSource bindsource = new();
        DataTable dtcookbook;
        DataTable dtcookbookrecipe;
        string deletecolname = "deletcol";
        int cookbookid = 0;
        public frmCookbook()
        {
            InitializeComponent();
            btnSaveCookbook.Click += BtnSaveCookbook_Click;
            btnDeleteCookbook.Click += BtnDeleteCookbook_Click;
            btnSaveCookbookRecipe.Click += BtnSaveCookbookRecipe_Click;
            gRecipes.CellContentClick += GRecipes_CellContentClick;
            this.FormClosing += FrmCookbook_FormClosing;
        }

        public void LoadCookbookForm(int cookbookidval)
        {
            cookbookid = cookbookidval;
            this.Tag = cookbookid;
            dtcookbook = Cookbook.Load(cookbookid);
            bindsource.DataSource = dtcookbook;
            if (cookbookid == 0)
            {
                dtcookbook.Rows.Add();
            }
            WindowsFormsUtility.SetControlBinding(txtCookbookName, bindsource);

            DataTable dtusers = Cookbook.GetUsersList();
            WindowsFormsUtility.SetListBinding(lstUsers, dtusers, dtcookbook, "Users");
            
            WindowsFormsUtility.SetControlBinding(txtPrice, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, bindsource);
            //Check.DataBindings.Add("Checked", dt, "check", false, DataSourceUpdateMode.OnPropertyChanged);
            WindowsFormsUtility.SetControlBinding(chkActive, bindsource);
            this.Text = GetCookbookDesc();
            SetButtonsEnableBasedOnNewRecord();
            LoadCookbookRecipe();

        }

        private void SetButtonsEnableBasedOnNewRecord()
        {
            bool b = cookbookid == 0 ? false : true;
            btnDeleteCookbook.Enabled = b;
            btnSaveCookbookRecipe.Enabled = b;
        }

        private string GetCookbookDesc()
        {
            string value = "New Cookbook";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "CookbookId");
            if (pkvalue > 0)
            {
                value = "Cookbook - " + SQLUtility.GetValueFromFirstRowAsString(dtcookbook, "CookbookName");
            }
            return value;
        }

        private void LoadCookbookRecipe()
        {
            dtcookbookrecipe = CookbookRecipe.LoadByCookbookId(cookbookid);
            gRecipes.Columns.Clear();
            gRecipes.DataSource = dtcookbookrecipe;
            WindowsFormsUtility.AddComboBoxToGrid(gRecipes, DataMaintenance.GetDataList("Recipe"), "Recipe", "RecipeName");
            WindowsFormsUtility.AddDeleteButtonToGrid(gRecipes, deletecolname);
            WindowsFormsUtility.FormatGridForEdit(gRecipes, "Recipe");
        }

        private bool SaveCookbook()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                Cookbook.SaveCookbook(dtcookbook);
                b = true;
                bindsource.ResetBindings(false);
                cookbookid = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "CookbookId");
                this.Tag = cookbookid;
                SetButtonsEnableBasedOnNewRecord();
                this.Text = GetCookbookDesc();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }

        private void BtnSaveCookbook_Click(object? sender, EventArgs e)
        {
            SaveCookbook();
        }

        private void DeleteCookbook()
        {
            var response = MessageBox.Show("Are you sure you want to delete this cookbook?", Application.ProductName, MessageBoxButtons.YesNo); ;
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Cookbook.Delete(dtcookbook);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }

        }

        private void BtnDeleteCookbook_Click(object? sender, EventArgs e)
        {
            DeleteCookbook();
        }

        private void SaveCookbookRecipe()
        {
            try
            {
                CookbookRecipe.SaveTable(dtcookbookrecipe, cookbookid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void BtnSaveCookbookRecipe_Click(object? sender, EventArgs e)
        {
            SaveCookbookRecipe();
        }

        private void DeleteCookbookRecipe(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gRecipes, rowindex, "CookbookRecipeId");
            if (id > 0)
            {
                try
                {
                    CookbookRecipe.DeleteCookbookRecipe(id);
                    LoadCookbookRecipe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < gRecipes.Rows.Count)
            {
                gRecipes.Rows.RemoveAt(rowindex);
            }
        }

        private void GRecipes_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteCookbookRecipe(e.RowIndex);
        }


        private void FrmCookbook_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindsource.EndEdit();
            if (SQLUtility.TableHasChanges(dtcookbook))
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing the form?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        bool b = SaveCookbook();
                        if (b == false)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        this.Activate();
                        break;
                }
            }
        }
    }
}
