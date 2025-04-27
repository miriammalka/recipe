using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        [HttpGet]
        public List<bizDashboard> Get()
        {
            return new bizDashboard().GetList();
        }
    }
}
