using ToDo.API.DTOs;

namespace ToDo.API.Services.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoReadDto>> GetAllAsync();
        Task<ToDoReadDto> GetByIdAsync(Guid id);
        Task<ToDoCreateDto> CreateAsync(ToDoCreateDto dto);
        Task<ToDoCreateDto> UpdateAsync(Guid id, ToDoCreateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
