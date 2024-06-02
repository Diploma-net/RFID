using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Plane.Command;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Plane.CommandHandler;

public class StartCheckPlaneCommandHandler : IRequestHandler<StartCheckPlaneCommand, Guid>
{
    private readonly ReportDbContext _reportDbContext;

    public StartCheckPlaneCommandHandler(ReportDbContext reportDbContext)
    {
        _reportDbContext = reportDbContext;
    }

    public async Task<Guid> Handle(StartCheckPlaneCommand command, CancellationToken cancellationToken)
    {
        var report = await _reportDbContext.Reports.FirstOrDefaultAsync(r =>
            r.StatusReport == true && r.Type == command.TypeCheck, cancellationToken);
        if (report != null)
        {
            await _reportDbContext.SaveChangesAsync(cancellationToken);
            return report.Id;
        }
        var newReport = new Domain.Report.Report(command.IdPlane, command.TypeCheck);
        await _reportDbContext.Reports.AddAsync(newReport, cancellationToken);
        await _reportDbContext.SaveChangesAsync(cancellationToken);
        return newReport.Id;
    }
}