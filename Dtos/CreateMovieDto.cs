using System.ComponentModel.DataAnnotations;

namespace MovieApi_Refactor.Dtos;

public class CreateMovieDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(
        200,
        MinimumLength = 1,
        ErrorMessage = "Title must be between 1 and 200 characters."
    )]
    public required string Title { get; init; }

    [Range(1888, 2100, ErrorMessage = "Please enter a valid release year.")]
    public required int Year { get; init; }

    // Limits how many items can be in the collection (prevents massive payloads)
    [MaxLength(100, ErrorMessage = "Cannot add more than 100 actors at once.")]
    public ICollection<int> ActorsId { get; init; } = [];
}
