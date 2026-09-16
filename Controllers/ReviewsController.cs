using Microsoft.AspNetCore.Mvc;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Services;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet(Name = "reviews")]
    public async Task<IEnumerable<ReviewDto>> GetAllAsync() =>
        await serviceManager.Review.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ReviewDto?> GetByIdAsync(int id) =>
        await serviceManager.Review.GetByIdAsync(id);

    [HttpPost(Name = "Review")]
    public async Task<ReviewDto?> CreateAsync(CreateReviewDto inputDto) =>
        await serviceManager.Review.CreateAsync(inputDto);

    [HttpPut("{id}")]
    public async Task<ReviewDto?> PutAsync(int id, UpdateReviewDto inputDto) =>
        await serviceManager.Review.UpdateAsync(id, inputDto);

    [HttpDelete("{id}")]
    public async Task<ReviewDto?> DeleteAsync(int id) =>
        await serviceManager.Review.DeleteAsync(id);
}
