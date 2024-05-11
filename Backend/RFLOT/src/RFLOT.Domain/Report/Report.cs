using RFLOT.Common.Domain;
using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Domain.Report;

public class Report : IAggregateRoot<Guid>
{
    private List<EquipReport> _equipReports = new();
    public List<string> FullNameCheckers = new();

    private Report()
    {
    }

    public Report(string idPlane, ReportType type)
    {
        Id = Guid.NewGuid();
        IdPlane = idPlane;
        Type = type;
        DateTimeStart = DateTimeOffset.Now;
        StatusReport = true;
    }

    public string IdPlane { get; private set; }
    public ReportType Type { get; }
    public DateTimeOffset DateTimeStart { get; private set; }
    public DateTimeOffset? DateTimeFinish { get; }
    public bool StatusReport { get; set; }

    public IEnumerable<EquipReport> EquipReports
    {
        get => _equipReports?.ToList();
        internal set => _equipReports = value?.ToList();
    }

    public Guid Id { get; }

    public string GetReportTypeString()
    {
        return Type switch
        {
            ReportType.Post => "Post",
            ReportType.Pre => "Pre",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}