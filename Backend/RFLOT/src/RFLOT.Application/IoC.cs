using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RFLOT.BackgroundTasks;
using RFLOT.Infrastructure;

namespace RFLOT.Application;

public static class IoC
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        IConfigurationManager configuration)
    {
        var assembly = typeof(IoC).Assembly;
        services.AddDatabase(configuration);
        services.AddBackgroundTasks(configuration, assembly);
        services.AddSignalRCore();
        services.AddMediatR(x => 
            x.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        return services;
    }
}