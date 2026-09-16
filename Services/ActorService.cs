using MovieApi_Refactor.Data;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public class ActorService(IUnitOfWork unitOfWork) : IActorService
{
    public async Task<IEnumerable<ActorDto>> GetAllAsync()
    {
        var actors = await unitOfWork.Actors.GetAllAsync();

        return actors.Select(a => new ActorDto
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            BirthYear = a.BirthYear,

            Movies =
            [
                .. a.Movies.Select(m => new MovieSummaryDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                }),
            ],
        });
    }

    public async Task<ActorDto?> GetByIdAsync(int id)
    {
        var actor = await unitOfWork.Actors.GetByIdAsync(id);
        if (actor is null)
            return null;

        return new ActorDto
        {
            Id = actor.Id,
            FirstName = actor.FirstName,
            LastName = actor.LastName,
            BirthYear = actor.BirthYear,

            Movies =
            [
                .. actor.Movies.Select(m => new MovieSummaryDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                }),
            ],
        };
    }

    public async Task<ActorDto> CreateAsync(CreateActorDto inputDto)
    {
        var movies = await unitOfWork.Movies.GetByIdsAsync(inputDto.MoviesId);

        var actor = new Actor
        {
            FirstName = inputDto.FirstName,
            LastName = inputDto.LastName,
            BirthYear = inputDto.BirthYear,

            Movies = [.. movies],
        };

        unitOfWork.Actors.Add(actor);
        await unitOfWork.CompleteAsync();

        return new ActorDto
        {
            Id = actor.Id,
            FirstName = actor.FirstName,
            LastName = actor.LastName,
            BirthYear = actor.BirthYear,

            Movies =
            [
                .. movies.Select(m => new MovieSummaryDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                }),
            ],
        };
    }

    public async Task<ActorDto?> UpdateAsync(int id, UpdateActorDto actor)
    {
        var existing = await unitOfWork.Actors.GetByIdAsync(id);
        if (existing is null)
            return null;

        existing.FirstName = actor.FirstName;
        existing.LastName = actor.LastName;
        existing.BirthYear = actor.BirthYear;

        await unitOfWork.CompleteAsync();
        return new ActorDto
        {
            Id = existing.Id,
            FirstName = existing.FirstName,
            LastName = existing.LastName,
            BirthYear = existing.BirthYear,
            Movies =
            [
                .. existing.Movies.Select(m => new MovieSummaryDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                }),
            ],
        };
    }

    public async Task<ActorDto?> DeleteAsync(int id)
    {
        var actor = await unitOfWork.Actors.GetByIdAsync(id);
        if (actor is null)
            return null;

        unitOfWork.Actors.Remove(actor);
        await unitOfWork.CompleteAsync();

        return new ActorDto
        {
            Id = actor.Id,
            FirstName = actor.FirstName,
            LastName = actor.LastName,
            BirthYear = actor.BirthYear,

            Movies =
            [
                .. actor.Movies.Select(m => new MovieSummaryDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                }),
            ],
        };
    }
}
