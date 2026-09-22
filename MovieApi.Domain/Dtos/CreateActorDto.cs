using System.ComponentModel.DataAnnotations;

namespace MovieApi.Domain.Dtos;

public class CreateActorDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
    [StringLength(
        100,
        MinimumLength = 1,
        ErrorMessage = "First name must be between 1 and 100 characters."
    )]
    public required string FirstName { get; init; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
    [StringLength(
        100,
        MinimumLength = 1,
        ErrorMessage = "Last name must be between 1 and 100 characters."
    )]
    public required string LastName { get; init; }

    [Range(1850, 2100, ErrorMessage = "Please enter a valid birth year.")]
    public required int BirthYear { get; init; }

    [MaxLength(100, ErrorMessage = "Cannot link more than 100 movies at once.")]
    public ICollection<int> MoviesId { get; init; } = [];
}
