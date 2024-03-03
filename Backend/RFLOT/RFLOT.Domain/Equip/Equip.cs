namespace RFLOT.Domain;

public class Equip : Entity<string>
{
    public Equip(string rfId, Guid zoneId, string planePlace, string name, Type type, DateTimeOffset dateTimeStart, DateTimeOffset dateTimeEnd, Status lastStatus) : base(rfId)
    {
        _equips = new List<Equip>();
        ZoneId = zoneId;
        PlanePlace = planePlace;
        Name = name;
        Type = type;
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
        LastStatus = lastStatus;
        
    }
    private readonly List<Equip> _equips;
    public IReadOnlyCollection<Equip> Equips => _equips;
    public Guid ZoneId { get; private set; }
    public string PlanePlace { get; private set; }
    public string Name { get;private set; }
    public Type Type { get;private set; }
    public DateTimeOffset DateTimeStart { get;private set; }
    public DateTimeOffset DateTimeEnd { get; private set; }
    public Status LastStatus { get; private set; }

    public void AddNewEquip(Equip equip)
    {
        _equips.Add(equip);
    }
}

