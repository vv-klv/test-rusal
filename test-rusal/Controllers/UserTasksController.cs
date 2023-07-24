using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test_rusal.Services.UserService;
using test_rusal.Services.UserTasksService;

namespace test_rusal.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class UserTasksController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;
        private readonly IUserService _userService;

        public UserTasksController(IUserTaskService userTaskService, IUserService userService)
        {
            _userTaskService = userTaskService;
            _userService = userService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<List<UserTaskDb>>> GetAllTasks()
        {
            var userName = _userService.GetMyName();

            if (userName == null)
            {
                return BadRequest("Wrong user name!");
            }

            var result = await _userTaskService.GetAllTasks(userName);
            if (result == null)
            {
                return NotFound("There are no tasks!");
            }

            return result;
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<UserTaskDb>> GetSingleTask(int id)
        {
            var userName = _userService.GetMyName();

            if (userName == null)
            {
                return BadRequest("Wrong user name!");
            }

            var result = await _userTaskService.GetSingleTask(id, userName);
            if (result == null)
            {
                return NotFound("This task doesn't exist!");
            }

            return Ok(result);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<List<UserTaskDb>>> AddTask(UserTaskBase task)
        {
            var userName = _userService.GetMyName();

            if (userName == null)
            {
                return BadRequest("Wrong user name!");
            }

            var result = await _userTaskService.AddTask(task, userName);
            if (result == null)
            {
                return NotFound("Task not added!");
            }

            return Ok(result);
        }


        [HttpPut("{id}"), Authorize]
        public async Task<ActionResult<List<UserTaskDb>>> UpdateTask(int id, UserTaskBase request)
        {
            var userName = _userService.GetMyName();

            if (userName == null)
            {
                return BadRequest("Wrong user name!");
            }

            var result = await _userTaskService.UpdateTask(id, request, userName);

            if (result == null)
            {
                return NotFound("There is no task with the specified id!");
            }

            return Ok(result);
        }
    }
}