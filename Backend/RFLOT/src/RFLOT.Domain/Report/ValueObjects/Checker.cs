using RFLOT.Common.Domain;

namespace RFLOT.Domain.Report.ValueObjects;

public class Checker : ValueObject
{
    private Checker()
    {
        
    }
    public Checker(Guid idUser, DateTimeOffset dateTimeStart)
    {
        IdUser = idUser;
        DateTimeStart = dateTimeStart;
    }

    public Guid IdUser { get; }
    public DateTimeOffset? DateTimeStart { get; }
    public DateTimeOffset? DateTimeFinish { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IdUser;
        yield return DateTimeStart;
        yield return DateTimeFinish;
    }
}