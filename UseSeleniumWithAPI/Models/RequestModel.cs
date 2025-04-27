namespace UseSeleniumWithAPI.Models
{
    public class RequestModel
    {
        public string Url { get; set; }
        public List<ActionModel> Actions { get; set; } = new List<ActionModel>();
    }
}
