using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Application.Report.Models;

public class EquipReportModel
{
    public string NameEquip { get; set; }
    public Status Status { get; set; }
    public string Space { get; set; }
    public DateTimeOffset DateTimeCheck { get; set; }
    public string FullNameUser { get; set; }
}