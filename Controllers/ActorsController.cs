using Microsoft.AspNetCore.Mvc;
using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Services;

namespace MovieApi_Refactor.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet(Name = "Actors")]
    public async Task<IEnumerable<ActorDto>> GetAllAsync() =>
        await serviceManager.Actor.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActorDto?> GetByIdAsync(int id) =>
        await serviceManager.Actor.GetByIdAsync(id);

    [HttpPost(Name = "Actor")]
    public async Task<ActorDto?> CreateAsync(CreateActorDto inputDto) =>
        await serviceManager.Actor.CreateAsync(inputDto);

    [HttpPut("{id}")]
    public async Task<ActorDto?> PutAsync(int id, UpdateActorDto inputDto) =>
        await serviceManager.Actor.UpdateAsync(id, inputDto);

    [HttpDelete("{id}")]
    public async Task<ActorDto?> DeleteAsync(int id) => await serviceManager.Actor.DeleteAsync(id);
}
