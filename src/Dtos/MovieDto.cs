namespace MovieApi_Refactor.Dtos;

public class MovieDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required int Year { get; init; }

    public ICollection<ActorSummaryDto> Actors { get; init; } = [];
    public ICollection<ReviewSummaryDto> Reviews { get; init; } = [];
}
