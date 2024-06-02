using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Zone.Command;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Zone.CommandHandler;

public class StopCheckZoneCommandHandler : IRequestHandler<StopCheckZoneCommand>
{
    private readonly ReportDbContext _reportContext;

    public StopCheckZoneCommandHandler(ReportDbContext reportContext)
    {
        _reportContext = reportContext;
    }

    public async Task Handle(StopCheckZoneCommand command, CancellationToken cancellationToken)
    {
        var report =
            await _reportContext.Reports.FirstOrDefaultAsync(r => r.Id == command.IdReport,
                cancellationToken: cancellationToken);
        report.StopZoneReport(command.IdZone, command.IdUser);
        _reportContext.Reports.Update(report);
        await _reportContext.SaveChangesAsync(cancellationToken);
    }
}