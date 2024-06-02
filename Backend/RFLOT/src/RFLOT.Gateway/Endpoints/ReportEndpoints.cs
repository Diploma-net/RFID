using MediatR;
using RFLOT.Application.Plane.Command;
using RFLOT.Application.Report.Query;
using RFLOT.Domain.Report.ValueObjects;
using RFLOT.Gateway.DTO.Plane;
using RFLOT.Gateway.DTO.Report;

namespace RFLOT.Gateway.Endpoints;

public static class ReportEndpoints
{
    public static WebApplication AddReportEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/report");

        endpoints.MapGet("/get-reports",
            async (IMediator mediator, bool reportResult, string? planeName, DateOnly? reportDate, ReportType? reportType) =>
            {
                try
                {
                    var reportId = await mediator.Send(new GetReportsQuery(reportResult,
                        planeName, reportDate, reportType));
                    return Results.Ok(reportId);
                }
                catch (Exception e)
                {
                    return Results.NotFound(e.Message);
                }
            });
        endpoints.MapGet("/get-report",
            async (IMediator mediator, Guid idReport) =>
            {
                try
                {
                    var reportId = await mediator.Send(new GetReportQuery(idReport));
                    return Results.Ok(reportId);
                }
                catch (Exception e)
                {
                    return Results.NotFound(e.Message);
                }
            });
        return app;
    }
}