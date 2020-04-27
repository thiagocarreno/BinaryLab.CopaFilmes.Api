using Serilog;

namespace BinaryLab.CopaFilmes.Logging.Abstractions
{
    public interface IConfiguracaoLogger
    {
        ILogger Configurar(string variavelAmbiente);
    }
}
