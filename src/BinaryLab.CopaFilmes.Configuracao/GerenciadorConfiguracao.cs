using Microsoft.Extensions.Configuration;

namespace BinaryLab.CopaFilmes.Configuracao
{
    public class GerenciadorConfiguracao<TSettings> where TSettings : class
    {
        public static TSettings Configuracoes { get; private set; }

        public GerenciadorConfiguracao()
        {}

        public GerenciadorConfiguracao(IConfiguration configuration) : this(configuration, string.Empty)
        { }

        public GerenciadorConfiguracao(IConfiguration configuration, string sectionName) => Load(configuration, sectionName);

        public static void Load(IConfiguration configuration) => Load(configuration, string.Empty);

        public static void Load(IConfiguration configuration, string sectionName)
        {
            if (!string.IsNullOrEmpty(sectionName))
            {
                Configuracoes = configuration.GetSection(sectionName).Get<TSettings>();
                return;
            }

            Configuracoes = configuration.Get<TSettings>();
        }

        public static void Clear() => Configuracoes = null;
    }
}
