using RFLOT.Common.Domain.Entity;

namespace RFLOT.Domain.Plane;

public class Plane : IEntity<Guid>
{
    private Plane()
    {
    }

    public Plane(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; private set; }

    public Guid Id { get; private set; }
}