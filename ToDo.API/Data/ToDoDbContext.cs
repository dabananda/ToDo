using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> dbContextOptions) : base(dbContextOptions) {}

        // DbSet for ToDo items
        public DbSet<ToDoItem> ToDos { get; set; }
    }
}
