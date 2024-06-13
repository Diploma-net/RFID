using MediatR;
using RFLOT.BackgroundTasks.Jobs;
using RFLOT.Infrastructure.Report;

namespace RFLOT.BackgroundTasks.JobHandler;

public class StopAllReportJobHandler : IRequestHandler<StopAllReportsJob>
{
    private readonly ReportDbContext _context;

    public StopAllReportJobHandler(ReportDbContext context)
    {
        _context = context;
    }

    public async Task Handle(StopAllReportsJob notification, CancellationToken cancellationToken)
    {
        var reports = _context.Reports
            .Where(r => r.StatusReport == true && (DateTimeOffset.Now-r.DateTimeStart).Hours >= 1);
        if (reports.Any())
        {
            foreach (var r in reports)
            {
                r.StatusReport = false;
                r.DateTimeFinish = DateTimeOffset.Now;
            }
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}