using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public class ActorService(IUnitOfWork unitOfWork) : IActorService
{
    public async Task<IEnumerable<Actor>> GetAllAsync() => await unitOfWork.Actors.GetAllAsync();

    public async Task<Actor?> GetByIdAsync(int id) => await unitOfWork.Actors.GetByIdAsync(id);

    public async Task<Actor> CreateAsync(Actor actor)
    {
        unitOfWork.Actors.Add(actor);
        await unitOfWork.CompleteAsync();
        return actor;
    }

    public async Task<Actor?> UpdateAsync(int id, Actor actor)
    {
        var existing = await unitOfWork.Actors.GetByIdAsync(id);
        if (existing is null)
            return null;

        existing.FirstName = actor.FirstName;
        existing.LastName = actor.LastName;
        existing.BirthYear = actor.BirthYear;

        await unitOfWork.CompleteAsync();
        return existing;
    }

    public async Task<Actor?> DeleteAsync(int id)
    {
        var actor = await unitOfWork.Actors.GetByIdAsync(id);
        if (actor is null)
            return null;

        unitOfWork.Actors.Remove(actor);
        await unitOfWork.CompleteAsync();
        return actor;
    }
}
