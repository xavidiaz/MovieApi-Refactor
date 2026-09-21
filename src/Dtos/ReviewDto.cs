namespace MovieApi_Refactor.Dtos;

public class ReviewDto
{
    public int Id { get; init; }
    public required double Rating { get; init; }
    public required string Text { get; init; }

    public int MovieId { get; init; }
}
