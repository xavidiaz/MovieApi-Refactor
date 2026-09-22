using AutoMapper;
using MovieApi.Domain.Dtos;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, ReviewDto>();
        CreateMap<Movie, MovieSummaryDto>();
        CreateMap<CreateReviewDto, Review>();
        CreateMap<UpdateReviewDto, Review>();
    }
}
