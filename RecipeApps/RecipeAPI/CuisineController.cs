﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        [HttpGet]
        public List<bizCuisine> Get()
        {
            return new bizCuisine().GetList();
        }


        [HttpDelete]
        [AuthPermission(1)]
        public IActionResult Delete(int id)
        {
            bizCuisine cuisine = new();
            try
            {
                cuisine.Delete(id);
                return Ok(cuisine);
            }
            catch (Exception ex)
            {
                cuisine.ErrorMessage = ex.Message;
                return BadRequest(cuisine);
            }
        }

        [HttpPost]
        [AuthPermission(1)]
        public IActionResult Post(bizCuisine cuisine)
        {
            try
            {
                cuisine.Save();
                return Ok(cuisine);
            }
            catch (Exception ex)
            {
                cuisine.ErrorMessage = ex.Message;
                return BadRequest(cuisine);
            }
        }
    }
}
