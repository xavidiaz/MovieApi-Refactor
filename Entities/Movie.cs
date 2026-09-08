namespace MovieApi_Refactor.Entities;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; } = string.Empty;
    public required int Year { get; set; }

    public ICollection<Actor> Actors { get; set; } = [];
}
