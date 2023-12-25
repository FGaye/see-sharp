using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
  public class TodoAppContext : DbContext
  {
    public TodoAppContext(DbContextOptions<TodoAppContext> options) : base(options)
    {
    }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }

  }
}