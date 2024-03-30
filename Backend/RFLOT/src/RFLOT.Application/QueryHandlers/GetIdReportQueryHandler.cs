using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Queries;
using RFLOT.Domain.Report;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.QueryHandlers;

public class GetIdReportQueryHandler : IRequestHandler<GetIdReportQuery, string>
{
    private readonly ReportDbContext _reportDbContext;

    public GetIdReportQueryHandler(ReportDbContext reportDbContext)
    {
        _reportDbContext = reportDbContext;
    }

    public async Task<string> Handle(GetIdReportQuery query, CancellationToken cancellationToken)
    {
        var report = await _reportDbContext.Reports.FirstOrDefaultAsync(r =>
            r.StatusReport == true && r.Type == GetReportTypeByString(query.TypeCheck), cancellationToken: cancellationToken);
        if (report != null) return report.Id;
        var newReport = new Report(query.IdPlane, GetReportTypeByString(query.TypeCheck));
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