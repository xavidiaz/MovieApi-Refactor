using Microsoft.AspNetCore.Mvc;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;
using MovieApi_Refactor.Services;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet(Name = "Actors")]
    public async Task<IEnumerable<ActorDto>> GetAllAsync() =>
        await serviceManager.Actor.GetAllAsync();
}
