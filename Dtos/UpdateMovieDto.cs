namespace MovieApi_Refactor.Dtos;

public class UpdateMovieDto
{
    public required string Title { get; set; }
    public required int Year { get; set; }

    public required ICollection<int> ActorsId { get; set; }
}
