using MovieApi_Refactor.Repositories;

namespace MovieApi_Refactor.Data;

public class UnitOfWork(MovieContext context) : IUnitOfWork
{
    public IMovieRepository Movies { get; } = new MovieRepository(context);

    public async Task<bool> CompleteAsync() => await context.SaveChangesAsync() > 0;

}
