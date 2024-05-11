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

    public Guid IdPlane { get; }
    public string Name { get; }

    public Guid Id { get; }
}