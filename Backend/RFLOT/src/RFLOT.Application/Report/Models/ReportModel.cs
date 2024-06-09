using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Application.Report.Models;

public class ReportModel
{
    public Guid IdReport { get; set; }
    public string NamePlane { get; set; }
    public ReportType Type { get; set; }
    public DateTimeOffset DateTimeStart { get; set; }
    public DateTimeOffset? DateTimeFinish { get; set;}
    public List<ZoneModel> ZonesInfo { get; set; }
}