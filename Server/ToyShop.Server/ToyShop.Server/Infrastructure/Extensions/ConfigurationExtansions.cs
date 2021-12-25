using Microsoft.Extensions.Configuration;

namespace ToyShop.Server.Infrastructure.Extensions
{
    public static class ConfigurationExtansions
    {
        public static string GetDefaultConnection(this IConfiguration configuration) 
            => configuration.GetConnectionString("DefaultConnection");
    }
}