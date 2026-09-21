using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Entities;

namespace Api.Repositories;

public class ActorRepository(MovieContext context) : IActorRepository
{
    public async Task<IEnumerable<Actor>> GetAllAsync() => await context.Actors.ToListAsync();

    public async Task<IEnumerable<Actor>> GetByIdsAsync(IEnumerable<int> ids) =>
        await context.Actors.Where(a => ids.Contains(a.Id)).ToListAsync();

    public async Task<Actor?> GetByIdAsync(int id) =>
        await context.Actors.Include(m => m.Movies).FirstOrDefaultAsync(a => a.Id == id);

    public void Add(Actor actor) => context.Actors.Add(actor);

    public void Update(Actor actor) => context.Actors.Update(actor);

    public void Remove(Actor actor) => context.Actors.Remove(actor);
}
