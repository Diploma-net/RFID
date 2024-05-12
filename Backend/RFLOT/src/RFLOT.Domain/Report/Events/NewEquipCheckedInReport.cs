using MediatR;
using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Domain.Report.Events;

public class NewEquipCheckedInReport : INotification
{
    public NewEquipCheckedInReport(Guid idReport, Guid idZone, string space, Status status)
    {
        IdReport = idReport;
        IdZone = idZone;
        Space = space;
        Status = status;
    }

    public Guid IdReport { get; }
    public Guid IdZone { get; }
    public string Space { get; }
    public Status Status { get; }
}