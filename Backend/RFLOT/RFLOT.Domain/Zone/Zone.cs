namespace RFLOT.Domain.Zone;

public class Zone : Entity<Guid>
{
    public Zone(Guid id, string planeId, string name) : base(id)
    {
        PlaneId = planeId;
        Name = name;
    }
    
    public string PlaneId { get; private set; }
    public string Name { get; private set; }
}