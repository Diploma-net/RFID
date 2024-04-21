using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Commands;
using RFLOT.Application.Models;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.CommandHandlers;

public class StartCheckZoneCommandHandler : IRequestHandler<StartCheckZoneCommand, OneZoneInfo>
{
    private readonly RfidDbContext _rfidContext;
    private readonly ReportDbContext _reportContext;

    public StartCheckZoneCommandHandler(RfidDbContext rfidContext, ReportDbContext reportContext)
    {
        _rfidContext = rfidContext;
        _reportContext = reportContext;
    }

    public async Task<OneZoneInfo> Handle(StartCheckZoneCommand command, CancellationToken cancellationToken)
    {
        var plane = await _rfidContext.Planes.FirstOrDefaultAsync(p => p.Id == command.IdPlane,
            cancellationToken: cancellationToken);
        var report = await _reportContext.Reports.FirstOrDefaultAsync(r => r.Id == command.IdReport, cancellationToken: cancellationToken);
        var spaces = plane.Zones.FirstOrDefault(z => z.Name == command.NameZone).Spaces;
        var equipResults = new List<ReportEquipResult>();
        if (report != null)
        {
            equipResults = spaces.Select(space => new ReportEquipResult
            {
                Space = space,
                Status = report.EquipReports
                    .FirstOrDefault(r => r.Space == space).Status.ToString()
            }).ToList();
        }
        return new OneZoneInfo
        {
            Name = command.NameZone,
            Spaces = spaces,
            EquipResults = equipResults
        };
    }
}