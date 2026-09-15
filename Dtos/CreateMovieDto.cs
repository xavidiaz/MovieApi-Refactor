namespace MovieApi_Refactor.Dtos;

public class CreateMovieDto
{
    public required string Title { get; set; }
    public required int Year { get; set; }

    public ICollection<int> ActorsId { get; init; } = [];
}
