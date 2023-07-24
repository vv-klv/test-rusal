using Microsoft.EntityFrameworkCore;

namespace test_rusal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=usertasksdb;Trusted_Connection=True;TrustServercertificate=true;");
        }

        public DbSet<UserTaskDb> UserTasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
