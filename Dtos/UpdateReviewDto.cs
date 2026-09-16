namespace MovieApi_Refactor.Dtos;

public class UpdateReviewDto
{
    public required double Rating { get; set; }
    public required string Text { get; set; }

    public required int MovieId { get; set; }
}
