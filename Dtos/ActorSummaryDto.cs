namespace MovieApi_Refactor.Dtos;

public class ActorSummaryDto
{
    public int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int BirthYear { get; init; }
}
