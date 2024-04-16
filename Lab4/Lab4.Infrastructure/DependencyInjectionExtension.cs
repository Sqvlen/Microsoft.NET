using Lab4.Infrastructure.Applicant.Builder;
using Lab4.Infrastructure.Applicant.Builder.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab4.Infrastructure;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IApplicantBuilder, ApplicantBuilder>();
        
        return services;
    }
}