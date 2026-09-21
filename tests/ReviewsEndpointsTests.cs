using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Api.Dtos;

namespace Tests;

public class ReviewsEndpointsTests(CustomWebApplicationFactory factory)
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetAllReviews_ReturnOk()
    {
        var response = await _client.GetAsync("/reviews");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetReviewById_ReturnOk()
    {
        var response = await _client.GetAsync("/reviews/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateReview_WithAuth_ReturnOk()
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            TestTokens.User
        );

        var createDto = new CreateReviewDto
        {
            Rating = 4.5,
            Text = "Rolig men ytlig uppföljare.",
            MovieId = 1,
        };

        var response = await _client.PostAsJsonAsync("/reviews", createDto);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
