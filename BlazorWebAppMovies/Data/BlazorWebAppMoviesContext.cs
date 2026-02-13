using BlazorWebAppMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.Data;

public sealed class BlazorWebAppMoviesContext : DbContext
{
    public BlazorWebAppMoviesContext (DbContextOptions<BlazorWebAppMoviesContext> options)
        : base(options)
    { }

    public DbSet<Movie> Movie { get; set; } = default!;
}
