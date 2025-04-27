namespace UseSeleniumWithAPI.Models
{
    public class AutomationResult
    {
        public bool Success { get; set; }
        public object? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
