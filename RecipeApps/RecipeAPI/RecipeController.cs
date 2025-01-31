using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var recipes = new bizRecipe().GetList();
                return Ok(recipes); // Return 200 OK with the list of recipes
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // You can use a logging framework like Serilog, NLog, etc.

                // Return a 400 Bad Request or 500 Internal Server Error with a custom message
                return BadRequest(new { message = "An error occurred while retrieving recipes.", details = ex.Message });
            }
        }
        [HttpGet("{recipeid:int:min(0)}")]
        public bizRecipe GetRecipeById(int recipeid)
        {
            bizRecipe r = new bizRecipe();
            r.Load(recipeid);
            return r;

        }

        [HttpGet("getbycuisineId/{cuisineid:int:min(0)}")]
        public List<bizRecipe> GetRecipeByCuisineId(int cuisineid)
        {
            return new bizRecipe().Search("", cuisineid);

        }

        //[FromForm]
        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizRecipe recipe)
        {
            try
            {
                recipe.Save();
                return Ok(recipe);
            }
            catch(Exception ex)
            {
                recipe.ErrorMessage = ex.Message;
                return BadRequest(recipe);
            }
        }
        [HttpGet("users")]
        public List<bizUsers> GetUsers()
        {
            return new bizUsers().GetList();
        }

        [HttpDelete]
        [AuthPermission(3)]
        public IActionResult Delete(int id)
        {
            bizRecipe r = new();
            try
            {               
                r.Delete(id);
                return Ok(r);
            }
            catch (Exception ex)
            {
                r.ErrorMessage = ex.Message;
                return BadRequest(r);
            }
        }

    }
}
