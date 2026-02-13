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
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Mad Max",
                        ReleaseDate = new DateOnly(1979, 4, 12),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 2.51M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Road Warrior",
                        ReleaseDate = new DateOnly(1981, 12, 24),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 2.78M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Mad Max: Beyond Thunderdome",
                        ReleaseDate = new DateOnly(1985, 7, 10),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 3.55M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Mad Max: Fury Road",
                        ReleaseDate = new DateOnly(2015, 5, 15),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 8.43M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Furiosa: A Mad Max Saga",
                        ReleaseDate = new DateOnly(2024, 5, 24),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 13.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        ReleaseDate = new DateOnly(1994, 9, 23),
                        Genre = "Drama",
                        Price = 4.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        ReleaseDate = new DateOnly(1972, 3, 24),
                        Genre = "Crime Drama",
                        Price = 4.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Dark Knight",
                        ReleaseDate = new DateOnly(2008, 7, 18),
                        Genre = "Action",
                        Price = 6.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Pulp Fiction",
                        ReleaseDate = new DateOnly(1994, 10, 14),
                        Genre = "Crime Drama",
                        Price = 5.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Forrest Gump",
                        ReleaseDate = new DateOnly(1994, 7, 6),
                        Genre = "Drama",
                        Price = 4.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Inception",
                        ReleaseDate = new DateOnly(2010, 7, 16),
                        Genre = "Sci-fi",
                        Price = 7.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Fight Club",
                        ReleaseDate = new DateOnly(1999, 10, 15),
                        Genre = "Drama",
                        Price = 5.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Fellowship of the Ring",
                        ReleaseDate = new DateOnly(2001, 12, 19),
                        Genre = "Fantasy",
                        Price = 6.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Return of the King",
                        ReleaseDate = new DateOnly(2003, 12, 17),
                        Genre = "Fantasy",
                        Price = 7.49M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Star Wars: Episode IV - A New Hope",
                        ReleaseDate = new DateOnly(1977, 5, 25),
                        Genre = "Sci-fi",
                        Price = 3.99M,
                        Rating = "PG",
                    },
                    new Movie
                    {
                        Title = "Star Wars: Episode V - The Empire Strikes Back",
                        ReleaseDate = new DateOnly(1980, 5, 21),
                        Genre = "Sci-fi",
                        Price = 3.99M,
                        Rating = "PG",
                    },
                    new Movie
                    {
                        Title = "Interstellar",
                        ReleaseDate = new DateOnly(2014, 11, 7),
                        Genre = "Sci-fi",
                        Price = 8.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Gladiator",
                        ReleaseDate = new DateOnly(2000, 5, 5),
                        Genre = "Action Drama",
                        Price = 5.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Departed",
                        ReleaseDate = new DateOnly(2006, 10, 6),
                        Genre = "Crime Thriller",
                        Price = 6.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Silence of the Lambs",
                        ReleaseDate = new DateOnly(1991, 2, 14),
                        Genre = "Thriller",
                        Price = 4.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Saving Private Ryan",
                        ReleaseDate = new DateOnly(1998, 7, 24),
                        Genre = "War Drama",
                        Price = 5.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Schindler's List",
                        ReleaseDate = new DateOnly(1993, 12, 15),
                        Genre = "Historical Drama",
                        Price = 5.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Green Mile",
                        ReleaseDate = new DateOnly(1999, 12, 10),
                        Genre = "Drama",
                        Price = 5.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Prestige",
                        ReleaseDate = new DateOnly(2006, 10, 20),
                        Genre = "Mystery Thriller",
                        Price = 6.49M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Goodfellas",
                        ReleaseDate = new DateOnly(1990, 9, 19),
                        Genre = "Crime Drama",
                        Price = 4.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Seven",
                        ReleaseDate = new DateOnly(1995, 9, 22),
                        Genre = "Thriller",
                        Price = 5.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Usual Suspects",
                        ReleaseDate = new DateOnly(1995, 8, 16),
                        Genre = "Crime Thriller",
                        Price = 4.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Jurassic Park",
                        ReleaseDate = new DateOnly(1993, 6, 11),
                        Genre = "Adventure",
                        Price = 5.49M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "The Avengers",
                        ReleaseDate = new DateOnly(2012, 5, 4),
                        Genre = "Action",
                        Price = 7.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Avatar",
                        ReleaseDate = new DateOnly(2009, 12, 18),
                        Genre = "Sci-fi",
                        Price = 7.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Titanic",
                        ReleaseDate = new DateOnly(1997, 12, 19),
                        Genre = "Romance Drama",
                        Price = 5.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "The Terminator",
                        ReleaseDate = new DateOnly(1984, 10, 26),
                        Genre = "Sci-fi Action",
                        Price = 3.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Terminator 2: Judgment Day",
                        ReleaseDate = new DateOnly(1991, 7, 3),
                        Genre = "Sci-fi Action",
                        Price = 4.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Aliens",
                        ReleaseDate = new DateOnly(1986, 7, 18),
                        Genre = "Sci-fi Horror",
                        Price = 4.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Blade Runner",
                        ReleaseDate = new DateOnly(1982, 6, 25),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 3.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Blade Runner 2049",
                        ReleaseDate = new DateOnly(2017, 10, 6),
                        Genre = "Sci-fi (Cyberpunk)",
                        Price = 9.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Social Network",
                        ReleaseDate = new DateOnly(2010, 10, 1),
                        Genre = "Drama",
                        Price = 6.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Whiplash",
                        ReleaseDate = new DateOnly(2014, 10, 10),
                        Genre = "Drama",
                        Price = 7.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Django Unchained",
                        ReleaseDate = new DateOnly(2012, 12, 25),
                        Genre = "Western",
                        Price = 7.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Inglourious Basterds",
                        ReleaseDate = new DateOnly(2009, 8, 21),
                        Genre = "War Drama",
                        Price = 6.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Grand Budapest Hotel",
                        ReleaseDate = new DateOnly(2014, 3, 28),
                        Genre = "Comedy Drama",
                        Price = 7.49M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Parasite",
                        ReleaseDate = new DateOnly(2019, 5, 30),
                        Genre = "Thriller Drama",
                        Price = 9.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Joker",
                        ReleaseDate = new DateOnly(2019, 10, 4),
                        Genre = "Psychological Thriller",
                        Price = 9.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "1917",
                        ReleaseDate = new DateOnly(2019, 12, 25),
                        Genre = "War Drama",
                        Price = 9.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Dune",
                        ReleaseDate = new DateOnly(2021, 10, 22),
                        Genre = "Sci-fi",
                        Price = 11.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Everything Everywhere All at Once",
                        ReleaseDate = new DateOnly(2022, 3, 25),
                        Genre = "Sci-fi Comedy",
                        Price = 12.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "Top Gun: Maverick",
                        ReleaseDate = new DateOnly(2022, 5, 27),
                        Genre = "Action Drama",
                        Price = 12.99M,
                        Rating = "PG-13",
                    },
                    new Movie
                    {
                        Title = "Oppenheimer",
                        ReleaseDate = new DateOnly(2023, 7, 21),
                        Genre = "Historical Drama",
                        Price = 14.99M,
                        Rating = "R",
                    },
                    new Movie
                    {
                        Title = "The Batman",
                        ReleaseDate = new DateOnly(2022, 3, 4),
                        Genre = "Action Thriller",
                        Price = 12.99M,
                        Rating = "PG-13",
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