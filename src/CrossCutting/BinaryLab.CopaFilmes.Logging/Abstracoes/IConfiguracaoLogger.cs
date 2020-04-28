using Serilog;

namespace BinaryLab.CopaFilmes.Logging.Abstracoes
{
    public interface IConfiguracaoLogger
    {
        ILogger Configurar(string variavelAmbiente);
    }
}
