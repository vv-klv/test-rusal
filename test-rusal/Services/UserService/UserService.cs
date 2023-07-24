using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace test_rusal.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly DataContext _context;

        public UserService(IHttpContextAccessor contextAccessor, DataContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public string? GetMyName()
        {
            var result = string.Empty;
            
            if (_contextAccessor.HttpContext != null)
            {
                result = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }

            return result;
        }

        public async Task<User?> AddUser(User requestUser)
        {
            var existedUser = await _context.Users
                .FirstOrDefaultAsync(user => user.Username == requestUser.Username);

            if (existedUser != null) 
            {
                return null;
            }

            _context.Users.Add(requestUser);

            await _context.SaveChangesAsync();

            return await _context.Users
                .FirstOrDefaultAsync(user => user.Username == requestUser.Username);
        }

        public async Task<User?> GetUser(UserDto requestUser)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(user => user.Username == requestUser.Username);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
