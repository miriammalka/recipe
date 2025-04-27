using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementTypeController : ControllerBase
    {
        [HttpGet]
        public List<bizMeasurementType> Get()
        {
            return new bizMeasurementType().GetList();
        }

        
        [HttpDelete]
        [AuthPermission(1)]
        public IActionResult Delete(int id)
        {
            bizMeasurementType m = new();
            try
            {
                m.Delete(id);
                return Ok(m);
            }
            catch (Exception ex)
            {
                m.ErrorMessage = ex.Message;
                return BadRequest(m);
            }
        }

        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizMeasurementType measurementtype)
        {
            try
            {
                measurementtype.Save();
                return Ok(measurementtype);
            }
            catch (Exception ex)
            {
                measurementtype.ErrorMessage = ex.Message;
                return BadRequest(measurementtype);
            }
        }
    }
}
