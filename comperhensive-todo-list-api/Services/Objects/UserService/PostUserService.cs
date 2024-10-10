using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.General;
using comperhensive_todo_list_api.Services.Interface.UserService;
using comperhensive_todo_list_api.Validators;
using FluentValidation;
using Newtonsoft.Json;

namespace comperhensive_todo_list_api.Services.Objects.UserService
{
    public class PostUserService : IPostUserService
    {
        private readonly IMainDatabaseContext _databaseContext;
        private readonly IJwtServices _jwtServices;
        private readonly UserValidator _userValidator;

        public PostUserService(IMainDatabaseContext databaseContext , IJwtServices jwtServices
            , UserValidator validationRules) 
        {
            _databaseContext = databaseContext;
            _jwtServices = jwtServices;
            _userValidator = validationRules;
        }
        public async Task<UserDTO> PostUserByData(string data)
        {
            User? user = JsonConvert.DeserializeObject<User>(data);
            Thread.Sleep(10000);
            if (user == null)
            {
                throw new Exception("data is invalid");
            }
            _userValidator.ValidateAndThrow(user);
            await _databaseContext.users.AddAsync(user);
            await _databaseContext.ApplyChangesAsync();

            UserDTO userDTO = new UserDTO() { 
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
            };

            userDTO.UserToken = _jwtServices.CreateJwt(userDTO);

            return userDTO;
        }
    }
}
