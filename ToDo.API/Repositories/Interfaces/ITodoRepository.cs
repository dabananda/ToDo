using ToDo.API.Models;

namespace ToDo.API.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(Guid id);
        Task<ToDoItem> CreateAsync(ToDoItem todoItem);
        Task<ToDoItem> UpdateAsync(ToDoItem todoItem);
        Task<bool> DeleteAsync(Guid id);
    }
}
