using MediatR;
using RFLOT.Application.Zone.Models;

namespace RFLOT.Application.Zone.Query;

public class GetZonesByIdPlaneQuery : IRequest<List<ZonesInfo>>
{
    public GetZonesByIdPlaneQuery(Guid idPlane)
    {
        IdPlane = idPlane;
    }

    public Guid IdPlane { get; }
}