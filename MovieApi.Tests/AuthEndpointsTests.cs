using System.Net;
using System.Net.Http.Headers;

namespace MovieApi.Tests;

public class AuthEndpointsTests : IDisposable
{
    private readonly CustomWebApplicationFactory _factory = new();
    private readonly HttpClient _client;

    public AuthEndpointsTests()
    {
        _client = _factory.CreateClient();
    }

    public void Dispose() => _factory.Dispose();

    [Theory]
    [InlineData("/movies/1")]
    [InlineData("/actors/1")]
    [InlineData("/reviews/1")]
    public async Task Delete_WithoutToken_ReturnUnauthorized(string url)
    {
        var response = await _client.DeleteAsync(url);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Theory]
    [InlineData("/movies/1")]
    [InlineData("/actors/1")]
    [InlineData("/reviews/1")]
    public async Task Delete_WithoutAdminRole_ReturnForbidden(string url)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            TestTokens.User
        );

        var response = await _client.DeleteAsync(url);

        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Theory]
    [InlineData("/movies/1")]
    [InlineData("/actors/1")]
    [InlineData("/reviews/1")]
    public async Task Delete_WithAdminRole_ReturnOk(string url)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            TestTokens.Admin
        );

        var response = await _client.DeleteAsync(url);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
