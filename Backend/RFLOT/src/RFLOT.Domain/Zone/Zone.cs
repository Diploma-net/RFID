using RFLOT.Common.Domain.Entity;

namespace RFLOT.Domain.Zone;

public class Zone : IEntity<Guid>
{
    public Zone(Guid id, Guid idPlane, string name)
    {
        Id = id;
        IdPlane = idPlane;
        Name = name;
    }

    public Guid IdPlane { get; private set; }
    public string Name { get; private set;}

    public Guid Id { get; private set;}
}