using RFLOT.Common.Domain.Entity;
using RFLOT.Domain.Plane.ValueObjects;

namespace RFLOT.Domain.Plane;

public class Plane : IEntity
{
    public Plane(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; }
    public string Name { get; }
    private List<Zone> _zones = new();
    public IEnumerable<Zone> Zones
    {
        get => _zones?.ToList();
        internal set => _zones = value?.ToList();
    }
}