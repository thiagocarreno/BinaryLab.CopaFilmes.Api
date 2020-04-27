using BinaryLab.CopaFilmes.Configuracao;

namespace BinaryLab.CopaFilmes.Filme.Api.Configuracao
{
    public class AppSettings : ConfiguracaoPadrao
    {
        public RecursosExterno RecursosExterno { get; set; }
    }

    public class RecursosExterno
    {
        public string NomeCliente { get; set; }
        public string UrlBase { get; set; }
        public string Filmes { get; set; }
    }
}
