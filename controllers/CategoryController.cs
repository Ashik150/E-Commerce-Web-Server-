using System;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web_Server.controllers
{
    [ApiController]
    [Route("api/categories/")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (category == null || string.IsNullOrEmpty(category.Name))
            {
                return BadRequest("Invalid category data.");
            }

            category.CategoryId = Guid.NewGuid();
            category.CreatedAt = DateTime.UtcNow;
            categories.Add(category);

            return CreatedAtAction(nameof(GetCategories), new { id = category.CategoryId }, category);
        }
    }
}
