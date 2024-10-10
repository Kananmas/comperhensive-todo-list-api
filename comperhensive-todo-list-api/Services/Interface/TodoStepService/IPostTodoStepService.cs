using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;

namespace comperhensive_todo_list_api.Services.Interface.TodoStepService
{
    public interface IPostTodoStepService
    {
        Task<TodoStepDTO> PostTodoStepByData(string Data);
    }
}
