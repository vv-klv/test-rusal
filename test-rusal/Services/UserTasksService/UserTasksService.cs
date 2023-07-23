using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace test_rusal.Services.UserTasksService
{
    public class UserTasksService : IUserTaskService
    {
        private readonly DataContext _context;

        public UserTasksService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserTaskDb>?> GetAllTasks()
        {
            return await _context.UserTasks.ToListAsync();
        }

        public async Task<UserTaskDb?> GetSingleTask(int id)
        {
            return await _context.UserTasks.FindAsync(id);
        }

        public async Task<List<UserTaskDb>?> AddTask(UserTaskBase requestTask)
        {
            if (requestTask == null)
            {
                return null;
            }

            var userTaskDB = new UserTaskDb
            {
                UserName = requestTask.UserName,
                TaskName = requestTask.TaskName,
                TaskDescr = requestTask.TaskDescr,
                TaskStatus = requestTask.TaskStatus,
                UpdateDate = DateTime.Now,
                CreateDate = DateTime.Now,
            };

            _context.UserTasks.Add(userTaskDB);
            await _context.SaveChangesAsync();

            return await _context.UserTasks.ToListAsync();
        }

        public async Task<List<UserTaskDb>?> UpdateTask(int id, UserTaskBase requestTask)
        {
            var task = await _context.UserTasks.FindAsync(id);
            if (requestTask == null || task == null )
            {
                return null;
            }

            task.TaskName = requestTask.TaskName;
            task.TaskDescr = requestTask.TaskDescr;
            task.UpdateDate = DateTime.Now;
            task.TaskStatus = requestTask.TaskStatus;

            await _context.SaveChangesAsync();

            return await _context.UserTasks.ToListAsync();
        }
    }
}