using RFLOT.Common.Domain.Entity;

namespace RFLOT.Domain.Plane;

public class Plane : IEntity<string>
{
    private Plane()
    {
    }

    public Plane(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; private set; }

    public string Id { get; }
}