using AutoMapper;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;
using MovieApi_Refactor.Exceptions;

namespace MovieApi_Refactor.Services;

public class ActorService(IUnitOfWork unitOfWork, IMapper mapper) : IActorService
{
    public async Task<IEnumerable<ActorDto>> GetAllAsync()
    {
        var actors = await unitOfWork.Actors.GetAllAsync();

        return actors.Select(mapper.Map<ActorDto>);
    }

    public async Task<ActorDto> GetByIdAsync(int id)
    {
        var actor =
            await unitOfWork.Actors.GetByIdAsync(id) ?? throw new NotFoundException("Actor", id);

        return mapper.Map<ActorDto>(actor);
    }

    public async Task<ActorDto> CreateAsync(CreateActorDto inputDto)
    {
        var movies = await unitOfWork.Movies.GetByIdsAsync(inputDto.MoviesId);
        if (movies.Count() != inputDto.MoviesId.Count)
            throw new NotFoundException("Movie", inputDto.MoviesId);

        var actor = mapper.Map<Actor>(inputDto);
        actor.Movies = [.. movies];

        unitOfWork.Actors.Add(actor);
        await unitOfWork.CompleteAsync();

        return mapper.Map<ActorDto>(actor);
    }

    public async Task<ActorDto> UpdateAsync(int id, UpdateActorDto inputDto)
    {
        var actor =
            await unitOfWork.Actors.GetByIdAsync(id) ?? throw new NotFoundException("Actor", id);

        var movies = await unitOfWork.Movies.GetByIdsAsync(inputDto.MoviesId);

        mapper.Map(inputDto, actor);
        actor.Movies = [.. movies];

        await unitOfWork.CompleteAsync();

        return mapper.Map<ActorDto>(actor);
    }

    public async Task<ActorDto> DeleteAsync(int id)
    {
        var actor =
            await unitOfWork.Actors.GetByIdAsync(id) ?? throw new NotFoundException("Actor", id);

        unitOfWork.Actors.Remove(actor);
        await unitOfWork.CompleteAsync();

        return mapper.Map<ActorDto>(actor);
    }
}
