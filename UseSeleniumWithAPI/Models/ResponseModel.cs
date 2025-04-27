namespace UseSeleniumWithAPI.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public int? Status { get; set; }
        public List<Dictionary<string, object>>? result { get; set; }
    }
}
