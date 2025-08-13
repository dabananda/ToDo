using ToDo.API.DTOs;

namespace ToDo.API.Services.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoReadDto>> GetAllAsync();
        Task<ToDoReadDto> GetByIdAsync(Guid id);
        Task<ToDoReadDto> CreateAsync(ToDoCreateDto dto);
        Task<ToDoReadDto> UpdateAsync(Guid id, ToDoUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
