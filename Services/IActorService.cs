using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public interface IActorService
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task<Actor?> GetByIdAsync(int id);
    Task<Actor> CreateAsync(Actor actor);
    Task<Actor?> UpdateAsync(int id, Actor actor);
    Task<Actor?> DeleteAsync(int id);
}
