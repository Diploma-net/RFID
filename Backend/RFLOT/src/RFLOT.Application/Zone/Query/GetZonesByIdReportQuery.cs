using MediatR;
using RFLOT.Application.Zone.Models;

namespace RFLOT.Application.Zone.Query;

public class GetZonesByIdReportQuery : IRequest<List<ZonesInfo>>
{
    public GetZonesByIdReportQuery(Guid idReport)
    {
        IdReport = idReport;
    }

    public Guid IdReport { get; }
}