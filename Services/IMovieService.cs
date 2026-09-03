using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsyncAsync(int id);
    Task<Movie> CreateAsync(Movie movie);
    Task<bool> UpdateAsync(int id, Movie movie);
    Task<bool> DeleteAsync(int id);
}
