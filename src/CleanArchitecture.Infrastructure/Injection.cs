using CleanArchitecture.Application.Interfaces.Data;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.DbContext;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class Injection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options => {
                var connectionString = configuration.GetConnectionString("MyDbConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IMyDbContext>(options => options.GetService<MyDbContext>());
            services.AddScoped<IGadgetRepository, GadgetRepository>();
            return services;
        }
    }
}