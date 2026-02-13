using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.Data;

public static class BlazorWebAppMoviesContextMigrator
{
    public static void MigrateDatabase(this IServiceProvider service)
    {
        using (var scope = service.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var dbContext = serviceProvider.GetRequiredService<BlazorWebAppMoviesContext>();

                // Check if the database provider is relational before applying migrations.
                // This prevents the "Relational-specific methods" exception during integration tests using In-Memory DB.
                if (dbContext.Database.IsRelational())
                {
                    dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<BlazorWebAppMoviesContext>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}