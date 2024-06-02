using RFLOT.Common.Domain;
namespace RFLOT.Domain.Plane;

public class Plane : Entity<string>
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

}