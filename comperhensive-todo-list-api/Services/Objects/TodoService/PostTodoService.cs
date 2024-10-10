using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.General;
using comperhensive_todo_list_api.Services.Interface.TodoService;
using comperhensive_todo_list_api.Services.Objects.General;
using comperhensive_todo_list_api.Validators;
using FluentValidation;
using Newtonsoft.Json;

namespace comperhensive_todo_list_api.Services.Objects.TodoService
{
    public class PostTodoService : IPostTodoService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;
        private readonly IJwtServices _jwtServices;
        private readonly TodoValidator _validator;

        public PostTodoService(IMainDatabaseContext mainDatabaseContext, 
            TodoValidator validator,
            IJwtServices jwtServices)
        {
            _mainDatabaseContext = mainDatabaseContext;
            _jwtServices = jwtServices;
            _validator = validator;
        }

        public async Task<TodoDTO> PostTodoByData(string data)
        {
            var newItem = JsonConvert.DeserializeObject<Todo>(data);

            if (newItem == null) throw new Exception("data is invalid");
            _validator.ValidateAndThrow(newItem);
            newItem.UserId = _jwtServices.GetUserId();

                await _mainDatabaseContext.todos.AddAsync(newItem);
            await _mainDatabaseContext.ApplyChangesAsync();

            return (TodoDTO)MapObjectToDTO.Map(newItem, new TodoDTO());
        }
    }
}
