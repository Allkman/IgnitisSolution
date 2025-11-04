using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ignitis.Storage
{
    public static class StorageContextFactory
    {
        public static IServiceCollection AddStorageContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Always use SQL Server connection string from appsettings
            var connectionString = configuration.GetConnectionString("SQL_CONNECTION_STRING");

            Console.WriteLine($"Using SQL Server connection string: {connectionString}");

            services.AddDbContext<StorageContext>((_, options) =>
            {
                options.UseSqlServer(
                    connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("Ignitis.Storage");
                        sqlOptions.CommandTimeout(400);
                        sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null);
                    });

#if DEBUG
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
#endif
            });

            return services;
        }

        public static void MigrateDatabase(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StorageContext>();

            var connectionString = dbContext.Database.GetConnectionString();
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Warning: Database connection string is null or empty. Skipping migration and seeding.");
                return;
            }

            dbContext.Database.Migrate();
            dbContext.Seed();
        }
    }
}
