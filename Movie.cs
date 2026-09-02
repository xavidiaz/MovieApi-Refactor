namespace MovieApi_Refactor;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; } = string.Empty;
    public int Year { get; set; }

}
