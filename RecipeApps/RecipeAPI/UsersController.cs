using CPUFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(bizUsers userobject)
        {
            try
            {
                userobject.Login();
                return Ok(userobject);
            }
            catch(Exception ex)
            {
                userobject.ErrorMessage = ex.Message;
                return BadRequest(userobject);
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout(bizUsers userobject)
        {
            try
            {
                userobject.Logout();
                return Ok(userobject);
            }
            catch(Exception ex)
            {
                userobject.ErrorMessage = ex.Message;
                return BadRequest(userobject);
            }
        }
        [HttpDelete]
        [AuthPermission(1)]
        public IActionResult Delete(int id)
        {
            bizUsers users = new();
            try
            {
                users.Delete(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                users.ErrorMessage = ex.Message;
                return BadRequest(users);
            }
        }

        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizUsers users)
        {
            try
            {
                users.Save();
                return Ok(users);
            }
            catch (Exception ex)
            {
                users.ErrorMessage = ex.Message;
                return BadRequest(users);
            }
        }
    }
}
