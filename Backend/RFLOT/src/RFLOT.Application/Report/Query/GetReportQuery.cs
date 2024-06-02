using MediatR;
using RFLOT.Application.Report.Models;

namespace RFLOT.Application.Report.Query;

public class GetReportQuery : IRequest<ReportModel>
{
    public GetReportQuery(Guid idReport)
    {
        IdReport = idReport;
    }

    public Guid IdReport { get; }
}