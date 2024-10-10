using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Services.Interface.UserService;
using Microsoft.EntityFrameworkCore;

namespace comperhensive_todo_list_api.Services.Objects.UserService
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IMainDatabaseContext _mainDatabaseContext;

        public DeleteUserService(IMainDatabaseContext mainDatabaseContext)
        {
            _mainDatabaseContext = mainDatabaseContext;
        }
       
        public async Task DeleteUserById(Guid id)
        {
           await _mainDatabaseContext.users.Where(item => item.Id == id).ExecuteDeleteAsync();
            await _mainDatabaseContext. ApplyChangesAsync();

        }
    }
}
