using Microsoft.EntityFrameworkCore;
using RFLOT.DLL.EntityConfigurations;
using RFLOT.Domain;
using RFLOT.Domain.Equip;
using RFLOT.Domain.People;
using RFLOT.Domain.Zone;

namespace RFLOT.DLL;

public class RfidContext : DbContext
{
    public RfidContext(DbContextOptions<RfidContext> options) : base(options)
    {
    }

    public DbSet<Equip> Users { get; set; }
    public DbSet<People> Wallets { get; set; }
    public DbSet<Zone> Currencies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EquipConfiguration());
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