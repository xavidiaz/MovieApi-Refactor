using MovieApi.Domain.Dtos;

namespace MovieApi.Application.Contracts;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetAllAsync();
    Task<MovieDto> GetByIdAsync(int id);
    Task<MovieDto> CreateAsync(CreateMovieDto movie);
    Task<MovieDto> UpdateAsync(int id, UpdateMovieDto movie);
    Task<MovieDto> DeleteAsync(int id);
}
