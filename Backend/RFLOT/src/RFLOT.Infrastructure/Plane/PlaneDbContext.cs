using Microsoft.EntityFrameworkCore;
using RFLOT.Infrastructure.Plane.Configurations;

namespace RFLOT.Infrastructure.Plane;

public class PlaneDbContext : DbContext
{
    public PlaneDbContext(DbContextOptions<PlaneDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Plane.Plane> Planes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlaneConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured) throw new InvalidOperationException("Context was not configured");

        base.OnConfiguring(optionsBuilder);
    }
}