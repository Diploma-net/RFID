using MediatR;
using RFLOT.Application.Zone.Command;
using RFLOT.Application.Zone.Query;
using RFLOT.Gateway.DTO.Zone;

namespace RFLOT.Gateway.Endpoints;

public static class ZoneEndpoints
{
    public static WebApplication AddZoneEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/zone");

        endpoints.MapPost("/get-zones",
            async (IMediator mediator, GetZonesDto getZonesDto) =>
            {
                var zonesName = await mediator.Send(new GetZonesByIdReportQuery(getZonesDto.IdReport));
                return Results.Ok(new {ZonesName = zonesName});
            });
        endpoints.MapPost("/start-check",
            async (IMediator mediator, StartCheckZoneDto startCheckDto) =>
            {
                var oneZoneInfo = await mediator.Send(new StartCheckZoneCommand(startCheckDto.IdZone, startCheckDto.IdReport, startCheckDto. IdUser));
                return Results.Ok(new {OneZoneInfo = oneZoneInfo});
            });
        endpoints.MapPost("/stop-check",
            async (IMediator mediator, StopCheckZoneDto stopCheckDto) =>
            {
                await mediator.Send(new StopCheckZoneCommand(stopCheckDto.IdZone, stopCheckDto.IdReport, stopCheckDto.IdUser));
                return Results.Ok();
            });
        return app;
        
    }
}