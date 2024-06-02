using RFLOT.Common.Domain;

namespace RFLOT.Domain.Report.ValueObjects;

public class Checker
{
    public Checker(Guid idUser, DateTimeOffset? dateTimeStart)
    {
        IdUser = idUser;
        DateTimeStart = dateTimeStart;
    }

    public Guid IdUser { get; set; }
    public DateTimeOffset? DateTimeStart { get; set; }
    public DateTimeOffset? DateTimeFinish { get; set; }
   
}