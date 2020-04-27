using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Configuracao.InjecaoDependencia
{
    public static class Extensoes
    {
        public static IServiceCollection AddConfiguracao<TSettings>(this IServiceCollection services,
            IConfiguration configuration) where TSettings : class
        {
            GerenciadorConfiguracao<TSettings>.Load(configuration);
            services.Configure<TSettings>(configuration.Bind);

            return services;
        } 
    }
}
