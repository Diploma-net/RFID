using AutoFixture;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Domain.Equip.ValueObjects;
using RFLOT.Domain.Report.ValueObjects;
using RFLOT.Identity;
using RFLOT.Identity.Context;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Plane;
using RFLOT.Infrastructure.Report;
using RFLOT.Infrastructure.Zone;
using Type = RFLOT.Domain.Equip.ValueObjects.Type;

namespace RFLOT.Application.DataGenerate;

public class FullReportGenerateCommandHandler : IRequestHandler<FullReportGenerateCommand, List<Guid>>
{
    private readonly ReportDbContext _reportDbContext;
    private readonly PlaneDbContext _planeDbContext;
    private readonly EquipDbContext _equipDbContext;
    private readonly ZoneDbContext _zoneDbContext;
    private readonly UserDbContext _userDbContext;
    private readonly IFixture _fixture = new Fixture();

    private const int UsersInPlane = 4;
    private const int EconomyZonesInPlane = 6;
    private const int BusinessZonesInPlane = 1;
    private const int EquipsInBusiness = 16;
    private const int EquipsInEconomy = 24;

    private readonly string[] EquipsSpaceInBusiness =
    [
        "A1", "B1", "C1", "D1",
        "A2", "B2", "C2", "D2",
        "A3", "B3", "C3", "D3",
        "A4", "B4", "C4", "D4"
    ];

    private readonly string[] EquipsSpaceInEconomy =
    [
        "A5", "B5", "C5", "D5", "E5", "F5",
        "A6", "B6", "C6", "D6", "E6", "F6",
        "A7", "B7", "C7", "D7", "E7", "F7",
        "A8", "B8", "C8", "D8", "E8", "F8",
        "A9", "B9", "C9", "D9", "E9", "F9",
        "A10", "B10", "C10", "D10", "E10", "F10",
        "A11", "B11", "C11", "D11", "E11", "F11",
        "A17", "B17", "C17", "D17", "E17", "F17",
        "A18", "B18", "C18", "D18", "E18", "F18",
        "A19", "B19", "C19", "D19", "E19", "F19",
        "A20", "B20", "C20", "D20", "E20", "F20",
        "A21", "B21", "C21", "D21", "E21", "F21",
        "A22", "B22", "C22", "D22", "E22", "F22",
        "A23", "B23", "C23", "D23", "E23", "F23",
        "A24", "B24", "C24", "D24", "E24", "F24",
        "A25", "B25", "C25", "D25", "E25", "F25",
        "A26", "B26", "C26", "D26", "E26", "F26",
        "A27", "B27", "C27", "D27", "E27", "F27",
        "A28", "B28", "C28", "D28", "E28", "F28",
        "A29", "B29", "C29", "D29", "E29", "F29",
        "A30", "B30", "C30", "D30", "E30", "F30",
        "A31", "B31", "C31", "D31", "E31", "F31",
        "A32", "B32", "C32", "D32", "E32", "F32",
        "A33", "B33", "C33", "D33", "E33", "F33"
    ];

    private readonly string[] RandomPlaneNames =
    [
        "Phoenix", "Aurora", "Thunderbird", "Wingspan", "Skyhawk",
        "Silverbird", "Gravity", "Starlight", "Bluebird", "Firefly",
        "Falcon", "Stratosphere", "Moonlight", "Dreamliner", "Rainbow",
        "Soaring Eagle", "Spirit", "Sunrise", "Sundancer", "Infinity",
        "Cirrus", "Celestial", "Galaxy", "Pegasus", "Solar Flare",
        "Dragonfly", "Luminous", "Empyrean", "Aerospace", "Nimbus",
        "Jetstream", "Jupiter", "Hope", "Radiance", "Aerostar", "Velocity",
        "Altitude", "Constellation", "Eclipse", "Skylark", "Zenith",
        "Majestic", "Stardust", "Harmony", "Icarus", "Orion",
        "Aerodynamic", "Voyager", "Flightpath", "Pantheon", "Horizon",
        "Nebula", "Aether", "Avalon", "Serenity", "AeroMax",
        "Supernova", "Comet", "Astraeus", "Perseus", "Solaris",
        "Venture", "Genesis", "AeroWing", "Fury", "Ascend",
        "Quasar", "Lyra", "Auriga", "Equinox", "Apollo",
        "Cascade", "Astrojet", "Stellar", "AeroDream", "Vortex",
        "Vector", "AeroLux", "Endeavor", "Nova", "EagleEye",
        "Infinity", "Horizon", "AeroFlash", "Soar", "Polaris",
        "Infinite Flight", "Starjet", "Silverstreak", "Firefly", "Cosmic",
        "Radiance", "Nighthawk"
    ];

