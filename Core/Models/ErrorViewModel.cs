namespace Core.Models
{
    public class ErrorViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? RequestId { get; set; }
    }
}
