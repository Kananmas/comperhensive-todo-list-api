using comperhensive_todo_list_api.DTO;

namespace comperhensive_todo_list_api.Services.Interface.General
{
    public interface IJwtServices
    {
        string CreateJwt(UserDTO user);
        UserDTO ReadJwt(string Jwt);
        UserDTO ReadJwt();

        bool IsTokenExpired(string Jwt);

        Guid GetUserId();

    }
}
