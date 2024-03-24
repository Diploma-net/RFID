namespace RFLOT.Domain.Zone;

public class Zone
{
    public Zone(Guid id, string planeId, string name)
    {
        Id = id;
        PlaneId = planeId;
        Name = name;
    }
    public Guid Id { get; private set; }
    public string PlaneId { get; private set; }
    public string Name { get; private set; }
}