using AutoMapper;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<Actor, ActorSummaryDto>();
        CreateMap<Review, ReviewSummaryDto>();
        CreateMap<CreateMovieDto, Movie>().ForMember(dest => dest.Actors, opt => opt.Ignore());
        CreateMap<UpdateMovieDto, Movie>().ForMember(dest => dest.Actors, opt => opt.Ignore());
    }
}
