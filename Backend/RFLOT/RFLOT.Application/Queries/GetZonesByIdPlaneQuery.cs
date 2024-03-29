using MediatR;

namespace RFLOT.Application.Queries;

public class GetZonesByIdPlaneQuery : IRequest<List<string>>
{
    public GetZonesByIdPlaneQuery(string idPlane)
    {
        IdPlane = idPlane;
    }

    public string IdPlane { get;  }
}