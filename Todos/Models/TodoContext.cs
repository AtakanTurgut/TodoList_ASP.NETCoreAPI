using Microsoft.EntityFrameworkCore;

namespace Todos.Models
{
    public class TodoContext : DbContext
    {
       public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

       public DbSet<Todo> Todos { get; set; }
        
    }
}
