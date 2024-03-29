using Microsoft.EntityFrameworkCore;
using RFLOT.Domain.Equip;
using RFLOT.Domain.People;
using RFLOT.Domain.Zone;
using RFLOT.Infrastructure.Contexts.EntityConfigurations;

namespace RFLOT.Infrastructure.Contexts;

public class RfidContext : DbContext
{
    public RfidContext(DbContextOptions<RfidContext> options) : base(options)
    {
    }

    public DbSet<Equip> Equips { get; set; }
    public DbSet<People> Peoples { get; set; }
    public DbSet<Zone> Zones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EquipConfiguration());
        modelBuilder.ApplyConfiguration(new PeopleConfiguration());
        modelBuilder.ApplyConfiguration(new ZoneConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured) 
        {
            throw new InvalidOperationException("Context was not configured");
        }
        base.OnConfiguring(optionsBuilder);
    }
}