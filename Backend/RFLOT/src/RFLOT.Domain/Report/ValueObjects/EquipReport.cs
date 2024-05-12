using RFLOT.Common.Domain;
using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Domain.Report.ValueObjects;

public class EquipReport : ValueObject
{
    private EquipReport()
    {
        
    }
    public EquipReport(Guid idEquip, Status status, string space, DateTimeOffset dateTimeCheck, Guid idUser)
    {
        IdEquip = idEquip;
        Status = status;
        Space = space;
        DateTimeCheck = dateTimeCheck;
        IdUser = idUser;
    }

    public Guid IdEquip { get; }
    public Status Status { get; }
    public string Space { get; }
    public DateTimeOffset DateTimeCheck { get; }
    public Guid IdUser { get;  }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IdEquip;
        yield return Status;
        yield return Space;
    }
}