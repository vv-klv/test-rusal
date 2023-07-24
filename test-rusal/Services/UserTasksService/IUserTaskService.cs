namespace test_rusal.Services.UserTasksService
{
    public interface IUserTaskService
    {
        Task<List<UserTaskDb>?> GetAllTasks(string userName);
        Task<UserTaskDb?> GetSingleTask(int id, string userName);
        Task<List<UserTaskDb>?> AddTask(UserTaskBase task, string userName);
        Task<List<UserTaskDb>?> UpdateTask(int id, UserTaskBase request, string userName);
    }
}
