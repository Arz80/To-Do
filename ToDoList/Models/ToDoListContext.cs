using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models;

public class ToDoListContext: DbContext
{
    public ToDoListContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<ToDoTask> ToDoLists { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Priority> Prioritys { get; set; }
}
