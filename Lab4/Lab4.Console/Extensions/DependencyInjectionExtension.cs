using Lab4.Infrastructure;
using Lab4.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab4.Console.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddLab4Services(this IServiceCollection services)
    {
        services.AddInfrastructure();
        
        return services;
    }
}