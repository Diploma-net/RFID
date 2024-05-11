using Microsoft.EntityFrameworkCore;
using RFLOT.Infrastructure.Zone.Configurations;

namespace RFLOT.Infrastructure.Zone;

public class ZoneDbContext : DbContext
{
    public ZoneDbContext(DbContextOptions<ZoneDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Zone.Zone> Zones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ZoneConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured) throw new InvalidOperationException("Context was not configured");

        base.OnConfiguring(optionsBuilder);
    }
}