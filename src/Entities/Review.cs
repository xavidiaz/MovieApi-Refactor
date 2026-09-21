namespace MovieApi_Refactor.Entities;

public class Review
{
    public int Id { get; set; }
    public required double Rating { get; set; }
    public required string Text { get; set; } = string.Empty;

    public required int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
}
