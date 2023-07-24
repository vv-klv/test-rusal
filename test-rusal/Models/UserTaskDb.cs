namespace test_rusal.Models
{
    public class UserTaskDb : UserTaskBase
    {
        public string UserName { get; set; } = string.Empty;
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}