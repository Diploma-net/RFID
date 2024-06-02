using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Common.EF;
using RFLOT.Infrastructure.Zone.Configurations;

namespace RFLOT.Infrastructure.Zone;

public class ZoneDbContext : DbContext, IEventPublisher
{
    public ZoneDbContext(DbContextOptions<ZoneDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    private readonly IMediator _mediator;

    public DbSet<Domain.Zone.Zone> Zones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ZoneConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured) throw new InvalidOperationException("Context was not configured");

        base.OnConfiguring(optionsBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync<string>(this);
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();
    }
}