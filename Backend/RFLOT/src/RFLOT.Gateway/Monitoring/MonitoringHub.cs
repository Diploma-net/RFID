using MediatR;
using Microsoft.AspNetCore.SignalR;
using RFLOT.Application.Report.Models;
using RFLOT.Application.Report.Query;
using RFLOT.Gateway.Monitoring.Models;

namespace RFLOT.Gateway.Monitoring;

public class MonitoringHub : Hub
{
    private readonly Mediator _mediator;

    public MonitoringHub(Mediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ReportPlaneResult> JoinInMonitoring(NewConnection connection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, connection.IdReport.ToString());
        return await _mediator.Send(new GetReportPlaneQuery(connection.IdReport));
    }

    public async Task NewEquipCheck(Guid IdReport)
    {
    }
}