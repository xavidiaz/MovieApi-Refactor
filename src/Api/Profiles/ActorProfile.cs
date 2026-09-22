using AutoMapper;
using MovieApi.Domain.Dtos;
using MovieApi.Domain.Entities;

namespace Api.Profiles;

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
