using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToyShop.Server.Hub;
using ToyShop.Server.Infrastructure.Extensions;
using ToyShop.Server.Infrustructure.Extensions;
using ToyShop.Server.Middlewares;

namespace ToyShop.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddDatabaseDeveloperPageExceptionFilter()
                .AddJwtAuthentication(services.GetAppSettings(this.Configuration))
                .AddApplicationServices()
                .AddSwagger()
                .AddSignalRBuilder()
                .AddControllers();

        public void Configure(IApplicationBuilder app)
            => app
                .ApplySwagger()
                .PrepareDateBase()
                .UseMiddleware<ExceptionHandlingMiddleware>()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<MonitoringHub>("/monitoringHub");
                    endpoints.MapControllers();
                });
    }
}