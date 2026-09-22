using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Domain.Dtos;
using MovieApi.Application.Contracts;

namespace Api.Controllers;

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

    [Authorize]
    [HttpPost(Name = "Review")]
    public async Task<ReviewDto?> CreateAsync(CreateReviewDto inputDto) =>
        await serviceManager.Review.CreateAsync(inputDto);

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ReviewDto?> PutAsync(int id, UpdateReviewDto inputDto) =>
        await serviceManager.Review.UpdateAsync(id, inputDto);

    [HttpDelete("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ReviewDto?> DeleteAsync(int id) =>
        await serviceManager.Review.DeleteAsync(id);
}
