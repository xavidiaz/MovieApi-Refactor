using AutoMapper;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public class ReviewService(IUnitOfWork unitOfWork, IMapper mapper) : IReviewService
{
    public async Task<IEnumerable<ReviewDto>> GetAllAsync()
    {
        var review = await unitOfWork.Reviews.GetAllAsync();

        return review.Select(mapper.Map<ReviewDto>);
    }

    public async Task<ReviewDto?> GetByIdAsync(int id)
    {
        var review = await unitOfWork.Reviews.GetByIdAsync(id);
        if (review is null)
            return null;

        return mapper.Map<ReviewDto>(review);
    }

    public async Task<ReviewDto?> CreateAsync(CreateReviewDto inputDto)
    {
        var movie = await unitOfWork.Movies.GetByIdAsync(inputDto.MovieId);
        if (movie is null)
            return null;

        var review = mapper.Map<Review>(inputDto);

        unitOfWork.Reviews.Add(review);
        await unitOfWork.CompleteAsync();

        return mapper.Map<ReviewDto>(review);
    }

    public async Task<ReviewDto?> UpdateAsync(int id, UpdateReviewDto inputDto)
    {
        var existing = await unitOfWork.Reviews.GetByIdAsync(id);
        if (existing is null)
            return null;

        var movie = await unitOfWork.Movies.GetByIdAsync(inputDto.MovieId);
        if (movie is null)
            return null;

        mapper.Map(inputDto, existing);

        await unitOfWork.CompleteAsync();

        return mapper.Map<ReviewDto>(existing);
    }

    public async Task<ReviewDto?> DeleteAsync(int id)
    {
        var existing = await unitOfWork.Reviews.GetByIdAsync(id);
        if (existing is null)
            return null;

        unitOfWork.Reviews.Remove(existing);
        await unitOfWork.CompleteAsync();

        return mapper.Map<ReviewDto>(existing);
    }
}
