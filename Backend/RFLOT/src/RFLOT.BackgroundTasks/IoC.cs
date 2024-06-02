using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RFLOT.Infrastructure.Report;

namespace RFLOT.BackgroundTasks;

public static class IoC
{
    public static IServiceCollection AddBackgroundTasks(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(assembly));
        return services;
    }
}