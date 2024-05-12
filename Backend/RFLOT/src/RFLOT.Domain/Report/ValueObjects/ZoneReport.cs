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
    private List<EquipReport> _equipReports = new();
    private List<Checker> _checkers = new();

    public IEnumerable<EquipReport> EquipReports
    {
        get => _equipReports?.ToList();
        internal set => _equipReports = value?.ToList();
    }

    public IEnumerable<Checker> Checkers
    {
        get => _checkers?.ToList();
        internal set => _checkers = value?.ToList();
    }

    public void AddChecker(Guid idUser)
    {
        _checkers.Add(new Checker(idUser, DateTimeOffset.Now));
    }

    public void AddCheckedEquip(Guid idEquip, Status status, string space, Guid idUser)
    {
        _equipReports.Add(new EquipReport(idEquip, status, space, DateTimeOffset.Now, idUser));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IdZone;
        yield return EquipReports;
        yield return Checkers;
    }
}