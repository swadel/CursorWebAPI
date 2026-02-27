using System.Globalization;
using CursorWebAPI.Application.Dtos;
using CursorWebAPI.Domain;

namespace CursorWebAPI.Application;

public sealed class ThisDayService(IShowRepository showRepository)
{
    public async Task<ThisDayResponse> GetThisDayAsync(string? date, CancellationToken cancellationToken)
    {
        var (month, day, normalizedDate) = ParseDate(date);

        var shows = await showRepository.GetByMonthDayAsync(month, day, cancellationToken);

        var showDtos = shows
            .OrderBy(s => s.ShowDate)
            .Select(Map)
            .ToArray();

        return new ThisDayResponse(normalizedDate, showDtos);
    }

    private static ShowDto Map(Show s) =>
        new(
            s.ShowDate,
            s.Venue,
            s.City,
            s.State,
            s.FunFact,
            s.ImageUrl,
            s.YouTubeUrl
        );

    private static (int month, int day, string normalizedDate) ParseDate(string? date)
    {
        if (string.IsNullOrWhiteSpace(date))
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            return (today.Month, today.Day, today.ToString("MM-dd", CultureInfo.InvariantCulture));
        }

        var trimmed = date.Trim();

        // Accept MM-dd
        if (DateOnlyTryParseMonthDay(trimmed, out var month, out var day, out var monthDayText))
        {
            return (month, day, monthDayText);
        }

        // Accept yyyy-MM-dd (extract month/day)
        if (DateOnly.TryParseExact(
                trimmed,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var fullDate))
        {
            return (fullDate.Month, fullDate.Day, fullDate.ToString("MM-dd", CultureInfo.InvariantCulture));
        }

        throw new FormatException("Invalid date format. Use MM-dd or yyyy-MM-dd.");
    }

    private static bool DateOnlyTryParseMonthDay(string value, out int month, out int day, out string monthDayText)
    {
        month = 0;
        day = 0;
        monthDayText = string.Empty;

        // fast-path for "MM-dd" (5 chars)
        if (value.Length != 5 || value[2] != '-')
        {
            return false;
        }

        if (!int.TryParse(value.AsSpan(0, 2), NumberStyles.None, CultureInfo.InvariantCulture, out month))
        {
            return false;
        }

        if (!int.TryParse(value.AsSpan(3, 2), NumberStyles.None, CultureInfo.InvariantCulture, out day))
        {
            return false;
        }

        if (month is < 1 or > 12)
        {
            return false;
        }

        // Validate day-of-month against a non-leap year (Feb 29 not allowed for MM-dd input).
        // If callers need Feb 29 support, they can pass a full yyyy-MM-dd.
        var maxDay = DateTime.DaysInMonth(2001, month);
        if (day < 1 || day > maxDay)
        {
            return false;
        }

        monthDayText = value;
        return true;
    }
}

