using MovieApi_Refactor.Dtos;

namespace MovieApi_Refactor.Services;

public interface IReviewService
{
    Task<IEnumerable<ReviewDto>> GetAllAsync();
    Task<ReviewDto?> GetByIdAsync(int id);
    Task<ReviewDto?> CreateAsync(CreateReviewDto review);
    Task<ReviewDto?> UpdateAsync(int id, UpdateReviewDto review);
    Task<ReviewDto?> DeleteAsync(int id);
}
