using System.Net;
using System.Net.Http.Json;
using CursorWebAPI.Application.Dtos;
using CursorWebAPI.IntegrationTests.Fixtures;
using Microsoft.AspNetCore.Mvc;

namespace CursorWebAPI.IntegrationTests;

public sealed class ThisDayEndpointTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    [Fact]
    public async Task GetThisDayGratefulDead_WhenKnownDate_ReturnsCornell77()
    {
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/this-day/grateful-dead?date=05-08");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<ThisDayResponse>();
        Assert.NotNull(payload);
        Assert.Equal("05-08", payload!.Date);
        Assert.Single(payload.Shows);
        Assert.Equal(new DateOnly(1977, 5, 8), payload.Shows[0].ShowDate);
    }

    [Fact]
    public async Task GetThisDayGratefulDead_WhenNoShows_ReturnsEmptyArray()
    {
        using var client = factory.CreateClient();

        var payload = await client.GetFromJsonAsync<ThisDayResponse>("/this-day/grateful-dead?date=12-25");

        Assert.NotNull(payload);
        Assert.Equal("12-25", payload!.Date);
        Assert.Empty(payload.Shows);
    }

    [Fact]
    public async Task GetThisDayGratefulDead_WhenBadDate_Returns400ProblemDetails()
    {
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/this-day/grateful-dead?date=not-a-date");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        Assert.NotNull(problem);
        Assert.Equal(400, problem!.Status);
    }

    [Fact]
    public async Task Health_Returns200()
    {
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}