    private readonly string[] RandomNames =
    [
        "Александр", "Иван", "Дмитрий", "Сергей", "Андрей",
        "Михаил", "Артем", "Павел", "Евгений", "Николай",
        "Кирилл", "Олег", "Максим", "Алексей", "Владимир",
        "Антон", "Валерий", "Григорий", "Денис", "Юрий",
        "Игорь", "Станислав", "Борис", "Глеб", "Роман",
        "Гарри", "Захар", "Леонид", "Арсений", "Федор",
        "Константин", "Тимофей", "Егор", "Александр", "Илья",
        "Даниил", "Никита", "Семен", "Василий", "Евгений",
        "Александр", "Артем", "Матвей", "Вадим", "Дмитрий",
        "Сергей", "Иван", "Андрей", "Максим", "Петр",
        "Егор", "Никита", "Евгений", "Денис", "Константин",
        "Даниил", "Алексей", "Георгий", "Владислав", "Антон",
        "Артем", "Сергей", "Игорь", "Федор", "Роман",
        "Илья", "Борис", "Артур", "Степан", "Валентин",
        "Аркадий", "Василий", "Михаил", "Юрий", "Дмитрий",
        "Валерий", "Николай", "Марк", "Кирилл", "Евгений",
        "Александр", "Иван", "Артем", "Андрей", "Михаил",
        "Павел", "Олег", "Григорий", "Арсений", "Алексей",
        "Игорь", "Станислав", "Дмитрий", "Егор", "Николай",
        "Илья", "Александр", "Роман", "Алексей", "Даниил",
        "Владимир", "Сергей", "Константин", "Никита", "Денис",
        "Федор", "Кирилл"
    ];

    private readonly string[] RandomSurnames =
    [
        "Иванов", "Петров", "Смирнов", "Кузнецов", "Попов",
        "Васильев", "Соколов", "Михайлов", "Новиков", "Федоров",
        "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов",
        "Егоров", "Павлов", "Козлов", "Степанов", "Николаев",
        "Орлов", "Андреев", "Макаров", "Никитин", "Захаров",
        "Зайцев", "Соловьев", "Борисов", "Яковлев", "Григорьев",
        "Романов", "Воробьев", "Сергеев", "Куликов", "Беляев",
        "Карпов", "Исаев", "Ткачев", "Абрамов", "Родионов",
        "Баранов", "Кириллов", "Коновалов", "Жуков", "Александров",
        "Лазарев", "Медведев", "Ершов", "Данилов", "Герасимов",
        "Марков", "Прохоров", "Матвеев", "Елисеев", "Тимофеев",
        "Филиппов", "Крылов", "Максимов", "Сидоров", "Осипов",
        "Давыдов", "Анисимов", "Алексеев", "Фомин", "Панов",
        "Власов", "Тихонов", "Кузьмин", "Миронов", "Федотов",
        "Устинов", "Игнатьев", "Лысенко", "Богданов", "Краснов",
        "Цветков", "Дементьев", "Гаврилов", "Горбачев", "Ермаков",
        "Калашников", "Колесников", "Лазарев", "Трофимов", "Архипов",
        "Владимиров", "Аксенов", "Гусев", "Марков", "Юдин",
        "Кудрявцев", "Бирюков", "Гордеев", "Савельев"
    ];


    public FullReportGenerateCommandHandler(ReportDbContext reportDbContext, PlaneDbContext planeDbContext,
        EquipDbContext equipDbContext, ZoneDbContext zoneDbContext, UserDbContext userDbContext)
    {
        _reportDbContext = reportDbContext;
        _planeDbContext = planeDbContext;
        _equipDbContext = equipDbContext;
        _zoneDbContext = zoneDbContext;
        _userDbContext = userDbContext;
    }

