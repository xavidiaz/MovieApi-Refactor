using System.ComponentModel.DataAnnotations;

namespace MovieApi.Domain.Dtos;

public class UpdateReviewDto
{
    [Range(1.0, 5.0, ErrorMessage = "Rating must be between 1.0 and 5.0.")]
    public required double Rating { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Review text cannot be empty.")]
    [StringLength(
        1000,
        MinimumLength = 5,
        ErrorMessage = "Review text must be between 5 and 1000 characters."
    )]
    public required string Text { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A valid MovieId is required.")]
    public required int MovieId { get; set; }
}
