using CPUFramework;
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
        [HttpDelete]
        [AuthPermission(1)]
        public IActionResult Delete(int id)
        {
            bizCookbook c = new();
            try
            {
                c.Delete(id);
                return Ok(c);
            }
            catch (Exception ex)
            {
                c.ErrorMessage = ex.Message;
                return BadRequest(c);
            }
        }

        [HttpPost]
        //[AuthPermission(1)]
        public IActionResult Post(bizCookbook cookbook)
        {
            try
            {
                cookbook.Save();
                return Ok(cookbook);
            }
            catch (Exception ex)
            {
                cookbook.ErrorMessage = ex.Message;
                return BadRequest(cookbook);
            }
        }

        [HttpPost("AutoCreateCookbook")]
        [AuthPermission(1)]
        public IActionResult AutoCreateCookbook(bizUsers users)
        {
            int usersid = users.UsersId;
            try
            {
                bizCookbook.AutoCreateCookbook(usersid);
                return Ok(users);
            }
            catch (Exception ex)
            {
                users.ErrorMessage = ex.Message + users.UserName;

                return BadRequest(users);
            }
        }
    }
}
