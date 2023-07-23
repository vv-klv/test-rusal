namespace test_rusal.Services.UserTasksService
{
    public interface IUserTaskService
    {
        Task<List<UserTaskDb>?> GetAllTasks();
        Task<UserTaskDb?> GetSingleTask(int id);
        Task<List<UserTaskDb>?> AddTask(UserTaskBase task);
        Task<List<UserTaskDb>?> UpdateTask(int id, UserTaskBase request);
    }
}
