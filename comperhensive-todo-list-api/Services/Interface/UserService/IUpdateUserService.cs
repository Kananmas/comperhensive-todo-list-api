using comperhensive_todo_list_api.DTO;

namespace comperhensive_todo_list_api.Services.Interface.UserService
{
    public interface IUpdateUserService
    {
        Task<UserDTO> UpdateUserByData(string Data);
    }
}
