namespace ToyShop.Services.Monitoring.Models
{
    public class MonitoringModels
    {
        public record LogModel(string Date, string Message);
        public record AlertModel(string Date, string Message);
    }
}
