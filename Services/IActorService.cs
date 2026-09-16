using MovieApi_Refactor.Dtos;
using MovieApi_Refactor.Entities;

namespace MovieApi_Refactor.Services;

public interface IActorService
{
    Task<IEnumerable<ActorDto>> GetAllAsync();
    Task<ActorDto?> GetByIdAsync(int id);
    Task<ActorDto?> CreateAsync(CreateActorDto actor);
    Task<ActorDto?> UpdateAsync(int id, UpdateActorDto actor);
    Task<ActorDto?> DeleteAsync(int id);
}
