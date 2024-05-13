using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RFLOT.Infrastructure.Equip;
using RFLOT.Infrastructure.Plane;
using RFLOT.Infrastructure.Report;
using RFLOT.Infrastructure.Zone;

namespace RFLOT.Infrastructure;

public static class IoC
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EquipDbContext>(
            options => options.UseNpgsql(
                configuration.GetConnectionString("EquipConnection")
            )
        );
        services.AddDbContext<ZoneDbContext>(
            options => options.UseNpgsql(
                configuration.GetConnectionString("ZoneConnection")
            )
        );
        services.AddDbContext<PlaneDbContext>(
            options => options.UseNpgsql(
                configuration.GetConnectionString("PlaneConnection")
            )
        );
        services.AddDbContext<ReportDbContext>(
            options => options.UseNpgsql(
                configuration.GetConnectionString("ReportConnection")
            )
        );
        return services;
    }
}