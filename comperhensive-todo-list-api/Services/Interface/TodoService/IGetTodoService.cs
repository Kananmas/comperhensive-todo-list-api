using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;

namespace comperhensive_todo_list_api.Services.Interface.TodoService
{
    public interface IGetTodoService
    {
        Task<List<TodoDTO>> GetTodosByUserId(Guid userId);
        Task<TodoDTO> GetTodoById(Guid Id);

    }
}
