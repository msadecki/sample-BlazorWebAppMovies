using BlazorWebAppMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.Data;

public static class BlazorWebAppMoviesContextMigrator
{
    public static void MigrateDatabase(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<BlazorWebAppMoviesContext>();

                // Check if the database provider is relational before applying migrations.
                // This prevents the "Relational-specific methods" exception during integration tests using In-Memory DB.
                if (context.Database.IsRelational())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<BlazorWebAppMoviesContext>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }

    public static void SeedData(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<BlazorWebAppMoviesContext>();

                if (context == null || context.Movie == null)
                {
                    throw new NullReferenceException(
                        "Null BlazorWebAppMoviesContext or Movie DbSet");
                }

                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Matrix",
                        ReleaseDate = new DateOnly(1999, 3, 31),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 5.07M,
                    },
                    new Movie
                    {
                        Title = "Mad Max",
                        ReleaseDate = new DateOnly(1979, 4, 12),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 2.51M,
                    },
                    new Movie
                    {
                        Title = "The Road Warrior",
                        ReleaseDate = new DateOnly(1981, 12, 24),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 2.78M,
                    },
                    new Movie
                    {
                        Title = "Mad Max: Beyond Thunderdome",
                        ReleaseDate = new DateOnly(1985, 7, 10),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 3.55M,
                    },
                    new Movie
                    {
                        Title = "Mad Max: Fury Road",
                        ReleaseDate = new DateOnly(2015, 5, 15),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 8.43M,
                    },
                    new Movie
                    {
                        Title = "Furiosa: A Mad Max Saga",
                        ReleaseDate = new DateOnly(2024, 5, 24),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 13.49M,
                    });

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<BlazorWebAppMoviesContext>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }
    }
}