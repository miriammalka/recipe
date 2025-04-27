using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionController : ControllerBase
    {

        [HttpGet]
        public List<bizInstruction> Get()
        {
            return new bizInstruction().GetList();
        }

        [HttpGet("{id:int:min(0)}")]
        public bizInstruction Get(int id)
        {
            bizInstruction instruction = new bizInstruction();
            instruction.Load(id);
            return instruction;
        }

        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizInstruction instruction)
        {
            try
            {
                instruction.Save();
                return Ok(instruction);
            }
            catch (Exception ex)
            {
                instruction.ErrorMessage = ex.Message;
                return BadRequest(instruction);
            }
        }

        [HttpDelete]
        [AuthPermission(1)]
        public IActionResult Delete(int id)
        {
            bizInstruction instruction = new();
            try
            {
                instruction.Delete(id);
                return Ok(instruction);
            }
            catch (Exception ex)
            {
                instruction.ErrorMessage = ex.Message;
                return BadRequest(instruction);
            }
        }
    }
}
