using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.UserService;
using comperhensive_todo_list_api.Validators;
using FluentValidation;
using Newtonsoft.Json;

namespace comperhensive_todo_list_api.Services.Objects.UserService
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;
        private readonly UserValidator _validator;

        public UpdateUserService(IMainDatabaseContext mainDatabaseContext, UserValidator validator)
        {
            _mainDatabaseContext = mainDatabaseContext;
            _validator = validator;
        }
        public async Task<UserDTO> UpdateUserByData(string Data)
        {
            User? updatedUser = JsonConvert.DeserializeObject<User>(Data);
            if (updatedUser == null)
            {
                throw new Exception("invalid data");
            }
            _validator.ValidateAndThrow(updatedUser);
            User? user = _mainDatabaseContext.users.Where((item) => item.Id == updatedUser.Id).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("no such user exists");
            }
            _mainDatabaseContext.users.Update(updatedUser);
            await _mainDatabaseContext.ApplyChangesAsync();

            UserDTO result = new UserDTO()
            {
                Id = updatedUser.Id,
                Name = updatedUser.Name,
                Email = updatedUser.Email,
                UserName = updatedUser.UserName,
            };

            return result;
        }
    }
}
