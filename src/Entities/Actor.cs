namespace MovieApi_Refactor.Entities;

public class Actor
{
    public int Id { get; set; }
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public required int BirthYear { get; set; }

    public ICollection<Movie> Movies { get; set; } = [];
}
