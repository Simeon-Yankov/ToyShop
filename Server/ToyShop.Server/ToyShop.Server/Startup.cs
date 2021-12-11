using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ToyShop.Data;
using ToyShop.Server.Infrastructure.Extensions;
using ToyShop.Server.Infrustructure;
using ToyShop.Services.Identity;
using ToyShop.Services.Identity.Contracts;
using ToyShop.Services.Toys;
using ToyShop.Services.Toys.Contracts;

namespace ToyShop.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = services.GetAppSettings(this.Configuration);

            services
                .AddDbContext<ToyShopDbContext>(options => options
                    .UseSqlServer(this.Configuration.GetDefaultConnection()))
                .AddIdentity()
                .AddDatabaseDeveloperPageExceptionFilter()
                .AddJwtAuthentication(appSettings)
                .AddControllers();

            services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IToyService, ToyService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .PrepareDateBase()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}