using MovieApi_Refactor.Repositories;

namespace MovieApi_Refactor.Data;

public interface IUnitOfWork
{
    IMovieRepository Movies { get; }
    IActorRepository Actors { get; }
    IReviewRepository Reviews { get; }

    Task<bool> CompleteAsync();
}
