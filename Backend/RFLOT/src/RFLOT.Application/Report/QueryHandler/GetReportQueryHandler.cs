using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Report.Models;
using RFLOT.Application.Report.Query;
using RFLOT.Identity.Context;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Plane;
using RFLOT.Infrastructure.Report;
using RFLOT.Infrastructure.Zone;

namespace RFLOT.Application.Report.QueryHandler;

public class GetReportQueryHandler : IRequestHandler<GetReportQuery, ReportModel>
{
    private readonly ReportDbContext _reportDbContext;
    private readonly PlaneDbContext _planeDbContext;
    private readonly EquipDbContext _equipDbContext;
    private readonly ZoneDbContext _zoneDbContext;
    private readonly UserDbContext _userDbContext;

    public GetReportQueryHandler(ReportDbContext reportDbContext, PlaneDbContext planeDbContext,
        EquipDbContext equipDbContext, ZoneDbContext zoneDbContext, UserDbContext userDbContext)
    {
        _reportDbContext = reportDbContext;
        _planeDbContext = planeDbContext;
        _equipDbContext = equipDbContext;
        _zoneDbContext = zoneDbContext;
        _userDbContext = userDbContext;
    }

    public async Task<ReportModel> Handle(GetReportQuery query, CancellationToken cancellationToken)
    {
        var report =
            await _reportDbContext.Reports.FirstOrDefaultAsync(r => r.Id == query.IdReport,
                cancellationToken: cancellationToken) ??
            throw new ApplicationException("Проверка по данному id не найдена!");
        var zonesInfo = (from zoneReport in report.ZoneReports
            let equipInfo = zoneReport.EquipReports.Select(equipReport => new EquipReportModel
                {
                    Space = equipReport.Space,
                    Status = equipReport.Status,
                    DateTimeCheck = equipReport.DateTimeCheck,
                    NameEquip = _equipDbContext.Equips.FirstOrDefault(e => e.Id == equipReport.IdEquip).Name,
                    FullNameUser = _userDbContext.Users.FirstOrDefault(u => u.Id == equipReport.IdUser).FullName
                })
                .ToList()
            select new ZoneModel
            {
                EquipReports = equipInfo,
                NameZone = _zoneDbContext.Zones.FirstOrDefault(z => z.Id == zoneReport.IdZone).Name
            }).ToList();
        var result = new ReportModel
        {
            IdReport = report.Id,
            Type = report.Type,
            DateTimeStart = report.DateTimeStart,
            DateTimeFinish = report.DateTimeFinish,
            NamePlane = _planeDbContext.Planes.FirstOrDefault(p => p.Id == report.IdPlane).Name,
            ZonesInfo = zonesInfo
        };
        return result;
    }
}