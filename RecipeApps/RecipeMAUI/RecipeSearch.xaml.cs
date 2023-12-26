using RecipeSystem;
using System.Data;

namespace RecipeMAUI;

public partial class RecipeSearch : ContentPage
{
	public RecipeSearch()
	{
		InitializeComponent();		
	}

	private void ShowRecipeList()
	{
		DataTable dt = Recipe.GetRecipeList();
		RecipeLst.ItemsSource = dt.Rows;

	}

    private void RecipeBtn_Clicked(object sender, EventArgs e)
    {
		ShowRecipeList();
    }
}