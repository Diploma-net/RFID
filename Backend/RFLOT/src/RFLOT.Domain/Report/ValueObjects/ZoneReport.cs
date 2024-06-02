using RFLOT.Common.Domain;
using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Domain.Report.ValueObjects;

public class ZoneReport : ValueObject
{
    public ZoneReport(Guid idZone)
    {
        IdZone = idZone;
    }

    public Guid IdZone { get; set; }
    public List<EquipReport> EquipReports = new();
    public List<Checker> Checkers = new();
    

    public void AddChecker(Guid idUser)
    {
        Checkers.Add(new Checker(idUser, DateTimeOffset.Now));
    }
    public void DeleteChecker(Guid idUser)
    {
        var checker = Checkers.FirstOrDefault(c => c.IdUser == idUser);
        checker.DateTimeFinish = DateTimeOffset.UtcNow;
    }

    public void AddCheckedEquip(string idEquip, Status status, string space, Guid idUser)
    {
        EquipReports.Add(new EquipReport(idEquip, status, space, DateTimeOffset.Now, idUser));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IdZone;
        yield return EquipReports;
        yield return Checkers;
    }
}