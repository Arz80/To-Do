using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models;

public class ToDoListContext: DbContext
{
    public ToDoListContext(DbContextOptions options) : base(options)
    {

    }

}
