namespace ToDo.API.DTOs
{
    public class ToDoCreateDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
