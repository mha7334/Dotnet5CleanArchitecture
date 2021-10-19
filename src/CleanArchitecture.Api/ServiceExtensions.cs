using System;
using System.Collections.Generic;
using CleanArchitecture.Api.Healthcheck;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CleanArchitecture.Api
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });
        }

        public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("MyDbConnection"), healthQuery: "select 1",
                    name: "SQL Server", HealthStatus.Unhealthy, tags: new List<string>())
                .AddCheck<RemoteHealthCheck>("Remote endpoints Health Check", HealthStatus.Unhealthy)
                .AddCheck<MemoryHealthCheck>("Api Memory check", failureStatus: HealthStatus.Unhealthy,
                    tags: new[] {"gadget service"})
                .AddUrlGroup(new Uri("https://localhost:5001/api/GadgetService/v1/heartbeat/ping"), name: "base Url", failureStatus: HealthStatus.Unhealthy);


            services.AddHealthChecksUI(opt =>
                {
                    opt.SetEvaluationTimeInSeconds(10);
                    opt.MaximumHistoryEntriesPerEndpoint(60);
                    opt.SetApiMaxActiveRequests(1);
                    opt.AddHealthCheckEndpoint("gadget api", "/api/health");
                })
                .AddInMemoryStorage();

        }
    }
}