using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Entities;

namespace Api.Repositories;

public class ReviewRepository(MovieContext context) : IReviewRepository
{
    public async Task<IEnumerable<Review>> GetAllAsync() => await context.Reviews.ToListAsync();

    public async Task<IEnumerable<Review>> GetByIdsAsync(IEnumerable<int> ids) =>
        await context.Reviews.Where(r => ids.Contains(r.Id)).ToListAsync();

    public async Task<Review?> GetByIdAsync(int id) =>
        await context.Reviews.Include(m => m.Movie).FirstOrDefaultAsync(r => r.Id == id);

    public void Add(Review review) => context.Reviews.Add(review);

    public void Update(Review review) => context.Reviews.Update(review);

    public void Remove(Review review) => context.Reviews.Remove(review);
}
