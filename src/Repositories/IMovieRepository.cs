using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<IEnumerable<Movie>> GetByIdsAsync(IEnumerable<int> ids);
    Task<Movie?> GetByIdAsync(int id);
    void Add(Movie movie);
    void Update(Movie movie);
    void Remove(Movie movie);
}
