using RFLOT.Common.Domain;
using RFLOT.Domain.Equip.ValueObjects;
using RFLOT.Domain.Report.Events;
using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Domain.Report;

public class Report : AggregateRoot<Guid>
{
    private Report()
    {
    }

    public Report(string idPlane, ReportType type)
    {
        Id = Guid.NewGuid();
        IdPlane = idPlane;
        Type = type;
        DateTimeStart = DateTimeOffset.UtcNow;
        StatusReport = true;
        AddDomainEvent(new NewReport(Id));
    }

    public Report(Guid id, string idPlane, ReportType type, DateTimeOffset dateTimeStart,
        DateTimeOffset? dateTimeFinish, bool statusReport, List<ZoneReport> zoneReports)
    {
        Id = id;
        IdPlane = idPlane;
        Type = type;
        DateTimeStart = dateTimeStart;
        DateTimeFinish = dateTimeFinish;
        StatusReport = statusReport;
        _zoneReports = zoneReports;
    }

    public string IdPlane { get; private set; }
    public ReportType Type { get; private set; }
    public DateTimeOffset DateTimeStart { get; private set; }
    public DateTimeOffset? DateTimeFinish { get; set; }

    ///<summary>
    /// true - это мониторинг
    /// false - это отчёт
    /// </summary>
    public bool StatusReport { get; set; }

    private List<ZoneReport> _zoneReports = new();

    public IEnumerable<ZoneReport> ZoneReports
    {
        get => _zoneReports?.ToList();
        internal set => _zoneReports = value?.ToList();
    }

    public void StartZoneReport(Guid idZone, Guid idUser)
    {
        if (_zoneReports.FirstOrDefault(z => z.IdZone == idZone) == null)
        {
            var newZoneReport = new ZoneReport(idZone);
            newZoneReport.AddChecker(idUser);
            _zoneReports.Add(newZoneReport);
        }
        else
        {
            var zoneReport = _zoneReports.FirstOrDefault(z => z.IdZone == idZone);
            zoneReport.AddChecker(idUser);
        }
    }

    public void StopZoneReport(Guid idZone, Guid idUser)
    {
        var zoneReport = _zoneReports.FirstOrDefault(z => z.IdZone == idZone);
        zoneReport.DeleteChecker(idUser);
    }

    public void AddCheckedEquip(Guid idZone, string idEquip, Status status, string space, Guid idUser)
    {
        var zoneReport = _zoneReports.FirstOrDefault(z => z.IdZone == idZone);
        zoneReport.AddCheckedEquip(idEquip, status, space, idUser);
        AddDomainEvent(new NewEquipCheckedInReport(Id, idZone, space, status));
    }
}