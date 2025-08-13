using System.ComponentModel.DataAnnotations;

namespace ToDo.API.DTOs
{
    public class ToDoCreateDto
    {
        [Required]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters.")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
