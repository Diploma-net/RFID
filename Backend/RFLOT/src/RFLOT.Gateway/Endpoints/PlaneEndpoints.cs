using MediatR;
using RFLOT.Application.Plane.Command;
using RFLOT.Domain.Report.ValueObjects;
using RFLOT.Gateway.DTO.Equip;

namespace RFLOT.Gateway.Endpoints;

public static class PlaneEndpoints
{
    public static WebApplication AddPlaneEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/plane");

        endpoints.MapPost("/start",
            async (IMediator mediator, string idPlane, Guid idUser, ReportType typeCheck) =>
            {
                var reportId = await mediator.Send(new StartCheckPlaneCommand(idPlane, idUser, typeCheck));
                return Results.Ok(reportId);
            });
        return app;
    }
}