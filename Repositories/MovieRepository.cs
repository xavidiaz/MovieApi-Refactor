using Microsoft.EntityFrameworkCore;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Repositories;

public class MovieRepository(MovieContext context) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAllAsync() => await context.Movies.ToListAsync();
    public async Task<Movie?> GetById(int id) => await context.Movies.FindAsync(id);
    public void Add(Movie movie) => context.Movies.Add(movie);
    public void Update(Movie movie) => context.Movies.Update(movie);
    public void Remove(Movie movie) => context.Movies.Remove(movie);

}
