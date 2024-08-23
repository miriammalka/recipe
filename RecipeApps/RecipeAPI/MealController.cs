using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        [HttpGet]
        public List<bizMeal> Get()
        {

            return new bizMeal().GetList();
        }
    }
}
