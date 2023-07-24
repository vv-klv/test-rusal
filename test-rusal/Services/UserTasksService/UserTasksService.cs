using Microsoft.EntityFrameworkCore;

namespace test_rusal.Services.UserTasksService
{
    public class UserTasksService : IUserTaskService
    {
        private readonly DataContext _context;

        public UserTasksService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserTaskDb>?> GetAllTasks(string userName)
        {
            if (userName == null)
            {
                return null;
            }

            if (userName == "Admin")
            {
                return await _context.UserTasks.ToListAsync();
            }
            
            return await _context.UserTasks
                .Where(task => task.UserName == userName)
                .ToListAsync();
        }

        public async Task<UserTaskDb?> GetSingleTask(int id, string userName)
        {
            if (userName == null)
            {
                return null;
            }

            if (userName == "Admin")
            {
                return await _context.UserTasks.FindAsync(id);
            }

            return await _context.UserTasks
                .FirstOrDefaultAsync(task => task.Id == id && task.UserName == userName); 
        }

        public async Task<List<UserTaskDb>?> AddTask(UserTaskBase requestTask, string userName)
        {
            if (requestTask == null)
            {
                return null;
            }

            var userTaskDB = new UserTaskDb
            {
                UserName = userName,
                TaskName = requestTask.TaskName,
                TaskDescr = requestTask.TaskDescr,
                TaskStatus = requestTask.TaskStatus,
                UpdateDate = DateTime.Now,
                CreateDate = DateTime.Now,
            };

            _context.UserTasks.Add(userTaskDB);
            await _context.SaveChangesAsync();

            if (userName == "Admin")
            {
                return await _context.UserTasks.ToListAsync();
            }

            return await _context.UserTasks
                .Where(task => task.UserName == userName)
                .ToListAsync();
        }

        public async Task<List<UserTaskDb>?> UpdateTask(int id, UserTaskBase requestTask, string userName)
        {
            var task = await _context.UserTasks
                .FirstOrDefaultAsync(task => task.Id == id && task.UserName == userName);

            if (requestTask == null || task == null )
            {
                return null;
            }

            task.TaskName = requestTask.TaskName;
            task.TaskDescr = requestTask.TaskDescr;
            task.UpdateDate = DateTime.Now;
            task.TaskStatus = requestTask.TaskStatus;

            await _context.SaveChangesAsync();

            if (userName == "Admin")
            {
                return await _context.UserTasks.ToListAsync();
            }

            return await _context.UserTasks
                .Where(task => task.UserName == userName)
                .ToListAsync();
        }
    }
}