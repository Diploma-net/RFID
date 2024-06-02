using MediatR;

namespace RFLOT.Domain.Report.Events;

public class NewReport : INotification
{
    public NewReport(Guid idReport)
    {
        IdReport = idReport;
    }
    public Guid IdReport { get; }
}