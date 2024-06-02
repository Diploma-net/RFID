using MediatR;
using RFLOT.Application.DataGenerate;
using RFLOT.Application.Zone.Command;
using RFLOT.BackgroundTasks.Jobs;
using RFLOT.Gateway.DTO.Zone;

namespace RFLOT.Gateway.Endpoints;

public static class SystemEndpoints
{
    public static WebApplication AddSystemEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/system");
        endpoints.MapPost("/stop-check",
            async (IMediator mediator) =>
            {
                await mediator.Send(new StopAllReportsJob());
                return Results.Ok();
            });
        var endpointsGenerate = endpoints.MapGroup("/generate");
        endpointsGenerate.MapPost("/full",
            async (IMediator mediator, int count) =>
            {
                var result = await mediator.Send(new FullReportGenerateCommand(count));
                return Results.Ok(result);
            });
        return app;
    }
}