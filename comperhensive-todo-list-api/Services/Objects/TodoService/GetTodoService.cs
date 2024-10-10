using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.TodoService;
using comperhensive_todo_list_api.Services.Objects.General;
using Microsoft.EntityFrameworkCore;

namespace comperhensive_todo_list_api.Services.Objects.TodoService
{
    public class GetTodoService : IGetTodoService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;

        public GetTodoService(IMainDatabaseContext mainDatabaseContext)
        {
            _mainDatabaseContext = mainDatabaseContext;
        }

        public async Task<TodoDTO> GetTodoById(Guid Id)
        {
            Todo? result = await _mainDatabaseContext.todos.Where((item) => item.Id == Id).FirstOrDefaultAsync();
            if (result == null) throw new Exception("No Such Item Found");

            return (TodoDTO) MapObjectToDTO.Map(result , new TodoDTO());
        }

        public async Task<List<TodoDTO>> GetTodosByUserId(Guid userId)
        {
            List<Todo> todos = 
                await _mainDatabaseContext.todos.Where((item) => item.UserId == userId).ToListAsync();
            var result = todos.Select((item) => (TodoDTO)MapObjectToDTO.Map(item , new TodoDTO())).ToList();

            return result;
        }
    }
}
