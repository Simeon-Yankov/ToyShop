using Confluent.Kafka;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ToyShop.Services.Monitoring.Coontracts;

using static ToyShop.Services.Monitoring.Models.MonitoringModels;

namespace ToyShop.Services.Logging
{
    public class MonitoringProducerService : IMonitoringProducerService
    {
        private readonly IProducer<Null, string> _producer;

        public MonitoringProducerService(IProducer<Null, string> producer)
        {
            _producer = producer;
        }

        public async Task ProduceAsync(LogModel logMessage)
            => await _producer.ProduceAsync(
                "logging-topic",
                new Message<Null, string>
                {
                    Value = JsonConvert.SerializeObject(logMessage)
                });

        public async Task ProduceAsync(AlertModel alertModel)
           => await _producer.ProduceAsync(
               "alert-topic",
               new Message<Null, string>
               {
                   Value = JsonConvert.SerializeObject(alertModel)
               });
    }
}
