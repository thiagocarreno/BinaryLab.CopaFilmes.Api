using System;
using BinaryLab.CopaFilmes.Configuracao;
using BinaryLab.CopaFilmes.Configuracao.InjecaoDependencia;
using BinaryLab.CopaFilmes.Filme.Api.Configuracao;
using BinaryLab.CopaFilmes.Filme.Dominio.InjecaoDependencia;
using BinaryLab.CopaFilmes.Filme.Repositorio.InjecaoDependencia;
using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.InjecaoDependencia;
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
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguracao<AppSettings>(Configuration)
                .AddApiServices(GerenciadorConfiguracao<AppSettings>.Configuracoes?.SwaggerTitle)
                .AddMapeamentosFilmeServicoAplicacao()
                .AddRepositorio().AddRepositorioHttp().AddContextoHttp(
                    GerenciadorConfiguracao<AppSettings>.Configuracoes?.RecursosExterno.NomeCliente ?? throw new InvalidOperationException(),
                    GerenciadorConfiguracao<AppSettings>.Configuracoes?.RecursosExterno.Filmes ?? throw new InvalidOperationException())
                .AddClienteHttp(
                    GerenciadorConfiguracao<AppSettings>.Configuracoes?.RecursosExterno.NomeCliente ?? throw new InvalidOperationException(),
                    GerenciadorConfiguracao<AppSettings>.Configuracoes?.RecursosExterno.UrlBase ?? throw new InvalidOperationException())
                .AddFilmeServicoAplicacao().AddFilmeDominio().AddFilmeRepositorio();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            env.UseEnvironments(app);
            app.BuildApiApplication(provider, GerenciadorConfiguracao<AppSettings>.Configuracoes?.HealthCheckUrl ?? throw new InvalidOperationException());
        }
    }
}
