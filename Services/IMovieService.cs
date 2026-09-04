using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsync(int id);
    Task<Movie> CreateAsync(Movie movie);
    Task<Movie?> UpdateAsync(int id, Movie movie);
    Task<Movie?> DeleteAsync(int id);
}
