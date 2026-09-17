using AutoMapper;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public class MovieService(IUnitOfWork unitOfWork, IMapper mapper) : IMovieService
{
    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        var movies = await unitOfWork.Movies.GetAllAsync();

        return movies.Select(m => mapper.Map<MovieDto>(m));
    }

    public async Task<MovieDto?> GetByIdAsync(int id)
    {
        var movie = await unitOfWork.Movies.GetByIdAsync(id);

        return movie is null ? null : mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto?> CreateAsync(CreateMovieDto createDto)
    {
        var actors = await unitOfWork.Actors.GetByIdsAsync(createDto.ActorsId);
        if (actors.Count() != createDto.ActorsId.Count)
            return null;

        var movie = mapper.Map<Movie>(createDto);
        movie.Actors = [.. actors];
        movie.Reviews = [];

        unitOfWork.Movies.Add(movie);
        await unitOfWork.CompleteAsync();

        return movie is null ? null : mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto?> UpdateAsync(int id, UpdateMovieDto inputDto)
    {
        var movie = await unitOfWork.Movies.GetByIdAsync(id);
        if (movie is null)
            return null;

        var actors = await unitOfWork.Actors.GetByIdsAsync(inputDto.ActorsId);

        mapper.Map(inputDto, movie);
        movie.Actors = [.. actors];

        await unitOfWork.CompleteAsync();

        return movie is null ? null : mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto?> DeleteAsync(int id)
    {
        var movie = await unitOfWork.Movies.GetByIdAsync(id);
        if (movie is null)
            return null;

        unitOfWork.Movies.Remove(movie);
        await unitOfWork.CompleteAsync();

        return movie is null ? null : mapper.Map<MovieDto>(movie);
    }
}
