using MediatR;
using Microsoft.AspNetCore.SignalR;
using RFLOT.Domain.Equip.Events;
using RFLOT.Domain.Equip.ValueObjects;
using RFLOT.Domain.Report.Events;
using RFLOT.Gateway.Monitoring.Models;

namespace RFLOT.Application.Monitoring;

public class MonitoringHub : Hub, INotificationHandler<NewEquipCheckedInReport>
{
    public async Task JoinInMonitoringZone(ZoneConnection connection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId,
            $"{connection.IdReport.ToString()}_{connection.IdZone.ToString()}");
    }

    public async Task JoinInMonitoringPlane(PlaneConnection connection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, connection.IdReport.ToString());
    }

    public async Task Handle(NewEquipCheckedInReport notification, CancellationToken cancellationToken)
    {
        await Clients.Groups(new List<string>
        {
            $"{notification.IdReport.ToString()}",
            $"{notification.IdReport.ToString()}/{notification.IdZone.ToString()}"
        }).SendCoreAsync("NewEquipCheck", [new Message(notification.Space, notification.Status)], cancellationToken);
    }
}