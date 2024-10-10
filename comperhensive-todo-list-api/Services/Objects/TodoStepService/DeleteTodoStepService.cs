using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.TodoStepService;
using Microsoft.EntityFrameworkCore;

namespace comperhensive_todo_list_api.Services.Objects.TodoStepService
{
    public class DeleteTodoStepService : IDeleteTodoStepService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;

        public DeleteTodoStepService(IMainDatabaseContext mainDatabaseContext)
        {
            _mainDatabaseContext = mainDatabaseContext;
        }

        public async Task DeleteTodoStepsById(Guid id)
        {
            await _mainDatabaseContext.steps.Where(item => item.Id == id).ExecuteDeleteAsync();
            await _mainDatabaseContext.ApplyChangesAsync();

        }
    }
}
