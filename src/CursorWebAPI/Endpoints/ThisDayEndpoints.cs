using CursorWebAPI.Application;
using CursorWebAPI.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CursorWebAPI.Endpoints;

public static class ThisDayEndpoints
{
    public static IEndpointRouteBuilder MapThisDayEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/this-day");

        group.MapGet("/grateful-dead",
                async ([FromQuery] string? date, ThisDayService service, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        ThisDayResponse response = await service.GetThisDayAsync(date, cancellationToken);
                        return Results.Ok(response);
                    }
                    catch (FormatException ex)
                    {
                        return Results.Problem(
                            detail: ex.Message,
                            statusCode: StatusCodes.Status400BadRequest,
                            title: "Bad Request");
                    }
                })
            .WithName("GetThisDayGratefulDead")
            .Produces<ThisDayResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        return app;
    }
}

