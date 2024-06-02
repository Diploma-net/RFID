using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Equip.Models;
using RFLOT.Application.Monitoring.Command;
using RFLOT.Domain.Equip.ValueObjects;
using RFLOT.Domain.Report.ValueObjects;
using RFLOT.Gateway.Monitoring.Models;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Plane;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Monitoring.CommandHandler;

public class StartMonitoringCommandHandler : IRequestHandler<StartMonitoringCommand, Dictionary<string, Status>>
{
    private readonly ReportDbContext _reportDbContext;
    private readonly EquipDbContext _equipDbContext;
    private readonly PlaneDbContext _planeDbContext;

    public StartMonitoringCommandHandler(ReportDbContext reportDbContext, EquipDbContext equipDbContext,
        PlaneDbContext planeDbContext)
    {
        _reportDbContext = reportDbContext;
        _equipDbContext = equipDbContext;
        _planeDbContext = planeDbContext;
    }

    public async Task<Dictionary<string, Status>> Handle(StartMonitoringCommand command,
        CancellationToken cancellationToken)
    {
        var plane = await _planeDbContext.Planes.FirstOrDefaultAsync(p => p.Name == command.PlaneName,
            cancellationToken: cancellationToken);
        if (plane is null)
        {
            throw new ApplicationException("Неверное имя самолёта");
        }
        var report =
            await _reportDbContext.Reports.FirstOrDefaultAsync(r => r.StatusReport == true && r.IdPlane == plane.Id,
                cancellationToken: cancellationToken);
        var result = new Dictionary<string, Status>();
        var zoneReports = report.ZoneReports;
        var equipReports = new List<EquipReport>();
        foreach (var zoneReport in zoneReports)
        {
            equipReports.AddRange(zoneReport.EquipReports);
            foreach (var equipReport in zoneReport.EquipReports)
            {
                result.Add(equipReport.Space, equipReport.Status);
            }
        }
        return result;
    }
}