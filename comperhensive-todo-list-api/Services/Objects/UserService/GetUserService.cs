using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.General;
using comperhensive_todo_list_api.Services.Interface.UserService;
using Microsoft.EntityFrameworkCore;

namespace comperhensive_todo_list_api.Services.Objects.UserService
{
    public class GetUserService : IGetUserService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;
        private readonly IJwtServices _jwtServices;

        public GetUserService(IMainDatabaseContext mainDatabaseContext , IJwtServices jwtServices)
        {
            _mainDatabaseContext = mainDatabaseContext;
            _jwtServices = jwtServices;
        }
        public async Task<UserDTO> GetUserById(Guid id)
        {
            User? item  = await _mainDatabaseContext.users
                .Where(item => item.Id == id)
                .FirstOrDefaultAsync();
            if(item == null) { throw new Exception("No Such User Found"); }
            UserDTO dto = new UserDTO() { 
                Id = item.Id, 
                Name = item.Name, 
                Email = item.Email , 
                UserName=item.UserName
            };



            return dto;

        }

        public async Task<UserDTO> GetUserByUserNamePass(string userName, string Email , string Password)
        {
            User? item  = await _mainDatabaseContext.users
                .Where(item => item.UserName.Trim() == userName.Trim() && item.Email == Email.Trim())
                .FirstOrDefaultAsync();

            Thread.Sleep(10000);

            if (item == null) { throw new Exception($"No Such User with UserName of {userName} found."); }
            if(item.Password != Password) { throw new Exception("Wrong Password"); }

            var result = new UserDTO() { 
                Id=item.Id,
                Name=item.Name,
                UserName=item.UserName,
                Email=item.Email
            };

            result.UserToken = _jwtServices.CreateJwt(result);

            return result;

        }
    }
}
