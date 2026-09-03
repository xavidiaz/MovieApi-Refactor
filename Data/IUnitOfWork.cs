using MovieApi_Refactor.Repositories;

namespace MovieApi_Refactor.Data;

public interface IUnitOfWork
{
    IMovieRepository Movies { get; }

    Task<bool> CompleteAsync();
}
