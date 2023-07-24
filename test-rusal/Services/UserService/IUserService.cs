namespace test_rusal.Services.UserService
{
    public interface IUserService
    {
        string? GetMyName();
        Task<User?> AddUser(User requestTask);
        Task<User?> GetUser(UserDto requestTask);

    }
}
