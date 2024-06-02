using MediatR;
using RFLOT.Application.Report.Models;
using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Application.Report.Query;

public class GetReportsQuery : IRequest<List<GetReports>>
{
    public GetReportsQuery(bool reportResult, string? planeName, DateOnly? reportDate, ReportType? reportType)
    {
        ReportResult = reportResult;
        PlaneName = planeName;
        ReportDate = reportDate;
        ReportType = reportType;
    }

    public bool ReportResult { get; }
    public string? PlaneName { get;  }
    public DateOnly? ReportDate { get;  }
    public ReportType? ReportType { get; }
}