using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Domain.Report;

public class ZoneReport
{
    public ZoneReport(Guid id, Guid zoneId, string planeId, Guid peopleId, DateTimeOffset dateTimeStart, DateTimeOffset dateTimeEnd, List<EquipBadReport> badEquips)
    {
        Id = id;
        ZoneId = zoneId;
        PlaneId = planeId;
        PeopleId = peopleId;
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
        BadEquips = badEquips;
    }

    public Guid Id { get; private set; }
    public Guid ZoneId { get; private set; }
    public string PlaneId { get; private set; }
    public Guid PeopleId { get; private set; }
    public DateTimeOffset DateTimeStart { get; private set; }
    public DateTimeOffset DateTimeEnd { get; private set; }
    public List<EquipBadReport> BadEquips { get; private set; }
}