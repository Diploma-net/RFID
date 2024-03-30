using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Models;
using RFLOT.Application.Queries;
using RFLOT.Domain.Plane.ValueObjects;
using RFLOT.Domain.Report;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Report;

namespace RFLOT.Application.QueryHandlers;

public class GetZonesByIdPlaneQueryHandler : IRequestHandler<GetZonesByIdPlaneQuery, List<ZonesInfo>>
{
    private readonly RfidDbContext _rfidDbContext;
    private readonly IMapper _mapper;

    public GetZonesByIdPlaneQueryHandler(RfidDbContext dbContext, IMapper mapper)
    {
        _rfidDbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ZonesInfo>> Handle(GetZonesByIdPlaneQuery query, CancellationToken cancellationToken)
    {
        var plane = await _rfidDbContext.Planes.FirstOrDefaultAsync(p => p.Id == query.IdPlane, cancellationToken: cancellationToken);
        return plane.Zones.Select(zone => new ZonesInfo { Name = zone.Name, FullNameChecker = zone.FullNameCheckers }).ToList();
    }
}