namespace KeyForge.DTO
{
    public class ApiKeyDTO
    {
        public string Key { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
    }
}
