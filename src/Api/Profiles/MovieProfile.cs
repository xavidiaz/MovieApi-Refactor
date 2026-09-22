using AutoMapper;
using MovieApi.Domain.Dtos;
using MovieApi.Domain.Entities;

namespace Api.Profiles;

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
