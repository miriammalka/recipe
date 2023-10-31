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
    public partial class frmAutoCreateCookbook : Form
    {
        DataTable dtusers;
        DataTable dtcookbook;
        public frmAutoCreateCookbook()
        {
            InitializeComponent();
            BindData();
            btnAutoCreateCookbook.Click += BtnAutoCreateCookbook_Click;
        }

        private void BindData()
        {
            dtusers = Recipe.GetUsersList();
            dtcookbook = Cookbook.GetCookbookList();
            WindowsFormsUtility.SetListBinding(lstUsers, dtusers, dtcookbook, "Users");
        }

        private void AutoCreateCookbook()
        {
            int usersid = WindowsFormsUtility.GetIdFromComboBox(lstUsers);
            Cursor = Cursors.WaitCursor;
            try
            {
                Cookbook.AutoCreateCookbook(usersid);
                dtcookbook = SQLUtility.GetDataTable("select * from cookbook c order by c.cookbookid desc");
                int newcookbookid = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "CookbookId");
                if (this.MdiParent != null && this.MdiParent is frmMain)
                {
                    ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook), newcookbookid);
                    // this.Close();                    
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

        private void BtnAutoCreateCookbook_Click(object? sender, EventArgs e)
        {
            AutoCreateCookbook();
        }
    }
}
