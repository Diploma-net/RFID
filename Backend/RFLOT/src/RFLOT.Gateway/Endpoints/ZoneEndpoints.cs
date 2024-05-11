using MediatR;
using RFLOT.Application.Zone.Query;

namespace RFLOT.Gateway.Endpoints;

public static class ZoneEndpoints
{
    public static WebApplication AddZoneEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/zone");

        endpoints.MapGet("/get-zones-by-plane",
            async (IMediator mediator, Guid planeId) =>
            {
                var zonesName = await mediator.Send(new GetZonesByIdPlaneQuery(planeId));
                return Results.Ok(zonesName);
            });

        return app;
    }
}