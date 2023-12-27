using Microsoft.EntityFrameworkCore;

namespace Todo.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }


    }
}
