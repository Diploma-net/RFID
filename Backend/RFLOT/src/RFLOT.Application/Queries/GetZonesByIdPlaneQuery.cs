using MediatR;
using RFLOT.Application.Models;

namespace RFLOT.Application.Queries;

public class GetZonesByIdPlaneQuery : IRequest<List<ZonesInfo>>
{
    public GetZonesByIdPlaneQuery(string idPlane)
    {
        IdPlane = idPlane;
    }

    public string IdPlane { get;  }
}