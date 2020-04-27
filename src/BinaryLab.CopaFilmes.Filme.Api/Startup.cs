using BinaryLab.CopaFilmes.Configuracao;
using BinaryLab.CopaFilmes.Configuracao.DependencyInjenction;
using BinaryLab.CopaFilmes.Hospedagem.Construtor;
using BinaryLab.CopaFilmes.Hospedagem.InjecaoDependencia;
using BinaryLab.CopaFilmes.Repositorio.Http.InjecaoDependencia;
using BinaryLab.CopaFilmes.Repositorio.InjecaoDependencia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Filme.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguracao<ConfiguracaoPadrao>(Configuration)
                .AddApiServices(GerenciadorConfiguracao<ConfiguracaoPadrao>.Configuracoes?.SwaggerTitle)
                .AddRepositorio().AddRepositorioHttp();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            env.UseEnvironments(app);
            app.BuildApiApplication(provider, GerenciadorConfiguracao<ConfiguracaoPadrao>.Configuracoes?.HealthCheckUrl);
        }
    }
}
