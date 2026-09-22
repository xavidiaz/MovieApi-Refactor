using Api.Data;
using Api.Repositories;
using AutoMapper;
using Moq;
using MovieApi.Application.Services;
using MovieApi.Domain.Dtos;
using MovieApi.Domain.Entities;

namespace Tests;

public class ActorServiceTests
{
    [Fact]
    public async Task GetByIdAsync_ReturnActorDto_WhenActorExist()
    {
        var mockUow = new Mock<IUnitOfWork>();
        var mockActorRepo = new Mock<IActorRepository>();
        var mockMapper = new Mock<IMapper>();

        var actor = new Actor
        {
            Id = 1,
            FirstName = "Keanu",
            LastName = "Reeves",
            BirthYear = 1964,
        };
        var expectedDto = new ActorDto
        {
            Id = 1,
            FirstName = "Keanu",
            LastName = "Reeves",
            BirthYear = 1964,
        };

        mockUow.Setup(u => u.Actors).Returns(mockActorRepo.Object);
        mockActorRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(actor);
        mockMapper.Setup(m => m.Map<ActorDto>(actor)).Returns(expectedDto);

        var service = new ActorService(mockUow.Object, mockMapper.Object);

        var result = await service.GetByIdAsync(1);

        Assert.Equal(expectedDto.FirstName, result.FirstName);
    }
}
