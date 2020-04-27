namespace BinaryLab.CopaFilmes.Tests.Mocks
{
    public class AppSettings
    {
        public static RecursoExterno RecursoExterno = new RecursoExterno();
    }

    public class RecursoExterno
    {
        public readonly string UrlBase = "http://copafilmes.azurewebsites.net/api/";
        public readonly string NomeCliente = "CopaFilmes";
        public readonly string Filmes = nameof(Filmes);
    }
}
