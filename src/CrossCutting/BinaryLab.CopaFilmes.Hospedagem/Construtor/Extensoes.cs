using BinaryLab.CopaFilmes.Api;
using BinaryLab.CopaFilmes.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BinaryLab.CopaFilmes.Hospedagem.Construtor
{
    public static class Extensoes
    {
        public static IApplicationBuilder BuildApiApplication(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider, string healthCheckUrl = ValoresPadrao.HealthCheckUrl)
        {
            app.UseCorsForAllOrigins()
                .UseMvcWithDefaultRoute()
                .UseVersionamento()
                .UseSwaggerApi(provider)
                .UseMiddlewares()
                .UseHealthChecks(healthCheckUrl);

            return app;
        }

        public static IHostingEnvironment UseEnvironments(this IHostingEnvironment env,
            IApplicationBuilder applicationBuilder)
        {
            if (env.IsDevelopment())
                applicationBuilder.UseDeveloperExceptionPage();
            else
                applicationBuilder.UseHsts();

            applicationBuilder.UseHttpsRedirection();

            return env;
        }
    }
}
