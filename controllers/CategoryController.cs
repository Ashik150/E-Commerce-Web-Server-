using System;
using E_Commerce_Web_Server.DTOs;
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
            if (categories.Count == 0)
            {
                return NotFound("No categories found.");
            }
            var categoryDtos = categories.Select(c => new CategoryReadDto
            {
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            }).ToList();
            return Ok(categoryDtos);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDtos category)
        {
            if (category == null || string.IsNullOrEmpty(category.Name))
            {
                return BadRequest("Invalid category data.");
            }

            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = category.Name,
                Description = category.Description,
                CreatedAt = DateTime.UtcNow
            };
            categories.Add(newCategory);
            return CreatedAtAction(nameof(GetCategories), new { id = newCategory.CategoryId }, newCategory);
        }
    }
}
