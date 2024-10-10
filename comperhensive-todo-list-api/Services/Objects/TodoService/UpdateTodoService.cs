using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.TodoService;
using comperhensive_todo_list_api.Services.Objects.General;
using comperhensive_todo_list_api.Validators;
using FluentValidation;
using Newtonsoft.Json;

namespace comperhensive_todo_list_api.Services.Objects.TodoService
{
    public class UpdateTodoService : IUpdateTodoService
    {
        private readonly  IMainDatabaseContext _mainDatabaseContext;
        private readonly TodoValidator _validator;

        public UpdateTodoService(IMainDatabaseContext mainDatabaseContext , TodoValidator validator)
        {
            _mainDatabaseContext = mainDatabaseContext;
            _validator = validator;
        }

        public async Task<TodoDTO> UpdateTodoAsync(string data)
        {
            var item = JsonConvert.DeserializeObject<Todo>(data);   
            if(item == null) throw new ArgumentNullException(nameof(data));
            _validator.ValidateAndThrow(item);  
            _mainDatabaseContext.todos.Update(item);
            await _mainDatabaseContext.ApplyChangesAsync();


            return (TodoDTO)MapObjectToDTO.Map(item , new TodoDTO());
        }
    }
}
