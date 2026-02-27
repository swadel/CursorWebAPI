namespace CursorWebAPI.Application.Dtos;

public sealed record ShowDto(
    DateOnly ShowDate,
    string Venue,
    string City,
    string? State,
    string FunFact,
    string? ImageUrl,
    string? YouTubeUrl
);

