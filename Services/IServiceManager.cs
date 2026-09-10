namespace MovieApi_Refactor.Services;

public interface IServiceManager
{
    IMovieService Movie { get; }
    IActorService Actor { get; }
    IReviewService Review { get; }
}
