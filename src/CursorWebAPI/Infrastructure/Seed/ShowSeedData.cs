using CursorWebAPI.Domain;

namespace CursorWebAPI.Infrastructure.Seed;

public static class ShowSeedData
{
    public static readonly Show[] Shows =
    [
        new Show
        {
            Id = 1,
            ShowDate = new DateOnly(1977, 5, 8),
            Venue = "Barton Hall, Cornell University",
            City = "Ithaca",
            State = "NY",
            FunFact =
                "Widely considered one of the greatest Grateful Dead concerts ever performed. The tape circulated for decades as a legendary bootleg.",
            ImageUrl =
                "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4e/Barton_Hall_Cornell.jpg/800px-Barton_Hall_Cornell.jpg",
            YouTubeUrl = "https://www.youtube.com/watch?v=jLGk3CVMdQU",
        },
        new Show
        {
            Id = 2,
            ShowDate = new DateOnly(1972, 8, 27),
            Venue = "Old Renaissance Faire Grounds",
            City = "Veneta",
            State = "OR",
            FunFact =
                "The iconic \"Sunshine Daydream\" show—famous for its high energy and the psychedelic film footage from the day.",
            ImageUrl =
                "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Veneta%2C_Oregon.jpg/800px-Veneta%2C_Oregon.jpg",
            YouTubeUrl = "https://www.youtube.com/watch?v=JidgG6g1l3o",
        },
        new Show
        {
            Id = 3,
            ShowDate = new DateOnly(1989, 7, 7),
            Venue = "John F. Kennedy Stadium",
            City = "Philadelphia",
            State = "PA",
            FunFact =
                "A massive summer '89 stadium performance—often cited as a peak era for the band's late-career sound.",
            ImageUrl = null,
            YouTubeUrl = null,
        },
        new Show
        {
            Id = 4,
            ShowDate = new DateOnly(1987, 9, 18),
            Venue = "Madison Square Garden",
            City = "New York",
            State = "NY",
            FunFact =
                "A strong late-'80s run at MSG—part of the post-\"Touch of Grey\" resurgence that brought in a new wave of fans.",
            ImageUrl = null,
            YouTubeUrl = null,
        },
        new Show
        {
            Id = 5,
            ShowDate = new DateOnly(1970, 2, 13),
            Venue = "Fillmore East",
            City = "New York",
            State = "NY",
            FunFact =
                "A classic early-1970 Fillmore East set, showcasing the band as it bridged the psychedelic era into tighter songcraft.",
            ImageUrl = null,
            YouTubeUrl = null,
        },
        new Show
        {
            Id = 6,
            ShowDate = new DateOnly(1995, 7, 9),
            Venue = "Soldier Field",
            City = "Chicago",
            State = "IL",
            FunFact =
                "The band's final concert—an emotional capstone to three decades of touring and a major point of reflection in Deadhead history.",
            ImageUrl = null,
            YouTubeUrl = null,
        },
    ];
}

