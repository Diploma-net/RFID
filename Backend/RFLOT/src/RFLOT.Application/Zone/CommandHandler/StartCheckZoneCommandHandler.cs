using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Report.Models;
using RFLOT.Application.Zone.Command;
using RFLOT.Application.Zone.Models;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Zone.CommandHandler;

public class StartCheckZoneCommandHandler : IRequestHandler<StartCheckZoneCommand, OneZoneInfo>
{
    private readonly EquipDbContext _equipContext;
    private readonly ReportDbContext _reportContext;

    public StartCheckZoneCommandHandler(EquipDbContext equipContext, ReportDbContext reportContext)
    {
        _equipContext = equipContext;
        _reportContext = reportContext;
    }

    public async Task<OneZoneInfo> Handle(StartCheckZoneCommand command, CancellationToken cancellationToken)
    {
        var plane = await _equipContext.Planes.FirstOrDefaultAsync(p => p.Id == command.IdPlane,
            cancellationToken: cancellationToken);
        var report = await _reportContext.Reports.FirstOrDefaultAsync(r => r.Id == command.IdReport, cancellationToken);
        var spaces = plane.Zones.FirstOrDefault(z => z.Name == command.NameZone).Spaces;
        var equipResults = new List<ReportEquipResult>();
        if (report != null)
            equipResults = spaces.Select(space => new ReportEquipResult
            {
                Space = space,
                Status = report.EquipReports
                    .FirstOrDefault(r => r.Space == space).Status.ToString()
            }).ToList();
        return new OneZoneInfo
        {
            Name = command.NameZone,
            Spaces = spaces,
            EquipResults = equipResults
        };
    }
}