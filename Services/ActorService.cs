using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public class ActorService(IUnitOfWork unitOfWork, IMapper mapper) : IActorService
{
    public async Task<IEnumerable<ActorDto>> GetAllAsync()
    {
        var actors = await unitOfWork.Actors.GetAllAsync();

        return actors.Select(mapper.Map<ActorDto>);
    }

    public async Task<ActorDto?> GetByIdAsync(int id)
    {
        var actor = await unitOfWork.Actors.GetByIdAsync(id);

        return actor is null ? null : mapper.Map<ActorDto>(actor);
    }

    public async Task<ActorDto?> CreateAsync(CreateActorDto inputDto)
    {
        var movies = await unitOfWork.Movies.GetByIdsAsync(inputDto.MoviesId);
        if (movies.Count() != inputDto.MoviesId.Count)
            return null;

        var actor = mapper.Map<Actor>(inputDto);
        actor.Movies = [.. movies];

        unitOfWork.Actors.Add(actor);
        await unitOfWork.CompleteAsync();

        return actor is null ? null : mapper.Map<ActorDto>(actor);
    }

    public async Task<ActorDto?> UpdateAsync(int id, UpdateActorDto actor)
    {
        var existing = await unitOfWork.Actors.GetByIdAsync(id);
        if (existing is null)
            return null;

        var movies = await unitOfWork.Movies.GetByIdsAsync(actor.MoviesId);

        mapper.Map(actor, existing);
        existing.Movies = [.. movies];

        await unitOfWork.CompleteAsync();

        return existing is null ? null : mapper.Map<ActorDto>(existing);
    }

    public async Task<ActorDto?> DeleteAsync(int id)
    {
        var actor = await unitOfWork.Actors.GetByIdAsync(id);
        if (actor is null)
            return null;

        unitOfWork.Actors.Remove(actor);
        await unitOfWork.CompleteAsync();

        return actor is null ? null : mapper.Map<ActorDto>(actor);
    }
}
