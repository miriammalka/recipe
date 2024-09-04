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
        [HttpGet("{id:int:min(0)}")]
        public bizRecipe GetRecipeById(int id)
        {
            bizRecipe r = new bizRecipe();
            r.Load(id);
            return r;

        }
    }
}
