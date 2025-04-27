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

        [HttpGet("recipes")]
        public List<bizRecipe> GetRecipes()
        {
            return new bizRecipe().GetList(true);
        }


        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizCookbookRecipe cookbookrecipe)
        {
            try
            {
                cookbookrecipe.Save();
                return Ok(cookbookrecipe);
            }
            catch (Exception ex)
            {
                cookbookrecipe.ErrorMessage = ex.Message;
                return BadRequest(cookbookrecipe);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bizCookbookRecipe cookbookrecipe = new();
            try
            {
                cookbookrecipe.Delete(id);
                return Ok(cookbookrecipe);
            }
            catch (Exception ex)
            {
                cookbookrecipe.ErrorMessage = ex.Message;
                return BadRequest(cookbookrecipe);
            }
        }
    }  
}
