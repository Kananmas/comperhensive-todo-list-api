using comperhensive_todo_list_api.DTO;

namespace comperhensive_todo_list_api.Services.Interface.UserService
{
    public interface IPostUserService
    {
        Task<UserDTO> PostUserByData(string data);
    }
}
