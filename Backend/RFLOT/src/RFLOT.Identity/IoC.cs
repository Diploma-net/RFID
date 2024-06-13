using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RFLOT.Identity.Context;

namespace RFLOT.Identity;

public static class IoC
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserDbContext>(
            options => options.UseNpgsql(
                configuration
                    .GetConnectionString("IdentityConnection")
            )
        );
        services.AddScoped<IAuthorization, Authorizations>();
        services.AddScoped<IGetUser, GetUser>();
        return services;
    }
}