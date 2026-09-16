namespace MovieApi_Refactor.Dtos;

public class UpdateActorDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int BirthYear { get; set; }

    public ICollection<int> MoviesId { get; set; } = [];
}
