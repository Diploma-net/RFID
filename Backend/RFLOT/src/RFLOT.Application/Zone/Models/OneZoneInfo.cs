using RFLOT.Application.Report.Models;

namespace RFLOT.Application.Zone.Models;

public class OneZoneInfo
{
    public List<string> Spaces { get; set; }
    public string Name { get; set; }
    public List<ReportEquipResult> EquipResults { get; set; }
    // подключение
}