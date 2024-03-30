using RFLOT.Common.Domain;
using RFLOT.Domain.Equip;

namespace RFLOT.Domain.Report.ValueObjects;

public class EquipReport : ValueObject
{
    public EquipReport(string rfId, Status status, string place)
    {
        RfId = rfId;
        Status = status;
        Place = place;
    }

    public string RfId { get; private set; }
    public Status Status { get; private set; }
    public string Place { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return RfId;
        yield return Status;
        yield return Place;
    }
}