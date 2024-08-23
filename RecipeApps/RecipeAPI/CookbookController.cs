using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;
using System.Data;
using System.Text.Json.Serialization;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbookController : ControllerBase
    {
        [HttpGet]
        public List<bizCookbook> Get()
        {
            return new bizCookbook().GetList();
        }

        [HttpGet("{id:int:min(0)}")]
        public bizCookbook GetCookbookById(int id)
        {
            bizCookbook c = new bizCookbook();
            c.Load(id);
            return c;
        }
    }
}
