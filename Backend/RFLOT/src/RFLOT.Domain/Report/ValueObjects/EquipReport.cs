using RFLOT.Common.Domain;
using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Domain.Report.ValueObjects;

public class EquipReport : ValueObject
{
    public EquipReport(string rfId, Status status, string space)
    {
        RfId = rfId;
        Status = status;
        Space = space;
    }

    public string RfId { get; }
    public Status Status { get; }
    public string Space { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return RfId;
        yield return Status;
        yield return Space;
    }
}