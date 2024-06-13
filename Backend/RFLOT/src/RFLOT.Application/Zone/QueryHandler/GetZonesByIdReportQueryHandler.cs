using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Zone.Models;
using RFLOT.Application.Zone.Query;
using RFLOT.Identity;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Plane;
using RFLOT.Infrastructure.Report;
using RFLOT.Infrastructure.Zone;

namespace RFLOT.Application.Zone.QueryHandler;

public class GetZonesByIdReportQueryHandler : IRequestHandler<GetZonesByIdReportQuery, List<ZonesInfo>>
{
    private readonly ReportDbContext _reportDbContext;
    private readonly PlaneDbContext _planeDbContext;
    private readonly ZoneDbContext _zoneDbContext;
    private readonly IGetUser _getUser;
    private readonly EquipDbContext _equipDbContext;


    public GetZonesByIdReportQueryHandler(ReportDbContext reportDbContext, PlaneDbContext planeDbContext, ZoneDbContext zoneDbContext, IGetUser getUser, EquipDbContext equipDbContext)
    {
        _reportDbContext = reportDbContext;
        _planeDbContext = planeDbContext;
        _zoneDbContext = zoneDbContext;
        _getUser = getUser;
        _equipDbContext = equipDbContext;
    }

    public async Task<List<ZonesInfo>> Handle(GetZonesByIdReportQuery query, CancellationToken cancellationToken)
    {
        var result = new List<ZonesInfo>();
        var report =
            await _reportDbContext.Reports
                .FirstOrDefaultAsync(r => r.Id == query.IdReport,
                cancellationToken: cancellationToken);
        if (report == null)
        {
            throw new ApplicationException("Ошибка входа в состояние проверки.");
        }

        var plane = await _planeDbContext.Planes
            .FirstOrDefaultAsync(p => p.Id == report.IdPlane,
            cancellationToken: cancellationToken);

        var zones = _zoneDbContext.Zones
            .Where(z => z.IdPlane == plane.Id);

        foreach (var zone in zones)
        {
            if (report.ZoneReports
                    .FirstOrDefault(z => z.IdZone == zone.Id) != null)
            {
                var thisZone = report.ZoneReports
                    .FirstOrDefault(z => z.IdZone == zone.Id);
                result.Add(new ZonesInfo
                {
                    IdZone = zone.Id,
                    Name = zone.Name,
                    FullNameChecker = await _getUser.GetFullNameUsers(thisZone.Checkers
                        .Select(z => z.IdUser)
                        .ToList()),
                    Progress = $"{thisZone.EquipReports
                        .Count()}/{_equipDbContext.Equips
                        .Count(e => e.ZoneId == zone.Id)}"
                });
            }
            else
            {
                result.Add(new ZonesInfo
                {
                    IdZone = zone.Id,
                    Name = zone.Name,
                    FullNameChecker = null,
                    Progress = $"0/{_equipDbContext.Equips
                        .Count(e => e.ZoneId == zone.Id)}"
                });
            }
        }
        return result;
    }
}