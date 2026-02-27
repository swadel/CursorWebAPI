using CursorWebAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursorWebAPI.Infrastructure;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Show> Shows => Set<Show>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var shows = modelBuilder.Entity<Show>();

        shows.HasKey(s => s.Id);

        shows.Property(s => s.ShowDate).IsRequired();
        shows.Property(s => s.Venue).HasMaxLength(200).IsRequired();
        shows.Property(s => s.City).HasMaxLength(100).IsRequired();
        shows.Property(s => s.State).HasMaxLength(100);
        shows.Property(s => s.FunFact).HasMaxLength(2000).IsRequired();
        shows.Property(s => s.ImageUrl).HasMaxLength(500);
        shows.Property(s => s.YouTubeUrl).HasMaxLength(500);

        shows.HasIndex(s => s.ShowDate);
    }
}

