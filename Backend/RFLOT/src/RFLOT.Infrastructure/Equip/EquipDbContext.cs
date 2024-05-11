using Microsoft.EntityFrameworkCore;
using RFLOT.Infrastructure.Equip.Configurations;

namespace RFLOT.Infrastructure.Equip;

public class EquipDbContext : DbContext
{
    public EquipDbContext(DbContextOptions<EquipDbContext> options) : base(options)
    {
    }

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
}