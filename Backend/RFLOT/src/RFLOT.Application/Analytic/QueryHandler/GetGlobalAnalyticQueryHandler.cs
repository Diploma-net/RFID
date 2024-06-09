using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Analytic.Model;
using RFLOT.Application.Analytic.Query;
using RFLOT.Domain.Equip.ValueObjects;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Plane;
using RFLOT.Infrastructure.Report;
using Type = RFLOT.Domain.Equip.ValueObjects.Type;

namespace RFLOT.Application.Analytic.QueryHandler;

public class GetGlobalAnalyticQueryHandler : IRequestHandler<GetGlobalAnalyticQuery, GlobalAnalyticModel>
{
    private readonly EquipDbContext _equipDbContext;
    private readonly PlaneDbContext _planeDbContext;
    private readonly ReportDbContext _reportDbContext;

    public GetGlobalAnalyticQueryHandler(EquipDbContext equipDbContext, PlaneDbContext planeDbContext,
        ReportDbContext reportDbContext)
    {
        _equipDbContext = equipDbContext;
        _planeDbContext = planeDbContext;
        _reportDbContext = reportDbContext;
    }

    public async Task<GlobalAnalyticModel> Handle(GetGlobalAnalyticQuery query, CancellationToken cancellationToken)
    {
        var avarageTime = new List<TimeSpan>();
        foreach (var report in _reportDbContext.Reports)
        {
            if (report.DateTimeFinish == null) continue;
            var time = report.DateTimeFinish.Value.DateTime - report.DateTimeStart.DateTime;
            avarageTime.Add(time);
        }

        var result = new GlobalAnalyticModel
        {
            EquipAnalytic = new EquipAnalyticModel
            {
                Count = await _equipDbContext.Equips.CountAsync(cancellationToken),
                StatusAnalytic = new EquipStatusAnalyticModel
                {
                    Ok = await _equipDbContext.Equips.CountAsync(e => e.LastStatus == Status.Ok,
                        cancellationToken: cancellationToken),
                    DateMonth = await _equipDbContext.Equips.CountAsync(e => e.LastStatus == Status.DateMonth,
                        cancellationToken: cancellationToken),
                    DateFail = await _equipDbContext.Equips.CountAsync(e => e.LastStatus == Status.DateFail,
                        cancellationToken: cancellationToken),
                    NotFound = await _equipDbContext.Equips.CountAsync(e => e.LastStatus == Status.NotFound,
                        cancellationToken: cancellationToken),
                    Arсhive = await _equipDbContext.Equips.CountAsync(e => e.LastStatus == Status.Arсhive,
                        cancellationToken: cancellationToken),
                    None = await _equipDbContext.Equips.CountAsync(e => e.LastStatus == Status.None,
                        cancellationToken: cancellationToken)
                },
                TypeAnalytic = new EquipTypeAnalyticModel
                {
                    FireExtinguisher = await _equipDbContext.Equips.CountAsync(e => e.Type == Type.FireExtinguisher,
                        cancellationToken: cancellationToken),
                    OxygenMask = await _equipDbContext.Equips.CountAsync(e => e.Type == Type.OxygenMask,
                        cancellationToken: cancellationToken),
                    InformationCard = await _equipDbContext.Equips.CountAsync(e => e.Type == Type.InformationCard,
                        cancellationToken: cancellationToken)
                },
                EquipTypeLost = new EquipTypeLostModel
                {
                    FireExtinguisherLost = await _equipDbContext.Equips.CountAsync(
                        e => e.LastStatus == Status.NotFound && e.Type == Type.FireExtinguisher,
                        cancellationToken: cancellationToken),
                    InformationCardLost = await _equipDbContext.Equips.CountAsync(
                        e => e.LastStatus == Status.NotFound && e.Type == Type.InformationCard,
                        cancellationToken: cancellationToken),
                    OxygenMaskLost = await _equipDbContext.Equips.CountAsync(
                        e => e.LastStatus == Status.NotFound && e.Type == Type.OxygenMask,
                        cancellationToken: cancellationToken)
                }
            },
            PlaneAnalytic = new PlaneAnalyticModel
            {
                Count = await _planeDbContext.Planes.CountAsync(cancellationToken)
            },
            ReportAnalytic = new ReportAnalyticModel
            {
                Count = await _reportDbContext.Reports.CountAsync(cancellationToken),
                AverageTimeReport = new TimeSpan(Convert.ToInt64(avarageTime.Average(timeSpan => timeSpan.Ticks)))
            }
        };
        return result;
    }
}