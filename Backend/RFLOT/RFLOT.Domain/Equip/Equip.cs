namespace RFLOT.Domain.Equip;

public class Equip
{
    public Equip(string rfId, Guid zoneId, string planePlace, string name, Type type, DateTimeOffset dateTimeStart, DateTimeOffset dateTimeEnd, Status lastStatus = Status.Arсhive)
    {
        RfId = rfId;
        ZoneId = zoneId;
        PlanePlace = planePlace;
        Name = name;
        Type = type;
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
        LastStatus = lastStatus;
    }
    public string RfId { get; private set; }
    public Guid ZoneId { get; private set; }
    public string PlanePlace { get; private set; }
    public string Name { get;private set; }
    public Type Type { get;private set; }
    public DateTimeOffset DateTimeStart { get;private set; }
    public DateTimeOffset DateTimeEnd { get; private set; }
    public Status LastStatus { get; set; }
    
    
}

