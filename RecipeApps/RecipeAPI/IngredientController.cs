using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        [HttpGet]
        public List<bizIngredient> Get()
        {
            return new bizIngredient().GetList();
        }


        [HttpDelete]
        [AuthPermission(1)]
        public IActionResult Delete(int id)
        {
            bizIngredient ingredient = new();
            try
            {
                ingredient.Delete(id);
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                ingredient.ErrorMessage = ex.Message;
                return BadRequest(ingredient);
            }
        }

        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizIngredient ingredient)
        {
            try
            {
                ingredient.Save();
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                ingredient.ErrorMessage = ex.Message;
                return BadRequest(ingredient);
            }
        }
    }
}
