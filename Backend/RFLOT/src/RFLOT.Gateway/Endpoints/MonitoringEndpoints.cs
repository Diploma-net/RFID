using MediatR;
using RFLOT.Application.Monitoring.Command;
using RFLOT.Application.Plane.Command;
using RFLOT.Gateway.DTO.Monitoring;
using RFLOT.Gateway.DTO.Plane;

namespace RFLOT.Gateway.Endpoints;

public static class MonitoringEndpoints
{
    public static WebApplication AddMonitoringEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/plane");

        endpoints.MapPost("/start-monitoring",
            async (IMediator mediator, StartMonitoringDto startMonitoringDto) =>
            {
                var result = await mediator.Send(new StartMonitoringCommand(startMonitoringDto.PlaneName));
                return Results.Ok(result);
            });
        return app;
    }
}