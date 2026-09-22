using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;

namespace Api.Data;

public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Review> Reviews { get; set; }
}
