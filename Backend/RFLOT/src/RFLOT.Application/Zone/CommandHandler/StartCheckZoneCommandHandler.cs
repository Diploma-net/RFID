using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Report.Models;
using RFLOT.Application.Zone.Command;
using RFLOT.Application.Zone.Models;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Report;
using RFLOT.Infrastructure.Zone;

namespace RFLOT.Application.Zone.CommandHandler;

public class StartCheckZoneCommandHandler : IRequestHandler<StartCheckZoneCommand, OneZoneInfo>
{
    private readonly EquipDbContext _equipContext;
    private readonly ReportDbContext _reportContext;
    private readonly ZoneDbContext _zoneDbContext;

    public StartCheckZoneCommandHandler(EquipDbContext equipContext, ReportDbContext reportContext,
        ZoneDbContext zoneDbContext)
    {
        _equipContext = equipContext;
        _reportContext = reportContext;
        _zoneDbContext = zoneDbContext;
    }

    public async Task<OneZoneInfo> Handle(StartCheckZoneCommand command, CancellationToken cancellationToken)
    {
        var report =
            await _reportContext.Reports
                .FirstOrDefaultAsync(r => r.Id == command.IdReport,
                cancellationToken: cancellationToken);
        report.StartZoneReport(command.IdZone, command.IdUser);
        _reportContext.Update(report);
        await _reportContext.SaveChangesAsync(cancellationToken);
        var zone = await _zoneDbContext.Zones
            .FirstOrDefaultAsync(z => z.Id == command.IdZone,
            cancellationToken: cancellationToken);
        var equipsResult = (from equipResults in report.ZoneReports
                .Select(z => z.EquipReports)
            from equipResult in equipResults
            select new ReportEquipResult { Status = equipResult.Status, Space = equipResult.Space })
            .ToList();
        return new OneZoneInfo
        {
            Name = zone.Name,
            Spaces = _equipContext.Equips
                .Where(e => e.ZoneId == command.IdZone)
                .Select(e => e.Space)
                .ToList(),
            EquipResults = equipsResult
        };
    }
}