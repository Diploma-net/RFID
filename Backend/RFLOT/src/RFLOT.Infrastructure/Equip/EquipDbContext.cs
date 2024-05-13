using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Common.EF;
using RFLOT.Infrastructure.Equip.Configurations;

namespace RFLOT.Infrastructure.Equip
{
    public class EquipDbContext : DbContext, IEventPublisher
    {
        public EquipDbContext(DbContextOptions<EquipDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private readonly IMediator _mediator;
        public DbSet<Domain.Equip.Equip> Equips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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
    }
}