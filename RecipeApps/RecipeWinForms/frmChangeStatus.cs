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
    public partial class frmChangeStatus : Form
    {
        BindingSource bindsource = new();
        int loadedrecipeid = 0;

        // private enum RecipeStatusEnum { Draft, Publish, Archived };

        DataTable dtrecipe;
        public frmChangeStatus()
        {
            InitializeComponent();
            btnDraft.Click += Btn_Click;
            btnPublished.Click += Btn_Click;
            btnArchived.Click += Btn_Click;
        }


        public void LoadRecipeStatusForm(int recipeid)
        {
            loadedrecipeid = recipeid;
            dtrecipe = Recipe.Load(recipeid);
            bindsource.DataSource = dtrecipe;
            WindowsFormsUtility.SetControlBinding(lblRecipeName, bindsource);
            WindowsFormsUtility.SetControlBinding(lblRecipeStatus, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, bindsource);
            SetButtonsEnabledBasedOnStatus();
            this.Show();
        }


        private void Btn_Click(object? sender, EventArgs e)
        {
            if (sender != null && sender is Button)
            {
                Button btn = (Button)sender;
                string status = btn.Text;
                var response = MessageBox.Show("Are you sure you want to change this recipe status to " + status + "?", Application.ProductName, MessageBoxButtons.YesNo);
                if (response == DialogResult.No)
                {
                    return;
                }
                Application.UseWaitCursor = true;
                try
                {
                    lblRecipeStatus.Text = status;
                    switch (status)
                    {
                        case "Draft":
                            txtDatePublished.Text = "";
                            txtDateArchived.Text = "";
                            break;
                        case "Published":
                            txtDatePublished.Text = txtDatePublished.Text == "" ? DateTime.Now.ToString() : txtDatePublished.Text;
                            txtDateArchived.Text = "";
                            break;
                        case "Archived":
                            txtDateArchived.Text = DateTime.Now.ToString();
                            break;
                    }
                    Recipe.Save(dtrecipe);
                    bindsource.ResetBindings(true);
                    SetButtonsEnabledBasedOnStatus();
                    LoadRecipeForm(loadedrecipeid);
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
        }

        private void SetButtonsEnabledBasedOnStatus()
        {
            foreach (Button b in tblButtons.Controls)
            {
                b.Enabled = true;
            }
            string status = dtrecipe.Rows[0]["RecipeStatus"].ToString();
            switch (status)
            {
                case "draft":
                    btnDraft.Enabled = false;
                    break;
                case "published":
                    btnPublished.Enabled = false;
                    break;
                case "archived":
                    btnArchived.Enabled = false;
                    break;
            }
        }

        private void LoadRecipeForm(int recipeid)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmRecipe)
                {
                    bindsource.ResetBindings(true);
                    ((frmRecipe)f).bindsource.DataSource = Recipe.Load(recipeid);
                }
            }
        }

        //private void BtnPublished_Click(object? sender, EventArgs e)
        //{
        //    var response = MessageBox.Show("Are you sure you want to change this recipe status to published?", Application.ProductName, MessageBoxButtons.YesNo);
        //    if (response == DialogResult.No)
        //    {
        //        return;
        //    }
        //    Application.UseWaitCursor = true;
        //    try
        //    {
        //        RecipeStatusEnum currentstatus = RecipeStatusEnum.Publish;
        //        currentstatus = RecipeStatusEnum.Publish;
        //        lblRecipeStatus.Text = currentstatus.ToString();
        //        txtDatePublished.Text = DateTime.Now.ToString();
        //        txtDateArchived.Text = null;
        //        //how to set the value in the column to the recipe status?
        //        Recipe.Save(dtrecipe);
        //        //bindsource.DataSource = dtrecipe;
        //        //Recipe.Load(recipeid);
        //        bindsource.ResetBindings(true);
        //        SetButtonsEnabledBasedOnStatus();
        //        LoadRecipeForm(loadedrecipeid);
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName);
        //    }
        //    finally
        //    {
        //        Application.UseWaitCursor = false;
        //    }
        //}

        //private void BtnDraft_Click(object? sender, EventArgs e)
        //{
        //    var response = MessageBox.Show("Are you sure you want to change this recipe status to draft?", Application.ProductName, MessageBoxButtons.YesNo);
        //    if (response == DialogResult.No)
        //    {
        //        return;
        //    }
        //    Application.UseWaitCursor = true;
        //    try
        //    {
        //        RecipeStatusEnum currentstatus = RecipeStatusEnum.Draft;
        //        currentstatus = RecipeStatusEnum.Draft;
        //        lblRecipeStatus.Text = currentstatus.ToString();
        //        txtDateCreated.Text = DateTime.Now.ToString();
        //        txtDatePublished.Text = "";
        //        txtDateArchived.Text = "";
        //        //how to set the value in the column to the recipe status?
        //        Recipe.Save(dtrecipe);
        //        //bindsource.DataSource = dtrecipe;
        //        //Recipe.Load(recipeid);
        //        bindsource.ResetBindings(true);
        //        SetButtonsEnabledBasedOnStatus();
        //        LoadRecipeForm(loadedrecipeid);
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName);
        //    }
        //    finally
        //    {
        //        Application.UseWaitCursor = false;
        //    }
        //}


        //private void BtnArchived_Click(object? sender, EventArgs e)
        //{
        //    var response = MessageBox.Show("Are you sure you want to change this recipe status to archived?", Application.ProductName, MessageBoxButtons.YesNo);
        //    if (response == DialogResult.No)
        //    {
        //        return;
        //    }
        //    Application.UseWaitCursor = true;
        //    try
        //    {
        //        RecipeStatusEnum currentstatus = RecipeStatusEnum.Archived;
        //        currentstatus = RecipeStatusEnum.Archived;
        //        lblRecipeStatus.Text = currentstatus.ToString();
        //        txtDateArchived.Text = DateTime.Now.ToString();
        //        //how to set the value in the column to the recipe status?
        //        Recipe.Save(dtrecipe);
        //        //bindsource.DataSource = dtrecipe;
        //        //Recipe.Load(recipeid);
        //        bindsource.ResetBindings(true);
        //        SetButtonsEnabledBasedOnStatus();
        //        LoadRecipeForm(loadedrecipeid);
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName);
        //    }
        //    finally
        //    {
        //        Application.UseWaitCursor = false;
        //    }
        //}

    }
}
