using Api.Repositories;

namespace Api.Data;

public interface IUnitOfWork
{
    IMovieRepository Movies { get; }
    IActorRepository Actors { get; }
    IReviewRepository Reviews { get; }

    Task<bool> CompleteAsync();
}
