using RFLOT.Common.Domain;
using RFLOT.Domain.Equip;

namespace RFLOT.Domain.Report.ValueObjects;

public class EquipReport : ValueObject
{
    public EquipReport(string rfId, Status status, string space)
    {
        RfId = rfId;
        Status = status;
        Space = space;
    }

    public string RfId { get; private set; }
    public Status Status { get; private set; }
    public string Space { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return RfId;
        yield return Status;
        yield return Space;
    }
}