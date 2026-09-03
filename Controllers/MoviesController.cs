using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi_Refactor.Repositories;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IMovieRepository repository) : ControllerBase
{
    [HttpGet(Name = "Movies")]
    public async Task<IEnumerable<Movie>> GetAllAsync() => await repository.GetAllAsync();

}
