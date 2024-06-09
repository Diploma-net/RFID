using MediatR;
using RFLOT.Application.Plane.Command;
using RFLOT.Application.Report.Command;
using RFLOT.Domain.Report.ValueObjects;
using RFLOT.Gateway.DTO.Equip;
using RFLOT.Gateway.DTO.Plane;

namespace RFLOT.Gateway.Endpoints;

public static class PlaneEndpoints
{
    public static WebApplication AddPlaneEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/plane");

        endpoints.MapPost("/start",
            async (IMediator mediator, StartCheckPlaneDto startCheckDto) =>
            {
                var reportId = await mediator.Send(new StartCheckPlaneCommand(startCheckDto.IdPlane,
                    startCheckDto.IdUser, startCheckDto.TypeCheck));
                return Results.Ok(new { ReportId = reportId });
            });
        endpoints.MapPost("/stop",
            async (IMediator mediator, StopCheckPlaneDto stopCheckPlaneDto) =>
            {
                await mediator.Send(new StopReportCommand(stopCheckPlaneDto.IdReport));
                return Results.Ok();
            });
        return app;
    }
}