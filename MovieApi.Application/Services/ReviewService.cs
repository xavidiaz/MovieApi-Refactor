using Api.Data;
using AutoMapper;
using MovieApi.Application.Contracts;
using MovieApi.Domain.Dtos;
using MovieApi.Domain.Entities;
using MovieApi.Domain.Exceptions;

namespace MovieApi.Application.Services;

public class ReviewService(IUnitOfWork unitOfWork, IMapper mapper) : IReviewService
{
    public async Task<IEnumerable<ReviewDto>> GetAllAsync()
    {
        var review = await unitOfWork.Reviews.GetAllAsync();

        return review.Select(mapper.Map<ReviewDto>);
    }

    public async Task<ReviewDto> GetByIdAsync(int id)
    {
        var review =
            await unitOfWork.Reviews.GetByIdAsync(id) ?? throw new NotFoundException("Review", id);

        return mapper.Map<ReviewDto>(review);
    }

    public async Task<ReviewDto> CreateAsync(CreateReviewDto inputDto)
    {
        _ =
            await unitOfWork.Movies.GetByIdAsync(inputDto.MovieId)
            ?? throw new NotFoundException("Movie", inputDto.MovieId);

        var review = mapper.Map<Review>(inputDto);

        unitOfWork.Reviews.Add(review);
        await unitOfWork.CompleteAsync();

        return mapper.Map<ReviewDto>(review);
    }

    public async Task<ReviewDto> UpdateAsync(int id, UpdateReviewDto inputDto)
    {
        var review =
            await unitOfWork.Reviews.GetByIdAsync(id) ?? throw new NotFoundException("Review", id);

        _ =
            await unitOfWork.Movies.GetByIdAsync(inputDto.MovieId)
            ?? throw new NotFoundException("Movie", inputDto.MovieId);

        mapper.Map(inputDto, review);

        await unitOfWork.CompleteAsync();

        return mapper.Map<ReviewDto>(review);
    }

    public async Task<ReviewDto> DeleteAsync(int id)
    {
        var review =
            await unitOfWork.Reviews.GetByIdAsync(id) ?? throw new NotFoundException("Review", id);

        unitOfWork.Reviews.Remove(review);
        await unitOfWork.CompleteAsync();

        return mapper.Map<ReviewDto>(review);
    }
}
