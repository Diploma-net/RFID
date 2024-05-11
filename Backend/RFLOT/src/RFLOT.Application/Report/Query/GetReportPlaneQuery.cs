using MediatR;
using RFLOT.Application.Report.Models;

namespace RFLOT.Application.Report.Query;

public class GetReportPlaneQuery : IRequest<ReportPlaneResult>
{
    public GetReportPlaneQuery(Guid idReport)
    {
        IdReport = idReport;
    }

    public Guid IdReport { get; }
}