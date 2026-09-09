using Microsoft.EntityFrameworkCore;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Repositories;

public class ActorRepository(MovieContext context) : IActorRepository
{
    public async Task<IEnumerable<Actor>> GetAllAsync() => await context.Actors.ToListAsync();

    public async Task<Actor?> GetByIdAsync(int id) => await context.Actors.FindAsync(id);

    public void Add(Actor actor) => context.Actors.Add(actor);

    public void Update(Actor actor) => context.Actors.Update(actor);

    public void Remove(Actor actor) => context.Actors.Remove(actor);
}
