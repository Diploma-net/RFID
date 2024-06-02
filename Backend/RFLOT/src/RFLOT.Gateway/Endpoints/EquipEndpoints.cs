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

        endpoints.MapPost("/check",
            async (IMediator mediator, CheckEquipDto checkEquipDto) =>
            {
                var result = await mediator.Send(new CheckEquipCommand(checkEquipDto.IdEquip, checkEquipDto.StatusEquip,
                    checkEquipDto.IdZone, checkEquipDto.IdReport, checkEquipDto.IdUser));
                return Results.Ok(new {EquipInfo = result});
            });
        
        endpoints.MapPost("/exit-check",
            async (IMediator mediator, EquipExitCheckDto equipExitCheckDto) =>
            {
                var result = await mediator.Send(new EquipExitCheckCommand(equipExitCheckDto.IdEquip));
                return result != null ? Results.Ok(new {EquipInfo = result}) : Results.NotFound();
            });

        return app;
    }
}