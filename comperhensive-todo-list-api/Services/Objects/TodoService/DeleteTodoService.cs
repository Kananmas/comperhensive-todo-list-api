using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.TodoService;
using Microsoft.EntityFrameworkCore;

namespace comperhensive_todo_list_api.Services.Objects.TodoService
{
    public class DeleteTodoService : IDeleteTodoService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;

        public DeleteTodoService(IMainDatabaseContext mainDatabaseContext)
        {
            _mainDatabaseContext = mainDatabaseContext;
        }

        public async Task DeleteTodoAsync(Guid id)
        {
            await _mainDatabaseContext.todos.Where(item => item.Id == id).ExecuteDeleteAsync();
            await _mainDatabaseContext.ApplyChangesAsync();

        }
    }
}
