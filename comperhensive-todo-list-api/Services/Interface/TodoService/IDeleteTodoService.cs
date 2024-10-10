namespace comperhensive_todo_list_api.Services.Interface.TodoService
{
    public interface IDeleteTodoService
    {
        Task DeleteTodoAsync(Guid id);
    }
}
