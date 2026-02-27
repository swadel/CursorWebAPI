using CursorWebAPI.Application;
using CursorWebAPI.Domain;

namespace CursorWebAPI.UnitTests;

public sealed class ThisDayServiceTests
{
    [Fact]
    public async Task GetThisDayAsync_WhenDateIsNull_UsesUtcTodayMonthDay()
    {
        var utcToday = DateOnly.FromDateTime(DateTime.UtcNow);
        var expectedDateText = utcToday.ToString("MM-dd", System.Globalization.CultureInfo.InvariantCulture);

        var repo = new FakeShowRepository(_ => []);
        var service = new ThisDayService(repo);

        var response = await service.GetThisDayAsync(date: null, CancellationToken.None);

        Assert.Equal(expectedDateText, response.Date);
    }

    [Fact]
    public async Task GetThisDayAsync_WhenDateIsMonthDay_ReturnsShowsForThatMonthDay()
    {
        var show = new Show
        {
            Id = 123,
            ShowDate = new DateOnly(1977, 5, 8),
            Venue = "Barton Hall, Cornell University",
            City = "Ithaca",
            State = "NY",
            FunFact = "Test",
            ImageUrl = null,
            YouTubeUrl = null,
        };

        var repo = new FakeShowRepository(input =>
            input.month == 5 && input.day == 8 ? [show] : []);
        var service = new ThisDayService(repo);

        var response = await service.GetThisDayAsync("05-08", CancellationToken.None);

        Assert.Equal("05-08", response.Date);
        Assert.Single(response.Shows);
        Assert.Equal(new DateOnly(1977, 5, 8), response.Shows[0].ShowDate);
        Assert.Equal("Barton Hall, Cornell University", response.Shows[0].Venue);
    }

    [Fact]
    public async Task GetThisDayAsync_WhenDateIsFullDate_ExtractsMonthDay()
    {
        var repo = new FakeShowRepository(input =>
            input.month == 5 && input.day == 8 ? [] : throw new Exception("Unexpected input"));
        var service = new ThisDayService(repo);

        var response = await service.GetThisDayAsync("1977-05-08", CancellationToken.None);

        Assert.Equal("05-08", response.Date);
    }

    [Theory]
    [InlineData("not-a-date")]
    [InlineData("2026-99-99")]
    [InlineData("02-29")]
    public async Task GetThisDayAsync_WhenDateIsInvalid_ThrowsFormatException(string date)
    {
        var repo = new FakeShowRepository(_ => throw new Exception("Repo should not be called"));
        var service = new ThisDayService(repo);

        await Assert.ThrowsAsync<FormatException>(() => service.GetThisDayAsync(date, CancellationToken.None));
    }

    private sealed class FakeShowRepository(Func<(int month, int day), IReadOnlyList<Show>> handler) : IShowRepository
    {
        public Task<IReadOnlyList<Show>> GetByMonthDayAsync(int month, int day, CancellationToken cancellationToken) =>
            Task.FromResult(handler((month, day)));
    }
}