namespace KeyForge.Model
{
    public class ApiKeyClass
    {
        public int Id { get; set; }

        // When Create user
        // public int UserId { get; set; }

        public string Key { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
    }
}
