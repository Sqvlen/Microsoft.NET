using Microsoft.Extensions.DependencyInjection;
using Routes.Infrastructure;

namespace Routes.RestApi.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection ConfigureService(this IServiceCollection services)
    {
        services.AddRepositories();
        
        return services;
    }
}