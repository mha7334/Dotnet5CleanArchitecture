using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyDbContext>(options => {
            var connectionString = configuration.GetConnectionString("MyDbConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IMyDbContext>(options => options.GetService<MyDbContext>());
        return services;
    }
}