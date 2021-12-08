using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using ToyShop.Data;

namespace ToyShop.Server.Infrustructure
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

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ToyShopDbContext>();

            data.Database.Migrate();
        }
    }
}