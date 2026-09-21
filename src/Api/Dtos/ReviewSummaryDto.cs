namespace Api.Dtos;

public class ReviewSummaryDto
{
    public int Id { get; init; }
    public required double Rating { get; init; }
    public required string Text { get; init; }
}
