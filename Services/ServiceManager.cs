using MovieApi_Refactor.Data;

namespace MovieApi_Refactor.Services;

public class ServiceManager(IUnitOfWork unitOfWork) : IServiceManager
{
    private readonly Lazy<IMovieService> _movieService = new(() => new MovieService(unitOfWork));
    private readonly Lazy<IActorService> _actorService = new(() => new ActorService(unitOfWork));
    private readonly Lazy<IReviewService> reviewService = new(() => new ReviewService(unitOfWork));

    public IMovieService Movie => _movieService.Value;
    public IActorService Actor => _actorService.Value;
    public IReviewService Review => reviewService.Value;
}
