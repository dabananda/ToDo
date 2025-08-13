using Microsoft.EntityFrameworkCore;
using ToDo.API.Data;
using ToDo.API.Models;
using ToDo.API.Repositories.Interfaces;

namespace ToDo.API.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ToDoDbContext _context;

        public TodoRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> CreateAsync(ToDoItem todoItem)
        {
            await _context.ToDos.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            if (todoItem == null) return false;
            _context.ToDos.Remove(todoItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(Guid id)
        {
            return await _context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem todoItem)
        {
            todoItem.UpdatedAt = DateTime.UtcNow;
            if (todoItem.IsCompleted && todoItem.CompletedAt == null)
            {
                todoItem.CompletedAt = DateTime.UtcNow;
            }
            else if (!todoItem.IsCompleted)
            {
                todoItem.CompletedAt = null;
            }
            _context.ToDos.Update(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }
    }
}
