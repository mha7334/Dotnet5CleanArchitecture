using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddAppicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IGadgetService, GadgetService>();
        return services;
    }
}