using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using MovieApi.Domain.Dtos;

namespace Tests;

public class MoviesEndpointsTests(CustomWebApplicationFactory factory)
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetAllMovies_ReturnOk()
    {
        var response = await _client.GetAsync("/movies");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetMovieById_ReturnOk()
    {
        var response = await _client.GetAsync("/movies/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateMovie_WithAuth_ReturnOk()
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            TestTokens.User
        );

        var createDto = new CreateMovieDto
        {
            Title = "Men In Black",
            Year = 2000,
            ActorsId = [],
        };

        var response = await _client.PostAsJsonAsync("/movies", createDto);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
