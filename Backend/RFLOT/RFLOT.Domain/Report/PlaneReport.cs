namespace RFLOT.Domain.Report;

public class PlaneReport
{
    public Guid Id { get; set; }
    public string PlaneId { get; set; }
    public DateTimeOffset DateTimeStart { get; set; }
    public DateTimeOffset? DateTimeEnd { get; set; }
    public List<ZoneReport> ZoneReports { get; set; }
}