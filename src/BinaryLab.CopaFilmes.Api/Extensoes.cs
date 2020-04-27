using System.Reflection;
using BinaryLab.CopaFilmes.Api.Versioning;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace BinaryLab.CopaFilmes.Api
{

    public static class Extensoes
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddCors();
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHealthChecks();
            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddVersionamentoApi(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new HeaderApiVersionReader(Headers.Versao);
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = Headers.PadraoRota;
                p.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return AddSwagger(services, string.Empty);
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string swaggerTitle)
        {
            services.AddSwaggerGen(options =>
            {
                var title = swaggerTitle;
                if (string.IsNullOrEmpty(title))
                    title = Assembly.GetEntryAssembly()?.GetName().Name;

                var provider = services.BuildServiceProvider()
                    .GetRequiredService<IApiVersionDescriptionProvider>();
                
                foreach ( var description in provider.ApiVersionDescriptions )
                {
                    var apiVersion = description.GroupName;
                    options.SwaggerDoc(apiVersion, new Info { Title = title, Version = apiVersion });
                }

            });

            return services;
        }

        public static IApplicationBuilder UseVersionamento(this IApplicationBuilder app)
        {
            app.UseApiVersioning();
            
            return app;
        }

        public static IApplicationBuilder UseSwaggerApi(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }

                options.DocExpansion(DocExpansion.None);
            });

            return app;
        }

        public static IApplicationBuilder UseCorsForAllOrigins(this IApplicationBuilder app)
        {
            app.UseCors(_ => {
                _.AllowAnyOrigin();
                _.AllowAnyHeader();
                _.AllowAnyMethod();
            });

            return app;
        }

        public static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app, string url = ValoresPadrao.HealthCheckUrl)
        {
            var healthCheckUrl = ValoresPadrao.HealthCheckUrl;
            if (!string.IsNullOrWhiteSpace(url))
                healthCheckUrl = url;

            app.UseHealthChecks(healthCheckUrl, new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            return app;
        }
    }
}
