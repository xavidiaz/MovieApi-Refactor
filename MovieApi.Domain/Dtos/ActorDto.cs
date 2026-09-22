namespace MovieApi.Domain.Dtos;

public class ActorDto
{
    public int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int BirthYear { get; init; }

    public ICollection<MovieSummaryDto> Movies { get; init; } = [];
}
