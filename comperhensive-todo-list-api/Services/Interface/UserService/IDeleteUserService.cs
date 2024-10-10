namespace comperhensive_todo_list_api.Services.Interface.UserService
{
    public interface IDeleteUserService
    {
        Task DeleteUserById(Guid id);
    }
}
