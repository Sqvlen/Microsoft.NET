using Microsoft.Extensions.DependencyInjection;
using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Database.Repositories;

namespace Routes.Infrastructure;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IStopRepository, StopRepository>();
        services.AddScoped<IRouteRepository, RouteRepository>();
        services.AddScoped<ITrolleybusRepository, TrolleybusRepository>();
        
        return services;
    }
}