using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ToyShop.Server.Hub
{
    public class MonitoringHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendLog(string log)
        {
            await Clients.All.SendAsync("ReceiveLog", log);
        }

        public async Task SendAlert(string alert)
        {
            await Clients.All.SendAsync("ReceiveAlert", alert);
        }
    }
}
