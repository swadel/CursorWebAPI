using CursorWebAPI.Domain;

namespace CursorWebAPI.Application;

public interface IShowRepository
{
    Task<IReadOnlyList<Show>> GetByMonthDayAsync(int month, int day, CancellationToken cancellationToken);
}

