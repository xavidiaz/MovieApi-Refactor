using Microsoft.EntityFrameworkCore;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Repositories;

public class MovieRepository(MovieContext context) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAllAsync() => await context.Movies.ToListAsync();

    public async Task<IEnumerable<Movie>> GetByIdsAsync(IEnumerable<int> ids) =>
        await context.Movies.Where(m => ids.Contains(m.Id)).ToListAsync();

    public async Task<Movie?> GetByIdAsync(int id) =>
        await context
            .Movies.Include(a => a.Actors)
            .Include(r => r.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);

    public void Add(Movie movie) => context.Movies.Add(movie);

    public void Update(Movie movie) => context.Movies.Update(movie);

    public void Remove(Movie movie) => context.Movies.Remove(movie);
}
