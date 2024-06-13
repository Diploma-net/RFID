using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Report.Models;
using RFLOT.Application.Report.Query;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Report.QueryHandler;

public class GetReportPlaneQueryHandler : IRequestHandler<GetReportPlaneQuery, ReportPlaneResult>
{
    private readonly ReportDbContext _reportContext;

    public GetReportPlaneQueryHandler(ReportDbContext reportContext)
    {
        _reportContext = reportContext;
    }

    public async Task<ReportPlaneResult> Handle(GetReportPlaneQuery query, CancellationToken cancellationToken)
    {
        var report =
            await _reportContext.Reports
                .FirstOrDefaultAsync(r => r.Id == query.IdReport,
                cancellationToken);
        return new ReportPlaneResult();
    }
}