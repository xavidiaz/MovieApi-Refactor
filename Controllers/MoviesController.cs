using Microsoft.AspNetCore.Mvc;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private static readonly List<Movie> _movies =
    [
    new () {Id = 1, Title = "Matrix", Year = 1999 },
    new () {Id = 2, Title= "Inception", Year = 2010}
    ];


    [HttpGet(Name = "Movies")]
    public IEnumerable<Movie> Get() => _movies;
}
