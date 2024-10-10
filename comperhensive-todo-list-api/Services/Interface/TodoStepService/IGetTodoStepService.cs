using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;

namespace comperhensive_todo_list_api.Services.Interface.TodoStepService
{
    public interface IGetTodoStepService
    {
        Task<List<TodoStepDTO>> GetStepsByTodoId(Guid todoId);
        Task<TodoStepDTO> GetStepsById(Guid todoId);
    }
}
