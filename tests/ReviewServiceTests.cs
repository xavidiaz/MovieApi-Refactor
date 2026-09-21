using Api.Data;
using Api.Dtos;
using Api.Entities;
using Api.Repositories;
using Api.Services;
using AutoMapper;
using Moq;

namespace Tests;

public class ReviewServiceTests
{
    [Fact]
    public async Task GetByIdAsync_ReturnReviewDto_WhenReviewExist()
    {
        var mockUow = new Mock<IUnitOfWork>();
        var mockReviewRepo = new Mock<IReviewRepository>();
        var mockMapper = new Mock<IMapper>();

        var review = new Review
        {
            Id = 1,
            Rating = 8.7,
            Text = "Genredefinierande sci-fi.",
            MovieId = 1,
        };
        var expectedDto = new ReviewDto
        {
            Id = 1,
            Rating = 8.7,
            Text = "Genredefinierande sci-fi.",
            MovieId = 1,
        };

        mockUow.Setup(u => u.Reviews).Returns(mockReviewRepo.Object);
        mockReviewRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(review);
        mockMapper.Setup(m => m.Map<ReviewDto>(review)).Returns(expectedDto);

        var service = new ReviewService(mockUow.Object, mockMapper.Object);

        var result = await service.GetByIdAsync(1);

        Assert.Equal(expectedDto.Text, result.Text);
    }
}
