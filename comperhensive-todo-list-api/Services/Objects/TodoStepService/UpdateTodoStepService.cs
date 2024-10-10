using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.TodoStepService;
using comperhensive_todo_list_api.Services.Objects.General;
using comperhensive_todo_list_api.Validators;
using FluentValidation;
using Newtonsoft.Json;

namespace comperhensive_todo_list_api.Services.Objects.TodoStepService
{
    public class UpdateTodoStepService : IUpdateTodoStepService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;
        private readonly TodoStepValidator _validator;

        public UpdateTodoStepService(IMainDatabaseContext mainDatabaseContext , TodoStepValidator validator)
        {
            _mainDatabaseContext = mainDatabaseContext;
            _validator = validator;
        }

        public async Task<TodoStepDTO> UpdateTodoStepByData(string Data)
        {
            TodoStep? updatedData = JsonConvert.DeserializeObject<TodoStep>(Data);
            if (updatedData == null) throw new Exception("Data is invalid");
            _validator.ValidateAndThrow(updatedData);
            var result = _mainDatabaseContext.steps.Update(updatedData).Entity;
            await _mainDatabaseContext.ApplyChangesAsync();
            if (result == null) throw new Exception("Np Such item Found");
            return (TodoStepDTO) MapObjectToDTO.Map(updatedData , new TodoStepDTO());
        }
    }
}
