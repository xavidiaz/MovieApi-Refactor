namespace MovieApi_Refactor.Dtos;

public class MovieSummaryDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required int Year { get; init; }
}
