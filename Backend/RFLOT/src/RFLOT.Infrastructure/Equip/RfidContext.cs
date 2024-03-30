using Microsoft.EntityFrameworkCore;
using RFLOT.Domain.People;
using RFLOT.Domain.Plane;
using RFLOT.Domain.Plane.ValueObjects;
using RFLOT.Infrastructure.Equip.EntityConfigurations;

namespace RFLOT.Infrastructure.Equip;

public class RfidContext : DbContext
{
    public RfidContext(DbContextOptions<RfidContext> options) : base(options)
    {
    }

    public DbSet<Domain.Equip.Equip> Equips { get; set; }
    public DbSet<People> Peoples { get; set; }
    public DbSet<Plane> Planes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EquipConfiguration());
        modelBuilder.ApplyConfiguration(new PeopleConfiguration());
        modelBuilder.ApplyConfiguration(new PlaneConfiguration());
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