using MovieApi_Refactor.Data;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public class ReviewService(IUnitOfWork unitOfWork) : IReviewService
{
    public async Task<IEnumerable<ReviewDto>> GetAllAsync()
    {
        var review = await unitOfWork.Reviews.GetAllAsync();

        return review.Select(m => new ReviewDto
        {
            Id = m.Id,
            Text = m.Text,
            Rating = m.Rating,
            MovieId = m.MovieId,
        });
    }

    public async Task<ReviewDto?> GetByIdAsync(int id)
    {
        var review = await unitOfWork.Reviews.GetByIdAsync(id);
        if (review is null)
            return null;

        return new ReviewDto
        {
            Id = review.Id,
            Text = review.Text,
            Rating = review.Rating,
            MovieId = review.MovieId,
        };
    }

    public async Task<ReviewDto?> CreateAsync(CreateReviewDto inputDto)
    {
        var review = new Review
        {
            Rating = inputDto.Rating,
            Text = inputDto.Text,
            MovieId = inputDto.MovieId,
        };

        unitOfWork.Reviews.Add(review);
        await unitOfWork.CompleteAsync();
        return new ReviewDto
        {
            Id = review.Id,
            Rating = review.Rating,
            Text = review.Text,
            MovieId = review.MovieId,
        };
    }

    public async Task<ReviewDto?> UpdateAsync(int id, UpdateReviewDto inputDto)
    {
        var existing = await unitOfWork.Reviews.GetByIdAsync(id);
        if (existing is null)
            return null;

        existing.Rating = inputDto.Rating;
        existing.Text = inputDto.Text;

        await unitOfWork.CompleteAsync();
        return new ReviewDto
        {
            Id = existing.Id,
            Text = existing.Text,
            Rating = existing.Rating,
            MovieId = existing.MovieId,
        };
    }

    public async Task<ReviewDto?> DeleteAsync(int id)
    {
        var existing = await unitOfWork.Reviews.GetByIdAsync(id);
        if (existing is null)
            return null;

        unitOfWork.Reviews.Remove(existing);
        await unitOfWork.CompleteAsync();

        return new ReviewDto
        {
            Id = existing.Id,
            Text = existing.Text,
            Rating = existing.Rating,
            MovieId = existing.MovieId,
        };
    }
}
