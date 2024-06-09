using MediatR;
using RFLOT.Application.Analytic.Query;

namespace RFLOT.Gateway.Endpoints;

public static class AnalyticEndpoints
{
    public static WebApplication AddAnalyticEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/analytic");

        endpoints.MapGet("/global-analytic",
            async (IMediator mediator) => Results.Ok((object?)await mediator.Send(new GetGlobalAnalyticQuery())));
        return app;
    }
}