using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToyShop.Server.Infrastructure.Extensions
{
    public static class ConfigurationExtansions
    {
        public static string GetDefaultConnection(this IConfiguration configuration) 
            => configuration.GetConnectionString("DefaultConnection");

        public static AppSettings GetAppSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettingsConfiguration");
            services.Configure<AppSettings>(applicationSettingsConfiguration);

            return applicationSettingsConfiguration.Get<AppSettings>();
        }
    }
}