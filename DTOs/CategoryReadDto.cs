using System;

namespace E_Commerce_Web_Server.DTOs
{
    public class CategoryReadDto
    {
        public string Name { get; set; }
        public string? Description { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }

    }
}
