using Microsoft.EntityFrameworkCore;
using RFLOT.Domain.People;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Equip.EntityConfigurations;

namespace RFLOT.Infrastructure.Report;

public class ReportDbContext : DbContext
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Report.Report> Reports { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
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