using Microsoft.AspNetCore.Mvc;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Services;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet(Name = "Movies")]
    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        var movies = await serviceManager.Movie.GetAllAsync();
        return movies.Select(m => new MovieDto
        {
            Id = m.Id,
            Title = m.Title,
            Year = m.Year,

            Actors = m.Actors,
            Reviews = m.Reviews,
        });
    }

    [HttpPost(Name = "Movie")]
    public async Task<MovieDto> CreateAsync(CreateMovieDto inputDto) =>
        await serviceManager.Movie.CreateAsync(inputDto);
}
