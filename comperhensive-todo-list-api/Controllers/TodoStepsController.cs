using comperhensive_todo_list_api.Services.Interface.TodoStepService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace comperhensive_todo_list_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoStepsController : ControllerBase
    {
        private readonly IGetTodoStepService _getTodoStepService;
        private readonly IPostTodoStepService _postTodoStepService;
        private readonly IUpdateTodoStepService _updateTodoStepService;
        private readonly IDeleteTodoStepService _deleteTodoStepService;

        public TodoStepsController(IGetTodoStepService getTodoStepService,
            IPostTodoStepService postTodoStepService, 
            IUpdateTodoStepService updateTodoStepService, 
            IDeleteTodoStepService deleteTodoStepService)
        {
            _getTodoStepService = getTodoStepService;
            _postTodoStepService = postTodoStepService;
            _updateTodoStepService = updateTodoStepService;
            _deleteTodoStepService = deleteTodoStepService;
        }

        [HttpGet("getstepbyid")]
        public async Task<IActionResult> GetTodoStepsById([FromQuery] string id)
        {
            var result = await _getTodoStepService.GetStepsById(Guid.Parse(id));

            return Ok(result);
        }

        [HttpGet("getstepsbytodoid")]
        public async Task<IActionResult> GetStepsByTodoStepId([FromQuery] string id)
        {
            var result = await _getTodoStepService.GetStepsByTodoId(Guid.Parse(id));

            return Ok(result);
        }

        [HttpPost("postbydata")] 
        public async Task<IActionResult> PostTodoStepByData([FromForm] string data)
        {
            var result = await _postTodoStepService.PostTodoStepByData(data);
            return Ok(result);
        }

        [HttpPut("putbydata")]
        public async Task<IActionResult> UpdateTodoStepByData([FromForm] string data)
        {
            var result =await _updateTodoStepService.UpdateTodoStepByData(data);

            return Ok(result);
        }

        [HttpDelete("deletebyid")]
        public async void DeleteTodoStepById([FromQuery] string id)
        {
            await _deleteTodoStepService.DeleteTodoStepsById(Guid.Parse(id));
        }
    }
}
