using CursorWebAPI.Application;
using CursorWebAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursorWebAPI.Infrastructure;

public sealed class ShowRepository(AppDbContext dbContext) : IShowRepository
{
    public async Task<IReadOnlyList<Show>> GetByMonthDayAsync(int month, int day, CancellationToken cancellationToken)
    {
        // SQLite maps DateOnly to TEXT (yyyy-MM-dd); use strftime so filtering stays server-side.
        var monthStr = month.ToString("D2");
        var dayStr = day.ToString("D2");

        return await dbContext.Shows
            .FromSqlInterpolated(
                $"SELECT * FROM Shows WHERE strftime('%m', ShowDate) = {monthStr} AND strftime('%d', ShowDate) = {dayStr}"
            )
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}

