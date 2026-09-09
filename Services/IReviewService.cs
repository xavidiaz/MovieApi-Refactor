using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public interface IReviewService
{
    Task<IEnumerable<Review>> GetAllAsync();
    Task<Review?> GetByIdAsync(int id);
    Task<Review> CreateAsync(Review review);
    Task<Review?> UpdateAsync(int id, Review review);
    Task<Review> DeleteAsync(int id);
}
