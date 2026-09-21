namespace Api.Services;

public interface IServiceManager
{
    IMovieService Movie { get; }
    IActorService Actor { get; }
    IReviewService Review { get; }
}
