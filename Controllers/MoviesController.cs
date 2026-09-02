using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi_Refactor.Data;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(MovieContext context) : ControllerBase
{
    [HttpGet(Name = "Movies")]
    public async Task<IEnumerable<Movie>> GetAllAsync() => await context.Movies.ToListAsync();

}
