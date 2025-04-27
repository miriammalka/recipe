using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public List<bizCourse> Get()
        {
            return new bizCourse().GetList();
        }


        [HttpDelete]
        [AuthPermission(1)]
        public IActionResult Delete(int id)
        {
            bizCourse course = new();
            try
            {
                course.Delete(id);
                return Ok(course);
            }
            catch (Exception ex)
            {
                course.ErrorMessage = ex.Message;
                return BadRequest(course);
            }
        }

        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizCourse course)
        {
            try
            {
                course.Save();
                return Ok(course);
            }
            catch (Exception ex)
            {
                course.ErrorMessage = ex.Message;
                return BadRequest(course);
            }
        }
    }
}
