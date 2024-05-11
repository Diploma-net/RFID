using RFLOT.Common.Domain;

namespace RFLOT.Gateway.Monitoring.Models.ValueObjects;

public class Checker : ValueObject
{
    public Guid IdChecker { get; set; }
    public string ZoneName { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IdChecker;
        yield return ZoneName;
    }
}