using Api.Data;
using Api.Dtos;
using Api.Entities;
using Api.Repositories;
using Api.Services;
using AutoMapper;
using Moq;

namespace Tests;

public class MovieServiceTests
{
    [Fact]
    public async Task GetByIdAsync_ReturnMovieDto_WhenMovieExist()
    {
        var mockUow = new Mock<IUnitOfWork>();
        var mockMovieRepo = new Mock<IMovieRepository>();
        var mockMapper = new Mock<IMapper>();

        var movie = new Movie
        {
            Id = 1,
            Title = "Inception",
            Year = 2010,
        };
        var expectedDto = new MovieDto
        {
            Id = 1,
            Title = "Inception",
            Year = 2010,
        };

        mockUow.Setup(u => u.Movies).Returns(mockMovieRepo.Object);
        mockMovieRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(movie);
        mockMapper.Setup(m => m.Map<MovieDto>(movie)).Returns(expectedDto);

        var service = new MovieService(mockUow.Object, mockMapper.Object);

        var result = await service.GetByIdAsync(1);

        Assert.Equal(expectedDto.Title, result.Title);
    }
}
