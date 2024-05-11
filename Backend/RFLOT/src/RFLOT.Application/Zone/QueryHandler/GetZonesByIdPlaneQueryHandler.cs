using AutoMapper;
using MediatR;
using RFLOT.Application.Zone.Models;
using RFLOT.Application.Zone.Query;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Application.Zone.QueryHandler;

public class GetZonesByIdPlaneQueryHandler : IRequestHandler<GetZonesByIdPlaneQuery, List<ZonesInfo>>
{
    private readonly EquipDbContext _equipDbContext;
    private readonly IMapper _mapper;

    public GetZonesByIdPlaneQueryHandler(EquipDbContext dbContext, IMapper mapper)
    {
        _equipDbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ZonesInfo>> Handle(GetZonesByIdPlaneQuery query, CancellationToken cancellationToken)
    {
        var plane = await _equipDbContext.Planes.FirstOrDefaultAsync(p => p.Id == query.IdPlane,
            cancellationToken: cancellationToken);
        return plane.Zones.Select(zone => new ZonesInfo { Name = zone.Name, FullNameChecker = zone.FullNameCheckers })
            .ToList();
    }
}