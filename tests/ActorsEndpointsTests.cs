using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using MovieApi.Domain.Dtos;

namespace Tests;

public class ActorsEndpointsTests(CustomWebApplicationFactory factory)
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetAllActors_ReturnOk()
    {
        var response = await _client.GetAsync("/actors");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetActorById_ReturnOk()
    {
        var response = await _client.GetAsync("/actors/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateActor_WithAuth_ReturnOk()
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            TestTokens.User
        );

        var createDto = new CreateActorDto
        {
            FirstName = "Will",
            LastName = "Smith",
            BirthYear = 1968,
            MoviesId = [],
        };

        var response = await _client.PostAsJsonAsync("/actors", createDto);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
