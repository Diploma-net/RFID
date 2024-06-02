using RFLOT.Common.Domain;
using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Domain.Report.ValueObjects;

public class EquipReport
{
    public EquipReport(string idEquip, Status status, string space, DateTimeOffset dateTimeCheck, Guid idUser)
    {
        IdEquip = idEquip;
        Status = status;
        Space = space;
        DateTimeCheck = dateTimeCheck;
        IdUser = idUser;
    }

    public string IdEquip { get; set; }
    public Status Status { get; set; }
    public string Space { get; set; }
    public DateTimeOffset DateTimeCheck { get; set; }
    public Guid IdUser { get; set; }
    
}