namespace RFLOT.Domain.Report.ValueObjects;

public class EquipBadReport : ValueObject
{
    public EquipBadReport(string rfId, Status status)
    {
        RfId = rfId;
        Status = status;
    }

    public string RfId { get; private set; }
    public Status Status { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return RfId;
        yield return Status;
    }
}