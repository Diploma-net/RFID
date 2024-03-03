namespace RFLOT.Domain.Zone;

public class Zone : Entity<Guid>
{
    public Zone(Guid id, string planeId, string name) : base(id)
    {
        PlaneId = planeId;
        Name = name;
        _zones = new List<Zone>();
    }
    
    private readonly List<Zone> _zones;
    public IReadOnlyCollection<Zone> Zones => _zones;
    
    public string PlaneId { get; private set; }
    public string Name { get; private set; }
}