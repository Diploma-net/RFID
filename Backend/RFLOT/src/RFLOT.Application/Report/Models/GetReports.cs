using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Application.Report.Models;

public class GetReports
{
    public Guid IdReport { get; set; }
    public string NamePlane { get; set; } 
    public DateTimeOffset DateTimeStart { get; set; }
    public DateTimeOffset? DateTimeFinish { get; set; }
    public ReportType ReportType { get; set; }
}