using Microsoft.AspNetCore.Mvc;
using test_rusal.Services.UserTasksService;

namespace test_rusal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTasksController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public UserTasksController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserTaskDb>>> GetAllTasks()
        {
            var result = await _userTaskService.GetAllTasks();
            if (result == null)
            {
                return NotFound("There are no tasks!");
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTaskDb>> GetSingleTask(int id)
        {
            var result = await _userTaskService.GetSingleTask(id);
            if (result == null)
            {
                return NotFound("This task doesn't exist!");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserTaskDb>>> AddTask(UserTaskBase task)
        {
            var result = await _userTaskService.AddTask(task);
            if (result == null)
            {
                return NotFound("Task not added!");
            }

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<UserTaskDb>>> UpdateTask(int id, UserTaskBase request)
        {
            var result = await _userTaskService.UpdateTask(id, request);

            if (result == null)
            {
                return NotFound("There is no task with the specified id!");
            }

            return Ok(result);
        }
    }
}