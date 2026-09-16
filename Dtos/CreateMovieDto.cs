namespace MovieApi_Refactor.Dtos;

public class CreateMovieDto
{
    public required string Title { get; init; }
    public required int Year { get; init; }

    public ICollection<int> ActorsId { get; init; } = [];
}
