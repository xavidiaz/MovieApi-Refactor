using AutoMapper;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Profiles;

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
