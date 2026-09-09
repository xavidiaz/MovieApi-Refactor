using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetAllAsync();
    Task<Review?> GetByIdAsync(int id);
    void Add(Review review);
    void Update(Review review);
    void Remove(Review review);
}
