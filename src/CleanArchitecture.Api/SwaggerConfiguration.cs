using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Api.ApiContstants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.Api
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {

            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddVersionedApiExplorer(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;

            });

            services.AddApiVersioning(options =>
            {

                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            var readmeDoc = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Readme.md"));

            services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                IApiVersionDescriptionProvider provider =
                    services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
                string xmlFile = $"{typeof(SwaggerConfiguration).Assembly.GetName().Name}.xml";

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));

                options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
            });



            return services;
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            string serviceDescription = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Readme.md"));

            var info = new OpenApiInfo()
            {
                Title = $"{ApiConstants.ServiceFriendlyName} API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = serviceDescription
            };

            if (description.IsDeprecated)
            {
                info.Description += $"{Environment.NewLine} This api has been deprecated";
            }

            return info;
        }

        /// <summary>
        /// ConfigureSwagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {

            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));

            }

            app.UseSwagger(options => options.RouteTemplate =
                $"swagger/{ApiConstants.ApiName}/{{documentName}}/swagger.json");

            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = $"swagger/{ApiConstants.ApiName}";
                foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });


            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FeedbackService v1"));

            return app;
        }
    }
}
