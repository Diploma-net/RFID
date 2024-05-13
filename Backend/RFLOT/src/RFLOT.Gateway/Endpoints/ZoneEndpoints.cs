using MediatR;
using RFLOT.Application.Zone.Command;
using RFLOT.Application.Zone.Query;

namespace RFLOT.Gateway.Endpoints;

public static class ZoneEndpoints
{
    public static WebApplication AddZoneEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/zone");

        endpoints.MapGet("/get-zones",
            async (IMediator mediator, Guid idReport) =>
            {
                var zonesName = await mediator.Send(new GetZonesByIdReportQuery(idReport));
                return Results.Ok(zonesName);
            });
        endpoints.MapPost("/start-check",
            async (IMediator mediator, Guid idZone, Guid idReport, Guid idUser) =>
            {
                var zonesName = await mediator.Send(new StartCheckZoneCommand(idZone, idReport, idUser));
                return Results.Ok(zonesName);
            });
        return app;
        
    }
}