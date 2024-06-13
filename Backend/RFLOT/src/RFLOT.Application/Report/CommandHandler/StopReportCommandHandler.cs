using MediatR;
using RFLOT.Application.Report.Command;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Report.CommandHandler;

public class StopReportCommandHandler : IRequestHandler<StopReportCommand>
{
    private readonly ReportDbContext _reportDbContext;

    public StopReportCommandHandler(ReportDbContext reportDbContext)
    {
        _reportDbContext = reportDbContext;
    }

    public async Task Handle(StopReportCommand command, CancellationToken cancellationToken)
    {
        var report = _reportDbContext.Reports
            .FirstOrDefault(r => r.Id == command.IdReport);
        report.StatusReport = false;
        await _reportDbContext.SaveChangesAsync(cancellationToken);
    }
}