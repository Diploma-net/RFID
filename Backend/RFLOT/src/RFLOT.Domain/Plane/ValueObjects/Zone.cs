using RFLOT.Common.Domain;

namespace RFLOT.Domain.Plane.ValueObjects;

public class Zone : ValueObject
{
    public string Name { get; set; }
    public List<string> Spaces { get; set; }

    public List<string> FullNameCheckers { get; set; } = new List<string>();
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Spaces;
        yield return FullNameCheckers;
    }
}