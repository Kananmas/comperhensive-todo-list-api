using comperhensive_todo_list_api.DTO;

namespace comperhensive_todo_list_api.Services.Interface.TodoStepService
{
    public interface IUpdateTodoStepService
    {
        Task<TodoStepDTO> UpdateTodoStepByData(string Data);
    }
}
