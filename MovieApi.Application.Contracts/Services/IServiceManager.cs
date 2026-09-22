namespace MovieApi.Application.Contracts;

public interface IServiceManager
{
    IMovieService Movie { get; }
    IActorService Actor { get; }
    IReviewService Review { get; }
}
