using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Domain.Equip.Events;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Report.NotificationHandler;

public class CheckedEquipNotificationHandler : INotificationHandler<EquipChecked>
{
    private readonly ReportDbContext _reportDbContext;
    private readonly EquipDbContext _equipDbContext;

    public CheckedEquipNotificationHandler(ReportDbContext reportDbContext, EquipDbContext equipDbContext)
    {
        _reportDbContext = reportDbContext;
        _equipDbContext = equipDbContext;
    }

    public async Task Handle(EquipChecked notification, CancellationToken cancellationToken)
    {
        var report = await _reportDbContext.Reports.FirstOrDefaultAsync(r => r.Id == notification.IdReport,
            cancellationToken: cancellationToken);
        var equip = await _equipDbContext.Equips.FirstOrDefaultAsync(e => e.Id == notification.IdEquip,
            cancellationToken: cancellationToken);
        report.AddCheckedEquip(notification.IdZone, notification.IdEquip, notification.Status, equip.Space,
            notification.IdUser);
        _reportDbContext.Update(report);
        await _reportDbContext.SaveChangesAsync(cancellationToken);
    }
}