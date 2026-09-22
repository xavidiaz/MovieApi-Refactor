using MovieApi.Domain.Entities;

namespace Api.Repositories;

public interface IActorRepository
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task<IEnumerable<Actor>> GetByIdsAsync(IEnumerable<int> ids);
    Task<Actor?> GetByIdAsync(int id);
    void Add(Actor actor);
    void Update(Actor actor);
    void Remove(Actor actor);
}
