namespace MovieApi_Refactor.Dtos;

public class CreateReviewDto
{
    public required double Rating { get; init; }
    public required string Text { get; init; }

    public required int MovieId { get; init; }
}
