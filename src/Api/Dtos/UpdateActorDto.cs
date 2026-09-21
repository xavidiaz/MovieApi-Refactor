using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public class UpdateActorDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
    [StringLength(
        100,
        MinimumLength = 1,
        ErrorMessage = "First name must be between 1 and 100 characters."
    )]
    public required string FirstName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
    [StringLength(
        100,
        MinimumLength = 1,
        ErrorMessage = "Last name must be between 1 and 100 characters."
    )]
    public required string LastName { get; set; }

    [Range(1850, 2100, ErrorMessage = "Please enter a valid birth year.")]
    public required int BirthYear { get; set; }

    [MaxLength(100, ErrorMessage = "Cannot link more than 100 movies at once.")]
    public ICollection<int> MoviesId { get; set; } = [];
}
