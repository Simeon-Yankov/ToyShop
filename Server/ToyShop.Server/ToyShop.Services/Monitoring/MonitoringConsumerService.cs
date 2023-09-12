using Confluent.Kafka;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ToyShop.Server.Hub;

using static ToyShop.Services.Monitoring.Models.MonitoringModels;

namespace ToyShop.Services.Monitoring
{
    public class MonitoringConsumerService : BackgroundService
    {
        private readonly IHubContext<MonitoringHub> _hubContext;
        private readonly ConsumerConfig _config;

        public MonitoringConsumerService(IHubContext<MonitoringHub> hubContext)
        {
            _hubContext = hubContext;

            // Ideally, configuration should be injected too, using IOptions or similar
            _config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "group-id",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
            consumer.Subscribe("logging-topic");
            consumer.Subscribe("alert-topic");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(stoppingToken);
                    if (consumeResult.Message != null)
                    {
                        var log = JsonConvert.DeserializeObject<LogModel>(consumeResult.Message.Value);
                        await _hubContext.Clients.All.SendAsync("ReceiveLog", $"[Information] Date: {log.Date}, Message: {log.Message}");
                        Debug.WriteLine("test" + log);
                    }
                }
                catch (ConsumeException e)
                {
                    Debug.WriteLine($"Consume error: @e", e);
                }

                await Task.Delay(TimeSpan.FromMilliseconds(300), stoppingToken);
            }

            consumer.Close();
        }
    }
}
