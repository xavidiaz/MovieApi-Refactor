namespace MovieApi_Refactor.Dtos;

public class CreateActorDto
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int BirthYear { get; init; }

    public ICollection<int> MoviesId { get; init; } = [];
}
