using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Models;
using RFLOT.Application.Queries;
using RFLOT.Domain.Plane.ValueObjects;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Application.QueryHandlers;

public class GetZonesByIdPlaneQueryHandler : IRequestHandler<GetZonesByIdPlaneQuery, List<ZonesInfo>>
{
    private readonly RfidContext _context;
    private readonly IMapper _mapper;

    public GetZonesByIdPlaneQueryHandler(RfidContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ZonesInfo>> Handle(GetZonesByIdPlaneQuery query, CancellationToken cancellationToken)
    {
        var plane = await _context.Planes.FirstOrDefaultAsync(p => p.Id == query.IdPlane, cancellationToken: cancellationToken);
        return plane.Zones.Select(zone => new ZonesInfo { Name = zone.Name, FullNameChecker = zone.FullNameCheckers }).ToList();
    }
}