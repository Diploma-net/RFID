using MediatR;
using Microsoft.AspNetCore.SignalR;
using RFLOT.Domain.Report.Events;
using RFLOT.Gateway.Monitoring.Models;

namespace RFLOT.Application.Monitoring;

public class MonitoringHub : Hub, INotificationHandler<NewEquipCheckedInReport>
{
    private readonly List<(string, List<PlaneConnection>)> _planeConnections =
        new List<(string, List<PlaneConnection>)>();

    private readonly List<(string, List<ZoneConnection>)> _zoneConnections = new List<(string, List<ZoneConnection>)>();

    public async Task JoinInMonitoringZone(ZoneConnection connection)
    {
        if (_zoneConnections.Any(z => 
                z.Item1 == $"{connection.IdReport.ToString()}_{connection.IdZone.ToString()}"))
        {
            _zoneConnections
                .First(z => 
                    z.Item1 == $"{connection.IdReport.ToString()}_{connection.IdZone.ToString()}")
                .Item2.Add(connection);
        }
        else
        {
            _zoneConnections.Add(($"{connection.IdReport.ToString()}_{connection.IdZone.ToString()}",
                new List<ZoneConnection> { connection }));
        }

        await Groups
            .AddToGroupAsync(Context.ConnectionId,
            $"{connection.IdReport.ToString()}_{connection.IdZone.ToString()}");
    }

    public async Task JoinInMonitoringPlane(PlaneConnection connection)
    {
        if (_planeConnections.Any(z => 
                z.Item1 == connection.IdReport.ToString()))
        {
            _planeConnections
                .First(z => 
                    z.Item1 == connection.IdReport.ToString())
                .Item2.Add(connection);
        }
        else
        {
            _planeConnections.Add((connection.IdReport.ToString(), new List<PlaneConnection> { connection }));
        }

        await Groups
            .AddToGroupAsync(Context.ConnectionId, connection.IdReport.ToString());
    }

    public async Task Handle(NewEquipCheckedInReport notification, CancellationToken cancellationToken)
    {
        if (Clients != null)
        {
            await Clients.Groups(new List<string>
            {
                notification.IdReport.ToString(),
                $"{notification.IdReport.ToString()}/{notification.IdZone.ToString()}"
            })
                .SendCoreAsync("NewEquipCheck", 
                    new object[] { new Message(notification.Space, notification.Status) },
                cancellationToken);
        }
    }
}