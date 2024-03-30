using RFLOT.Common.Domain;
using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Domain.Report;

public class Report : IAggregateRoot
{
    private Report () {}
    public Report(string idPlane, ReportType type)
    {
        Id = Guid.NewGuid().ToString();
        IdPlane = idPlane;
        Type = type;
        DateTimeStart = DateTimeOffset.Now;
        StatusReport = true;
    }

    public string Id { get; private set; }
    public string IdPlane {get; private set; }
    public ReportType Type { get; private set; }
    
    public string GetReportTypeString()
    {
        return Type switch
        {
            ReportType.Post => "Post",
            ReportType.Pre => "Pre",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    public DateTimeOffset DateTimeStart { get; private set; }
    public DateTimeOffset? DateTimeFinish { get; private set; }
    public bool StatusReport { get; set; }
    private List<EquipReport> _equipReports = new();
    public IEnumerable<EquipReport> EquipReports
    {
        get => _equipReports?.ToList();
        internal set => _equipReports = value?.ToList();
    }
    public List<string> FullNameCheckers = new List<string>();
}