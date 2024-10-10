using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.TodoStepService;
using comperhensive_todo_list_api.Services.Objects.General;
using Microsoft.EntityFrameworkCore;

namespace comperhensive_todo_list_api.Services.Objects.TodoStepService
{
    public class GetTodoStepService : IGetTodoStepService
    {
        private readonly IMainDatabaseContext _mainDbContext;

        public GetTodoStepService(IMainDatabaseContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<TodoStepDTO> GetStepsById(Guid todoId)
        {
            TodoStep? result = await _mainDbContext.steps.Where((item) => item.Id == todoId).FirstOrDefaultAsync();
            if (result == null) throw new Exception("No Such Item Found");

            return  (TodoStepDTO) MapObjectToDTO.Map(result , new TodoStepDTO());
        }

        public async Task<List<TodoStepDTO>> GetStepsByTodoId(Guid todoId)
        {
            List<TodoStep> steps =
                await _mainDbContext.steps.Where(item => item.TodoId == todoId).ToListAsync();

            var result = steps.Select((item) => (TodoStepDTO)MapObjectToDTO.Map(item, new TodoStepDTO())).ToList();

            return result;
        }
    }
}
