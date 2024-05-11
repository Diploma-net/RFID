using MediatR;
using RFLOT.Application.Equip.Command;
using RFLOT.Gateway.DTO.Equip;

namespace RFLOT.Gateway.Endpoints;

public static class EquipEndpoints
{
    public static WebApplication AddEquipEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/equip");

        endpoints.MapPost("/add",
            async (IMediator mediator, NewEquip.Request request) =>
            {
                await mediator.Send(new AddNewEquipCommand(request.Id, request.ZoneId, request.PlanePlace, request.Name,
                    request.Type, request.DateTimeEnd));
                return Results.Ok();
            });

        endpoints.MapGet("/check",
            async (IMediator mediator, Guid rfid) =>
            {
                var result = await mediator.Send(new CheckEquipCommand(rfid));
                return Results.Ok(result);
            });

        return app;
    }
}