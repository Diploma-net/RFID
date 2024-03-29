using MediatR;
using RFLOT.Application.Commands;
using RFLOT.Application.Queries;
using RFLOT.WebApi.DTO;
using RFLOT.WebApi.DTO.Equip;

namespace RFLOT.WebApi.Endpoints;

public static class ZoneEndpoints
{
    public static WebApplication AddZoneEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/zone");
        
        endpoints.MapGet("/get-zones-by-plane",
            async (IMediator mediator, string planeId) =>
            {
                var zonesName = await mediator.Send(new GetZonesByIdPlaneQuery(planeId));
                return Results.Ok(zonesName);
            }); 
        
        return app;
    }
}