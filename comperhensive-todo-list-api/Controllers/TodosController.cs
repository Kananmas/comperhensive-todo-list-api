using comperhensive_todo_list_api.Services.Interface.General;
using comperhensive_todo_list_api.Services.Interface.TodoService;
using Microsoft.AspNetCore.Mvc;

namespace comperhensive_todo_list_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IGetTodoService _getTodoService;
        private readonly IPostTodoService _postTodoService;
        private readonly IUpdateTodoService _updateTodoService;
        private readonly IDeleteTodoService _deleteTodoService;
        private readonly IJwtServices _jwtServices;

        public TodosController(IGetTodoService getTodoService, IJwtServices jwtServices,
            IPostTodoService postTodoService, IUpdateTodoService updateTodoService, IDeleteTodoService deleteTodoService)
        {
            _getTodoService = getTodoService;
            _jwtServices = jwtServices;
            _postTodoService = postTodoService;
            _updateTodoService = updateTodoService;
            _deleteTodoService = deleteTodoService;
        }

        [HttpGet("gettodobyid")]
        public async Task<IActionResult> GetTodoById([FromQuery] string id)
        {
                var result = await _getTodoService.GetTodoById(Guid.Parse(id));

            return Ok(result);
        }

        [HttpGet("gettodobyuserid")]
        public async Task<IActionResult> GetTodosByUserId()
        {
            var userDto = _jwtServices.ReadJwt();
            var result = await _getTodoService.GetTodosByUserId(userDto.Id);

            return Ok(result);
        }

        [HttpPost("postbydata")]
        public async Task<IActionResult> PostTodoByData([FromForm] string data)
        {
            try
            {
                var result = await _postTodoService.PostTodoByData(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPut("putbydata")]
        public async Task<IActionResult> UpdateTodoByData([FromForm] string data)
        {
            try
            {
                var result = await _updateTodoService.UpdateTodoAsync(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("deletebyid")]
        public async void DeleteTodoById([FromQuery] string id)
        {
            await _deleteTodoService.DeleteTodoAsync(Guid.Parse(id));
        }
    }
}
