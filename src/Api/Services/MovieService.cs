using AutoMapper;
using Api.Data;
using Api.Dtos;
using Api.Entities;
using Api.Exceptions;

namespace Api.Services;

public class MovieService(IUnitOfWork unitOfWork, IMapper mapper) : IMovieService
{
    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        var movies = await unitOfWork.Movies.GetAllAsync();

        return movies.Select(mapper.Map<MovieDto>);
    }

    public async Task<MovieDto> GetByIdAsync(int id)
    {
        var movie =
            await unitOfWork.Movies.GetByIdAsync(id) ?? throw new NotFoundException("Movie", id);

        return mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto> CreateAsync(CreateMovieDto createDto)
    {
        var actors = await unitOfWork.Actors.GetByIdsAsync(createDto.ActorsId);
        if (actors.Count() != createDto.ActorsId.Count)
            throw new NotFoundException("Actor", string.Join(",", createDto.ActorsId));

        var movie = mapper.Map<Movie>(createDto);
        movie.Actors = [.. actors];
        movie.Reviews = [];

        unitOfWork.Movies.Add(movie);
        await unitOfWork.CompleteAsync();

        return mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto> UpdateAsync(int id, UpdateMovieDto inputDto)
    {
        var movie =
            await unitOfWork.Movies.GetByIdAsync(id) ?? throw new NotFoundException("Movie", id);

        var actors = await unitOfWork.Actors.GetByIdsAsync(inputDto.ActorsId);

        mapper.Map(inputDto, movie);
        movie.Actors = [.. actors];

        await unitOfWork.CompleteAsync();

        return mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto> DeleteAsync(int id)
    {
        var movie =
            await unitOfWork.Movies.GetByIdAsync(id) ?? throw new NotFoundException("Movie", id);

        unitOfWork.Movies.Remove(movie);
        await unitOfWork.CompleteAsync();

        return mapper.Map<MovieDto>(movie);
    }
}
