namespace comperhensive_todo_list_api.Services.Interface.TodoStepService
{
    public interface IDeleteTodoStepService
    {
        Task DeleteTodoStepsById(Guid id);
    }
}
