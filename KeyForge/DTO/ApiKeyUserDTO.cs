namespace KeyForge.DTO
{
    public class ApiKeyUserDTO
    {
        public string Key { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrial { get; set; }
    }
}
