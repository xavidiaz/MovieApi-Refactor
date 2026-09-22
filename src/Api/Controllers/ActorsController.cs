using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Domain.Dtos;
using Api.Services;

namespace Api.Controllers;

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

    [Authorize]
    [HttpPost(Name = "Actor")]
    public async Task<ActorDto?> CreateAsync(CreateActorDto inputDto) =>
        await serviceManager.Actor.CreateAsync(inputDto);

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActorDto?> PutAsync(int id, UpdateActorDto inputDto) =>
        await serviceManager.Actor.UpdateAsync(id, inputDto);

    [HttpDelete("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActorDto?> DeleteAsync(int id) => await serviceManager.Actor.DeleteAsync(id);
}
