using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.TodoService;
using comperhensive_todo_list_api.Services.Interface.TodoStepService;
using comperhensive_todo_list_api.Services.Objects.General;
using comperhensive_todo_list_api.Validators;
using FluentValidation;
using Newtonsoft.Json;

namespace comperhensive_todo_list_api.Services.Objects.TodoStepService
{
    public class PostTodoStepService : IPostTodoStepService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;
        private readonly TodoStepValidator _validator;

        public PostTodoStepService(IMainDatabaseContext mainDatabaseContext , TodoStepValidator validator)
        {
            _mainDatabaseContext = mainDatabaseContext;
            _validator = validator;
        }

        public async Task<TodoStepDTO> PostTodoStepByData(string Data)
        {
            TodoStep? todoStep = JsonConvert.DeserializeObject<TodoStep>(Data);
            if(todoStep == null)
            {
                throw new Exception("Data in invalid");
            }
            _validator.ValidateAndThrow(todoStep);
            await _mainDatabaseContext.steps.AddAsync(todoStep);
            await _mainDatabaseContext.ApplyChangesAsync();
            return (TodoStepDTO) MapObjectToDTO.Map(todoStep , new TodoStepDTO());
        }
    }
}
