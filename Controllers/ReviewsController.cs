using Microsoft.AspNetCore.Mvc;
using MovieApi_Refactor.Entities;
using MovieApi_Refactor.Services;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet(Name = "reviews")]
    public async Task<IEnumerable<Review>> GetAllAsync() =>
        await serviceManager.Review.GetAllAsync();
}
