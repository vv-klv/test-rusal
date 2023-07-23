namespace test_rusal.Models
{
    public class UserTaskDb : UserTaskBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}