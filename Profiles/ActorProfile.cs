using AutoMapper;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Profiles;

public class ActorProfile : Profile
{
    public ActorProfile()
    {
        CreateMap<Actor, ActorDto>();
        CreateMap<Movie, MovieSummaryDto>();
        CreateMap<CreateActorDto, Actor>().ForMember(dest => dest.Movies, opt => opt.Ignore());
        CreateMap<UpdateActorDto, Actor>().ForMember(dest => dest.Movies, opt => opt.Ignore());
    }
}
