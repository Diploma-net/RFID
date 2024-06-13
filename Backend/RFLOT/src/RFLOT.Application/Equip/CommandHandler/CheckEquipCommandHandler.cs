using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Equip.Command;
using RFLOT.Application.Equip.Models;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Report;
using RFLOT.Infrastructure.Zone;

namespace RFLOT.Application.Equip.CommandHandler;

public class CheckEquipCommandHandler : IRequestHandler<CheckEquipCommand, EquipInfo>
{
    private readonly EquipDbContext _equipDbContext;
    private readonly ReportDbContext _reportDbContext;
    private readonly ZoneDbContext _zoneDbContext;

    public CheckEquipCommandHandler(EquipDbContext equipDbContext, ReportDbContext reportDbContext,
        ZoneDbContext zoneDbContext)
    {
        _equipDbContext = equipDbContext;
        _reportDbContext = reportDbContext;
        _zoneDbContext = zoneDbContext;
    }

    public async Task<EquipInfo> Handle(CheckEquipCommand command, CancellationToken cancellationToken)
    {
        var equip =
            await _equipDbContext.Equips
                .FirstOrDefaultAsync(e => e.Id == command.IdEquip,
                cancellationToken) 
            ?? throw new ApplicationException("АСО не найдено");
        var equipLastStatus = equip.LastStatus;
        equip.CheckEquip(command.StatusEquip, command.IdReport, command.IdZone, command.IdUser);
        _equipDbContext.Update(equip);
        await _equipDbContext.SaveChangesAsync(cancellationToken);
        var report = await _reportDbContext.Reports
            .FirstOrDefaultAsync(r => r.Id == command.IdReport,
            cancellationToken: cancellationToken);
        var countEquip = 0;
        var zones = _zoneDbContext.Zones
            .Where(z => z.IdPlane == report.IdPlane);
        foreach (var zone in zones)
        {
            countEquip += _equipDbContext.Equips
                .Count(e => e.ZoneId == zone.Id);
        }

        if (report.ZoneReports.Select(z => z.EquipReports.Count)
                .Count() >= countEquip)
        {
            report.StatusReport = false;
        }

        await _reportDbContext.SaveChangesAsync(cancellationToken);
        return new EquipInfo
        {
            Space = equip.Space,
            Type = equip.Type,
            Name = equip.Name,
            LastStatus = equipLastStatus
        };
    }
}