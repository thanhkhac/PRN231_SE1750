using Microsoft.EntityFrameworkCore;

namespace WebApp1
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> todoItems { get; set; } = null;
    }
}
