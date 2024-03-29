using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Queries;
using RFLOT.Infrastructure.Contexts;

namespace RFLOT.Application.QueryHandlers;

public class GetZonesByIdPlaneQueryHandler : IRequestHandler<GetZonesByIdPlaneQuery, List<string>>
{
    private readonly RfidContext _context;

    public GetZonesByIdPlaneQueryHandler(RfidContext context)
    {
        _context = context;
    }

    public async Task<List<string>> Handle(GetZonesByIdPlaneQuery query, CancellationToken cancellationToken)
    {
        return await _context.Zones.Where(z => z.PlaneId == query.IdPlane).Select(z => z.Name).ToListAsync(cancellationToken: cancellationToken);
    }
}