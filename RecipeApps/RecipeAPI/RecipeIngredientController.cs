using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        [HttpGet]
        public List<bizRecipeIngredient> Get()
        {
            return new bizRecipeIngredient().GetList();
        }

        [HttpGet("{id:int:min(0)}")]
        public bizRecipeIngredient Get(int id)
        {
            bizRecipeIngredient recipeingredient = new bizRecipeIngredient();
            recipeingredient.Load(id);
            return recipeingredient;
        }

        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizRecipeIngredient RecipeIngredient)
        {
            try
            {
                RecipeIngredient.Save();
                return Ok(RecipeIngredient);
            }
            catch(Exception ex)
            {
                RecipeIngredient.ErrorMessage = ex.Message;
                return BadRequest(RecipeIngredient);
            }
        }

        [HttpDelete]
        [AuthPermission(1)]
        public IActionResult Delete(int id)
        {
            bizRecipeIngredient recipeingredient = new();
            try
            {
                recipeingredient.Delete(id);
                return Ok(recipeingredient);
            }
            catch (Exception ex)
            {
                recipeingredient.ErrorMessage = ex.Message;
                return BadRequest(recipeingredient);
            }
        }

        [HttpGet("ingredients")]
        public List<bizIngredient> GetIngredients()
        {
            return new bizIngredient().GetList();
        }
    }
}
