using RFLOT.Common.Domain.Entity;
using RFLOT.Domain.Plane.ValueObjects;

namespace RFLOT.Domain.Plane;

public class Plane : IEntity
{
    private Plane() {}
    public Plane(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; private set; }
    public string Name { get; private set; }
    private List<Zone> _zones = new();
    public IEnumerable<Zone> Zones
    {
        get => _zones?.ToList();
        internal set => _zones = value?.ToList();
    }
}