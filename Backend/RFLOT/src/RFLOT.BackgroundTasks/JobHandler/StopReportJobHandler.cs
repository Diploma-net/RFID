using MediatR;
using RFLOT.Domain.Report.Events;
using RFLOT.Infrastructure.Report;

namespace RFLOT.BackgroundTasks.JobHandler;

public class StopReportJobHandler : INotificationHandler<NewReport>
{
    private readonly ReportDbContext _context;

    public StopReportJobHandler(ReportDbContext context)
    {
        _context = context;
    }

    public async Task Handle(NewReport job, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromHours(1), cancellationToken);
        var report = _context.Reports.FirstOrDefault(r => r.Id == job.IdReport);
        report.StatusReport = false;
        report.DateTimeFinish = DateTimeOffset.Now;
        await _context.SaveChangesAsync(cancellationToken);
    }
    
}