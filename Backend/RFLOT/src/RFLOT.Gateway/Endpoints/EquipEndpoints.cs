using MediatR;
using RFLOT.Application.Equip.Command;
using RFLOT.Domain.Equip.ValueObjects;
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
            async (IMediator mediator, string idEquip, Status statusEquip, Guid idZone, Guid idReport, Guid idUser) =>
            {
                var result = await mediator.Send(new CheckEquipCommand(idEquip, statusEquip, idZone, idReport, idUser));
                return Results.Ok(result);
            });

        return app;
    }
}