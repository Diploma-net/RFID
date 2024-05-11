using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Report.Query;
using RFLOT.Domain.Report.ValueObjects;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Report.QueryHandler;

public class GetIdReportQueryHandler : IRequestHandler<GetIdReportQuery, Guid>
{
    private readonly ReportDbContext _reportDbContext;

    public GetIdReportQueryHandler(ReportDbContext reportDbContext)
    {
        _reportDbContext = reportDbContext;
    }

    public async Task<Guid> Handle(GetIdReportQuery query, CancellationToken cancellationToken)
    {
        var report = await _reportDbContext.Reports.FirstOrDefaultAsync(r =>
            r.StatusReport == true && r.Type == GetReportTypeByString(query.TypeCheck), cancellationToken);
        if (report != null) return report.Id;
        var newReport = new Domain.Report.Report(query.IdPlane, GetReportTypeByString(query.TypeCheck));
        await _reportDbContext.Reports.AddAsync(newReport, cancellationToken);
        await _reportDbContext.SaveChangesAsync(cancellationToken);
        return newReport.Id;
    }

    private ReportType GetReportTypeByString(string type)
    {
        return type switch
        {
            "Pre" => ReportType.Pre,
            "Post" => ReportType.Post,
            _ => throw new ApplicationException("Тип проверки не найден.")
        };
    }
}