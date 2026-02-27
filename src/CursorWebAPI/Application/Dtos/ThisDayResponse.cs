namespace CursorWebAPI.Application.Dtos;

public sealed record ThisDayResponse(string Date, IReadOnlyList<ShowDto> Shows);

