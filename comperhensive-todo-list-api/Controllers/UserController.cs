using comperhensive_todo_list_api.Services.Interface.UserService;
using Microsoft.AspNetCore.Mvc;

namespace comperhensive_todo_list_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetUserService _getUserService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IPostUserService _postUserService;

        public UserController(IGetUserService getUserService,
            IUpdateUserService updateUserService,
            IDeleteUserService deleteUserService,
            IPostUserService postUserService)
        {
            _getUserService = getUserService;
            _updateUserService = updateUserService;
            _deleteUserService = deleteUserService;
            _postUserService = postUserService;
        }

        [HttpGet("byid")]
        public async Task<IActionResult> GetUserById([FromQuery] string id)
        {
            Guid ID = Guid.Parse(id);
            var item = await _getUserService.GetUserById(ID);

            return Ok(item);
        }

        [HttpGet("signin")]
        public async Task<IActionResult> GetUserByUsernamePass([FromQuery] string username,
            [FromQuery] string password,
            [FromQuery] string email)
        {
            var result = await _getUserService.GetUserByUserNamePass(username, email, password);
            return Ok(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> PostData([FromForm] string data)
        {
            var result = await _postUserService.PostUserByData(data);
            return Ok(result);
        }

        [HttpPut("putbydata")]
        public async Task<IActionResult> UpdateData([FromForm] string data)
        {
            var result = await _updateUserService.UpdateUserByData(data);

            return Ok(result);
        }


        [HttpDelete("deletebyid")]
        public async void DeleteUserById([FromQuery] Guid ID)
        {
            await _deleteUserService.DeleteUserById(ID);
        }
    }
}