    public async Task<List<Guid>> Handle(FullReportGenerateCommand command, CancellationToken cancellationToken)
    {
        var reports = new List<Guid>();
        for (int i = 0; i < command.CountGenerate; i++)
        {
            var users = await GenerateUsers(cancellationToken);
            await _userDbContext.SaveChangesAsync(cancellationToken);
            var plane = await GeneratePlane(cancellationToken);
            await _planeDbContext.SaveChangesAsync(cancellationToken);
            var zones = await GenerateZones(plane, cancellationToken);
            await _zoneDbContext.SaveChangesAsync(cancellationToken);
            var equips = await GenerateEquips(zones, cancellationToken);
            await _equipDbContext.SaveChangesAsync(cancellationToken);
            var report = await GenerateReport(users, plane, zones, equips, cancellationToken);
            await _reportDbContext.SaveChangesAsync(cancellationToken);
            reports.Add(report);
        }

        return reports;
    }

    private async Task<List<Guid>> GenerateUsers(CancellationToken cancellationToken)
    {
        var newUsers = new List<Guid>();
        for (int i = 0; i < UsersInPlane; i++)
        {
            var newUser = _fixture.Create<User>();
            newUser.FullName =
                $"{RandomSurnames[new Random()
                    .Next(0, RandomSurnames.Length - 1)]} {RandomNames[new Random()
                    .Next(0, RandomNames.Length - 1)]}";
            await _userDbContext.Users.
                AddAsync(newUser, cancellationToken);
            newUsers.Add(newUser.Id);
        }

        return newUsers;
    }

    private async Task<string> GeneratePlane(CancellationToken cancellationToken)
    {
        var newPlane = _fixture.Create<Domain.Plane.Plane>();
        newPlane.Name =
            $"{RandomPlaneNames[new Random()
                .Next(0, RandomPlaneNames.Length - 1)]}-{new Random()
                .Next(1, 200)}";
        await _planeDbContext.Planes
            .AddAsync(newPlane, cancellationToken);
        return newPlane.Id;
    }

    private async Task<(Guid, List<Guid>)> GenerateZones(string planeId, CancellationToken cancellationToken)
    {
        var newZonesId = new ValueTuple<Guid, List<Guid>>();
        //Бизнес
        for (int i = 0; i < BusinessZonesInPlane; i++)
        {
            var newZone = new Domain.Zone.Zone(_fixture
                .Create<Guid>(), planeId, "Бизнес");
            await _zoneDbContext.Zones
                .AddAsync(newZone, cancellationToken);
            newZonesId.Item1 = newZone.Id;
        }

        //Экономы
        var economyZoneIds = new List<Guid>();
        for (int i = 0; i < EconomyZonesInPlane; i++)
        {
            var newZone = new Domain.Zone.Zone(_fixture.Create<Guid>(), planeId, $"Эконом №{i + 1}");
            await _zoneDbContext.Zones
                .AddAsync(newZone, cancellationToken);
            economyZoneIds.Add(newZone.Id);
        }

        newZonesId.Item2 = economyZoneIds;
        return newZonesId;
    }

    private async Task<(List<string>, List<string>)> GenerateEquips((Guid, List<Guid>) idZones,
        CancellationToken cancellationToken)
    {
        var newEquips = new ValueTuple<List<string>, List<string>>
        {
            Item1 = new List<string>(),
            Item2 = new List<string>()
        };
        //Бизнес
        for (int i = 0; i < EquipsInBusiness * BusinessZonesInPlane; i++)
        {
            var newEquip = new Domain.Equip.Equip(_fixture.Create<string>(), 
                idZones.Item1, EquipsSpaceInBusiness[i],
                _fixture.Create<string>(), _fixture.Create<Type>(), 
                _fixture.Create<DateTimeOffset>(),
                _fixture.Create<DateTimeOffset>(), (Status)new Random().Next(0, 5));
            await _equipDbContext.Equips
                .AddAsync(newEquip, cancellationToken);
            newEquips.Item1.Add(newEquip.Id);
        }

        //Эконом
        var spaces = 0;
        for (int i = 0; i < EconomyZonesInPlane; i++)
        {
            for (int j = 0; j < EquipsInEconomy; j++)
            {
                var newEquip = new Domain.Equip.Equip(_fixture.Create<string>(), idZones.Item2[i],
                    EquipsSpaceInEconomy[spaces],
                    _fixture.Create<string>(), _fixture.Create<Type>(), 
                    _fixture.Create<DateTimeOffset>(),
                    _fixture.Create<DateTimeOffset>(), 
                    (Status)new Random().Next(0, 5));
                await _equipDbContext.Equips
                    .AddAsync(newEquip, cancellationToken);
                newEquips.Item2.Add(newEquip.Id);
                spaces++;
            }
        }
        return newEquips;
    }

    private async Task<Guid> GenerateReport(List<Guid> users, string planeId,
        (Guid, List<Guid>) idZones,
        (List<string>, List<string>) equips, CancellationToken cancellationToken)
    {
        var dateStart = _fixture.Create<DateTimeOffset>();
        var dateFinish = dateStart.AddHours(1);
        var listZoneReports = new List<ZoneReport>();
        var equipsBusinessChecks = new List<EquipReport>();
        //Бизнес
        var businessZone = new ZoneReport(idZones.Item1);
        var userTimeInfo = new List<(Guid, DateTimeOffset)>();
        foreach (var user in users)
        {
            var dateStartCheck = new Random()
                .Next(1, 10);
            var checker = new Checker(user, dateStart)
            {
                DateTimeFinish = dateStart
                    .AddMinutes(dateStartCheck)
            };
            businessZone.Checkers.Add(checker);
            userTimeInfo.Add(new ValueTuple<Guid, DateTimeOffset>(user, checker.DateTimeFinish.Value));
        }

        foreach (var equip in equips.Item1)
        {
            var equipInfo =
                await _equipDbContext.Equips.FirstOrDefaultAsync(e => e.Id == equip,
                    cancellationToken: cancellationToken);
            var randomUser = userTimeInfo[new Random().Next(0, userTimeInfo.Count - 1)];
            var equipCheck = new EquipReport(equipInfo.Id, (Status)new Random().Next(0, 5), 
                equipInfo.Space,
                randomUser.Item2.AddMinutes(new Random().Next(1, 20)),
                randomUser.Item1);
            equipsBusinessChecks.Add(equipCheck);
        }

        businessZone.EquipReports = equipsBusinessChecks;
        listZoneReports.Add(businessZone);
        //Эконом
        var zonesEquipsCreate = 0;
        foreach (var idZone in idZones.Item2)
        {
            var allEquip = equips.Item2.Count;
            var countCheck = 0;
            var randomCheckTime = 10;
            var economyZone = new ZoneReport(idZone);
            var equipsEconomyChecks = new List<EquipReport>();
            var userTimeInfoEconomy = new List<(Guid, DateTimeOffset)>();
            var dateStartCheck = _fixture.Create<DateTimeOffset>().AddMinutes(10);
            foreach (var user in users)
            {
                var dateStartCheckRandom = new Random().Next(randomCheckTime, randomCheckTime + 8);
                var checker = new Checker(user, dateStart.AddMinutes(20 * (countCheck + 1)))
                {
                    DateTimeFinish = dateStart.AddMinutes(dateStartCheckRandom)
                };
                economyZone.Checkers.Add(checker);
                userTimeInfoEconomy.Add(new ValueTuple<Guid, DateTimeOffset>(user, checker.DateTimeFinish.Value));
            }

            var countEquipInZone = 0;
            for (int z = zonesEquipsCreate; z < allEquip; z++)
            {
                if (countEquipInZone == 24)
                {
                    break;
                }

                var equipInfo =
                    await _equipDbContext.Equips
                        .FirstOrDefaultAsync(e => e.Id == equips.Item2[z],
                        cancellationToken: cancellationToken);
                var randomUser = userTimeInfoEconomy[new Random().Next(0, userTimeInfoEconomy.Count - 1)];
                var equipCheck = new EquipReport(equipInfo.Id, (Status)new Random().Next(0, 5),
                    equipInfo.Space,
                    randomUser.Item2.AddMinutes(new Random().Next(1, 20)),
                    randomUser.Item1);
                equipsEconomyChecks.Add(equipCheck);
                countEquipInZone++;
                zonesEquipsCreate++;
            }

            economyZone.EquipReports = equipsEconomyChecks;
            listZoneReports.Add(economyZone);
            countCheck++;
        }

        var report = new Domain.Report.Report(_fixture.Create<Guid>(), planeId, _fixture.Create<ReportType>(),
            dateStart, dateFinish, _fixture.Create<bool>(), listZoneReports);
        await _reportDbContext.Reports.AddAsync(report, cancellationToken);
        return report.Id;
    }
}