using RFLOT.Common.Domain;

namespace RFLOT.Domain.Zone;

public class Zone : Entity<Guid>
{
    public Zone(Guid id, string idPlane, string name)
    {
        Id = id;
        IdPlane = idPlane;
        Name = name;
    }

    public string IdPlane { get; private set; }
    public string Name { get; private set;}

    public Guid Id { get; private set;}
}