using System.ComponentModel.DataAnnotations;

namespace MovieApi.Domain.Dtos;

public class UpdateMovieDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Title cannot be empty.")]
    [StringLength(
        200,
        MinimumLength = 1,
        ErrorMessage = "Title must be between 1 and 200 characters."
    )]
    public required string Title { get; set; }

    [Range(1888, 2100, ErrorMessage = "Please enter a valid release year.")]
    public required int Year { get; set; }

    [MaxLength(100, ErrorMessage = "Cannot assign more than 100 actors to a movie.")]
    public required ICollection<int> ActorsId { get; set; }
}
