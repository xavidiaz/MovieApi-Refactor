using Microsoft.EntityFrameworkCore;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Repositories;

public class ReviewRepository(MovieContext context) : IReviewRepository
{
    public async Task<IEnumerable<Review>> GetAllAsync() => await context.Reviews.ToListAsync();

    public async Task<Review?> GetByIdAsync(int id) => await context.Reviews.FindAsync(id);

    public void Add(Review review) => context.Reviews.Add(review);

    public void Update(Review review) => context.Reviews.Update(review);

    public void Remove(Review review) => context.Reviews.Remove(review);
}
