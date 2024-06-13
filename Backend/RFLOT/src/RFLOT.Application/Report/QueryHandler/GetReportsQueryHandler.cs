using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Report.Models;
using RFLOT.Application.Report.Query;
using RFLOT.Infrastructure.Plane;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.Report.QueryHandler;

public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, List<GetReports>>
{
    private readonly ReportDbContext _reportDbContext;
    private readonly PlaneDbContext _planeDbContext;

    public GetReportsQueryHandler(ReportDbContext reportDbContext, PlaneDbContext planeDbContext)
    {
        _reportDbContext = reportDbContext;
        _planeDbContext = planeDbContext;
    }

    public async Task<List<GetReports>> Handle(GetReportsQuery query, CancellationToken cancellationToken)
    {
        var reports = _reportDbContext.Reports
            .Where(r => r.StatusReport == query.ReportResult);

        if (!string.IsNullOrEmpty(query.PlaneName))
        {
            var plane = await _planeDbContext.Planes
                            .FirstOrDefaultAsync(p => p.Name == query.PlaneName,
                                cancellationToken: cancellationToken)
                        ?? throw new ApplicationException("Самолёт с данным названием не найден.");
            reports = reports
                .Where(r => r.IdPlane == plane.Id);
        }

        if (query.ReportType != null)
        {
            reports = reports
                .Where(r => r.Type == query.ReportType);
        }

        if (query.ReportDate != null)
        {
            reports = reports
                .Where(r => new DateOnly(r.DateTimeStart.Year, r.DateTimeStart.Month, r.DateTimeStart.Day) ==
                            DateOnly.Parse(query.ReportDate));
        }

        var result = new List<GetReports>();
        foreach (var report in reports)
        {
            result.Add(new GetReports
            {
                IdReport = report.Id,
                ReportType = report.Type,
                DateTimeStart = report.DateTimeStart,
                DateTimeFinish = report.DateTimeFinish,
                NamePlane = _planeDbContext.Planes
                    .FirstOrDefault(p => p.Id == report.IdPlane).Name
            });
        }

        return result;
    }
}