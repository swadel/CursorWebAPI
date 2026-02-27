namespace CursorWebAPI.Domain;

public class Show
{
    public int Id { get; set; }
    public DateOnly ShowDate { get; set; }
    public required string Venue { get; set; }
    public required string City { get; set; }
    public string? State { get; set; }
    public required string FunFact { get; set; }
    public string? ImageUrl { get; set; }
    public string? YouTubeUrl { get; set; }
}

