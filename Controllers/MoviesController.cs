using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("{id}")]
    public async Task<MovieDto?> GetByIdAsync(int id) =>
        await serviceManager.Movie.GetByIdAsync(id);

    [HttpPost(Name = "Movie")]
    public async Task<MovieDto?> CreateAsync(CreateMovieDto inputDto) =>
        await serviceManager.Movie.CreateAsync(inputDto);

    [HttpPut("{id}")]
    public async Task<MovieDto?> PutAsync(int id, UpdateMovieDto inputDto) =>
        await serviceManager.Movie.UpdateAsync(id, inputDto);

    [HttpDelete("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<MovieDto?> DeleteAsync(int id) => await serviceManager.Movie.DeleteAsync(id);
}
