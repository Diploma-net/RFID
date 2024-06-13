using Microsoft.EntityFrameworkCore;
using RFLOT.Identity.Context.Configurations;

namespace RFLOT.Identity.Context;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured)
            throw new InvalidOperationException("Context was not configured");

        base.OnConfiguring(optionsBuilder);
    }
}