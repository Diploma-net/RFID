using MediatR;
using RFLOT.Application.Commands;
using RFLOT.WebApi.DTO;
using RFLOT.WebApi.DTO.Equip;

namespace RFLOT.WebApi.Endpoints;

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
        return app;
    }
}