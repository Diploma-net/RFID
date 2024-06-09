namespace RFLOT.Application.Analytic.Model;

public class EquipAnalyticModel
{
    public int Count { get; set; }
    public EquipStatusAnalyticModel StatusAnalytic { get; set; }
    public EquipTypeAnalyticModel TypeAnalytic { get; set; }
    public EquipTypeLostModel EquipTypeLost { get; set; }
}