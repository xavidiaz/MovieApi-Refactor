using Microsoft.AspNetCore.Mvc;
using MovieApi_Refactor.Entities;
using MovieApi_Refactor.Services;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IMovieService movieService) : ControllerBase
{
    [HttpGet(Name = "Movies")]
    public async Task<IEnumerable<Movie>> GetAllAsync() => await movieService.GetAllAsync();

}
