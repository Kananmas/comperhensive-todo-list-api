using comperhensive_todo_list_api.Models;
using Microsoft.EntityFrameworkCore;

namespace comperhensive_todo_list_api.Repository.DatabaseContext.Interface
{
    public interface IMainDatabaseContext
    {
        DbSet<Todo> todos {  get; set; }  
        DbSet<TodoStep> steps { get; set; }
        DbSet<User> users { get; set; }

        Task ApplyChangesAsync();
    }
}
