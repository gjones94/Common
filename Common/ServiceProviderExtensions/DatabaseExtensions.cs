using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ServiceProviderExtensions
{
    /// <summary>
    /// Extensions to be used by middleware in program.cs
    /// 
    /// Example
    /// =========
    /// 
    /// app.Services.AutoMigrateDatabase<YourCustomDbContext>();
    /// 
    /// </summary>
    public static class DatabaseExtensions
    {
        public static void AutoMigrateDatabase<T>(this IServiceProvider serviceProvider) where T : DbContext
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;

                //Auto migration/create
                var context = (DbContext) services.GetRequiredService<T>();
                context.Database.Migrate();
            }
        }

        public async static void SeedDatabase<TSeeder, TDbContext>(this IServiceProvider serviceProvider)
           where TDbContext : DbContext
           where TSeeder : ISeedService
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = scope.ServiceProvider.GetService<TDbContext>();

                if (dbContext is not null)
                {
                    var migrationHistory = dbContext.Database.GetMigrations();

                    if (migrationHistory.Count() <= 1) // Only the initial migration has been applied, so we should seed
                    {
                        var seedService = scope.ServiceProvider.GetService<TSeeder>();

                        if (seedService is not null)
                            await seedService.Seed();
                    }
                }
            }
        }
    }
}
