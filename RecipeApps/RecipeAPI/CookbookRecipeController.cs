using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbookRecipeController : ControllerBase
    {
        [HttpGet("getrecipesbycookbookname/{cookbookname}")]
        public List<bizCookbookRecipe> GetRecipesByCookbookName(string cookbookname)
        {
            return new bizCookbookRecipe().LoadCookbookRecipes(cookbookname);
        }
    }
}
