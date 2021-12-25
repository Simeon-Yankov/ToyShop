using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.SwaggerUI;

using ToyShop.Data;

namespace ToyShop.Server.Infrustructure.Extensions
{
    public static class ApplicationBuilderExtenion
    {
        public static IApplicationBuilder PrepareDateBase(
            this IApplicationBuilder app)
        {
            using var scopeServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopeServices.ServiceProvider;

            MigrateDatabase(serviceProvider);

            return app;
        }

        public static IApplicationBuilder ApplySwagger(this IApplicationBuilder app) 
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My ToyShop API");
                    options.RoutePrefix = string.Empty;
                    options.DocumentTitle = "Title Documentation";
                    options.DocExpansion(DocExpansion.None);
                });

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ToyShopDbContext>();

            data.Database.Migrate();
        }
    }
}