using comperhensive_todo_list_api.DTO;

namespace comperhensive_todo_list_api.Services.Interface.UserService
{
    public interface IGetUserService
    {
        Task<UserDTO> GetUserByUserNamePass(string userName ,string Email, string Password);
        Task<UserDTO> GetUserById(Guid id);
    }
}
