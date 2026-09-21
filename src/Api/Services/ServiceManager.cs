using AutoMapper;
using Api.Data;

namespace Api.Services;

public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper) : IServiceManager
{
    private readonly Lazy<IMovieService> _movieService = new(() =>
        new MovieService(unitOfWork, mapper)
    );
    private readonly Lazy<IActorService> _actorService = new(() =>
        new ActorService(unitOfWork, mapper)
    );
    private readonly Lazy<IReviewService> reviewService = new(() =>
        new ReviewService(unitOfWork, mapper)
    );

    public IMovieService Movie => _movieService.Value;
    public IActorService Actor => _actorService.Value;
    public IReviewService Review => reviewService.Value;
}
