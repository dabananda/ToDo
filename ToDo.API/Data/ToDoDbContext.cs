using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) {}

        // DbSet for ToDo items
        public DbSet<ToDoItem> ToDos { get; set; }
    }
}
