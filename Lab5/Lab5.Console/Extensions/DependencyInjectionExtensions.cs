using Lab5.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Console.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddLab5Services(this IServiceCollection services)
    {
        services.AddInfrastructure();
        
        return services;
    }
}