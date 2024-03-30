using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Infrastructure;

public static class IoC
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RfidDbContext>(
            options => options.UseNpgsql(
                configuration.GetConnectionString("RfidConnection")
            )
        );
        return services;
        
    }
}