using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi_Refactor.Entities;
using MovieApi_Refactor.Data;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpGet(Name = "Movies")]
    public async Task<IEnumerable<Movie>> CompleteAsync() => await unitOfWork.Movies.GetAllAsync();

}
