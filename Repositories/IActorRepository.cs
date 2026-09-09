using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Repositories;

public interface IActorRepository
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task<Actor?> GetByIdAsync(int id);
    void Add(Actor actor);
    void Update(Actor actor);
    void Remove(Actor actor);
}
