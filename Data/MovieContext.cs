using Microsoft.EntityFrameworkCore;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Data;

public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}
