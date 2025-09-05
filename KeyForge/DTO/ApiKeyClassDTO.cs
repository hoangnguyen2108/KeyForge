namespace KeyForge.DTO
{
    public class ApiKeyClassDTO
    {
        public int Id { get; set; }

        public string Key { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrial { get; set; }

        public string? UserId { get; set; }
    }
}
