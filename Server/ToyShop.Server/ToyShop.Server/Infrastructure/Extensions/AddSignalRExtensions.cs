using Microsoft.Extensions.DependencyInjection;

namespace ToyShop.Server.Infrastructure.Extensions
{
    public static class AddSignalRExtensions
    {
        public static IServiceCollection AddSignalRBuilder(this IServiceCollection services)
        {
            services.AddSignalR();

            return services;
        }
    }
}
