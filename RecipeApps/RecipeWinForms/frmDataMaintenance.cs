using CPUFramework;
using Microsoft.VisualBasic.ApplicationServices;
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

//AF The users tab has an extra column "Users" which is repetitive
//I had to add that column to the UsersGet Sproc because it was needed in other forms. I wrote code below to make it not visible. Is that sufficient?
//AF That's totally fine, I just didn't want it displayed twice
namespace RecipeWinForms
{
    public partial class frmDataMaintenance : Form
    {
        private enum TableTypeEnum { Users, Cuisine, Ingredient, MeasurementType, Course}
        DataTable dtlist = new();
        TableTypeEnum currenttabletype = TableTypeEnum.Users;
        string deletecolname = "deletecol";
        public frmDataMaintenance()
        {
            InitializeComponent();
            gData.CellContentClick += GData_CellContentClick;
            btnSave.Click += BtnSave_Click;
            this.FormClosing += FrmDataMaintenance_FormClosing;
            BindData(currenttabletype);
            SetupRadioButtons();
        }



        private void BindData (TableTypeEnum tabletype)
        {
            currenttabletype = tabletype;
            dtlist = DataMaintenance.GetDataList(currenttabletype.ToString());
            gData.Columns.Clear();
            gData.DataSource = dtlist;
            WindowsFormsUtility.AddDeleteButtonToGrid(gData, deletecolname);
            WindowsFormsUtility.FormatGridForEdit(gData, currenttabletype.ToString());
            if(tabletype == TableTypeEnum.Users)
            {
                gData.Columns["Users"].Visible = false;
            }
        }

        private void SetupRadioButtons()
        {
            foreach(Control c in tblButtons.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click;
                }
            }
            optUsers.Tag = TableTypeEnum.Users;
            optCuisines.Tag = TableTypeEnum.Cuisine;
            optIngredients.Tag = TableTypeEnum.Ingredient;
            optMeasurements.Tag = TableTypeEnum.MeasurementType;
            optCourses.Tag = TableTypeEnum.Course;
        }

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Control && ((Control)sender).Tag is TableTypeEnum)
            {
                BindData((TableTypeEnum)((Control)sender).Tag);
            }
            
        }

        private bool Save()
        {
            bool b = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                DataMaintenance.SaveDataList(dtlist, currenttabletype.ToString());
                BindData(currenttabletype);
                b = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return b;
        }

        private void Delete (int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gData, rowindex, currenttabletype.ToString() + "id");
            string prompt = currenttabletype == TableTypeEnum.Users ? "Are you sure you want to delete this user and all related recipes, meals, and cookbooks ?" : $"Are you sure you want to delete this {currenttabletype} record?";

            var response = MessageBox.Show(prompt, Application.ProductName,MessageBoxButtons.YesNo);
           
            if (id != 0)
            {
                if (response == DialogResult.No)
                {
                    return;
                }
                try
                {
                    DataMaintenance.DeleteRow(currenttabletype.ToString(), id);
                    BindData(currenttabletype);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id == 0 && rowindex < gData.Rows.Count)
            {
                gData.Rows.Remove(gData.Rows[rowindex]);
            }
        }

        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gData.Columns[e.ColumnIndex].Name == deletecolname)
            {
                Delete(e.RowIndex);
            }
        }


        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void FrmDataMaintenance_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (SQLUtility.TableHasChanges(dtlist))
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing the form?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        bool b = Save();
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
