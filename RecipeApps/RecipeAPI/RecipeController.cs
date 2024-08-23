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
        public List<bizRecipe> Get()
        {
            return new bizRecipe().GetList();
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
