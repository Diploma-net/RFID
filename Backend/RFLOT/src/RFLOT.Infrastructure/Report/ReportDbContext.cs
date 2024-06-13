using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RFLOT.Common.EF;
using RFLOT.Infrastructure.Kafka;
using RFLOT.Infrastructure.Report.EntityConfigurations;

namespace RFLOT.Infrastructure.Report;

public class ReportDbContext : DbContext, IEventPublisher
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator 
                    ?? throw new ArgumentNullException(nameof(mediator));
    }

    private readonly IMediator _mediator;

    public DbSet<Domain.Report.Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReportConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured) 
            throw new InvalidOperationException("Context was not configured");

        base.OnConfiguring(optionsBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync<Guid>(this);
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

    public override async ValueTask<EntityEntry> AddAsync(object entity,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.AddAsync(entity, cancellationToken);
        await EventPublish(result.Entity, cancellationToken);
        return result;
    }

    public async Task EventPublish(object entity, CancellationToken cancellationToken = default)
    {
        await Producer<object>.ProduceAsync(entity);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();
    }
}