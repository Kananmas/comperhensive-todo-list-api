using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;

namespace comperhensive_todo_list_api.Services.Interface.TodoService
{
    public interface IUpdateTodoService
    {
        Task<TodoDTO> UpdateTodoAsync(string data);
    }
}
