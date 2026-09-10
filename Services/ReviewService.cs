using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public class ReviewService(IUnitOfWork unitOfWork) : IReviewService
{
    public async Task<IEnumerable<Review>> GetAllAsync() => await unitOfWork.Reviews.GetAllAsync();

    public async Task<Review?> GetByIdAsync(int id) => await unitOfWork.Reviews.GetByIdAsync(id);

    public async Task<Review> CreateAsync(Review review)
    {
        unitOfWork.Reviews.Add(review);
        await unitOfWork.CompleteAsync();
        return review;
    }

    public async Task<Review?> UpdateAsync(int id, Review review)
    {
        var existing = await unitOfWork.Reviews.GetByIdAsync(id);
        if (existing is null)
            return null;

        existing.Rating = review.Rating;
        existing.Text = review.Text;

        await unitOfWork.CompleteAsync();
        return existing;
    }

    public async Task<Review?> DeleteAsync(int id)
    {
        var existing = await unitOfWork.Reviews.GetByIdAsync(id);
        if (existing is null)
            return null;

        unitOfWork.Reviews.Remove(existing);
        await unitOfWork.CompleteAsync();
        return existing;
    }
}
