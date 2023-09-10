using System.Threading.Tasks;
using ToyShop.Services.Monitoring.Models;

namespace ToyShop.Services.Monitoring.Coontracts
{
    public interface IMonitoringProducerService
    {
        Task ProduceAsync(MonitoringModels.LogModel logMessage);
        Task ProduceAsync(MonitoringModels.AlertModel alertMessage);
    }
}