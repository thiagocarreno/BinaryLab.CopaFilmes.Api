using System.Linq;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Tests.Mocks.Dominio;
using FluentAssertions;
using Xunit;

namespace BinaryLab.CopaFilmes.Filme.Dominio.UnitTests
{
    public class FilmeDominioUnitTests
    {
        private Filmes _filmesMock { get; }

        public FilmeDominioUnitTests()
        {
            _filmesMock = new Filmes();
        }

        [Fact(DisplayName = "Deve Ordenar Alfabéticamente")]
        public void DeveOrdernarAlfabeticamente()
        {
            var oitoPrimeirosFilmesMock = _filmesMock.OitoPrimeiros;

            var filmesDominio = new FilmeDominio();
            var filmesOrdenados = filmesDominio.Ordenar(oitoPrimeirosFilmesMock);

            filmesOrdenados.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.OitoPrimeirosOrdenados);
        }

        [Fact(DisplayName = "Deve Ordenar Assíncronamente Alfabéticamente")]
        public async Task DeveOrdernarAlfabeticamenteAsync()
        {
            var oitoPrimeirosFilmesMock = _filmesMock.OitoPrimeiros;

            var filmesDominio = new FilmeDominio();
            var filmesOrdenados = await filmesDominio.OrdenarAsync(oitoPrimeirosFilmesMock);

            filmesOrdenados.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.OitoPrimeirosOrdenados);
        }

        [Fact(DisplayName = "Deve Cálcular Quantidade de Disputas")]
        public void DeveCalcularDisputas()
        {
            var quantidadeDisputasMock = 4;

            var filmesDominio = new FilmeDominio();
            var quanitdadeDisputas = filmesDominio.CalcularDisputas(_filmesMock.OitoPrimeirosOrdenados);

            quanitdadeDisputas.Should().Be(quantidadeDisputasMock);
        }

        [Fact(DisplayName = "Deve Cálcular Assíncronamente a Quantidade de Disputas")]
        public async Task DeveCalcularDisputasAsync()
        {
            var quantidadeDisputasMock = 4;

            var filmesDominio = new FilmeDominio();
            var quanitdadeDisputas = await filmesDominio.CalcularDisputasAsync(_filmesMock.OitoPrimeirosOrdenados);

            quanitdadeDisputas.Should().Be(quantidadeDisputasMock);
        }
        
        [Theory(DisplayName = "Deve Cálcular o Index do Último Filme")]
        [InlineData(0, 7)]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        public void DeveRetornarUltimoIndex(int index, int ultimoIndexEsperado)
        {
            var quantidadeFilmes = _filmesMock.OitoPrimeirosOrdenados.Count();

            var filmesDominio = new FilmeDominio();
            var ultimoIndex = filmesDominio.ObterUltimoIndex(quantidadeFilmes, index);

            ultimoIndex.Should().Be(ultimoIndexEsperado);
        }

        [Fact(DisplayName = "Deve Obter os Filmes Vencedores")]
        public void DeveObterVencedores()
        {
            var vencedoresMock = _filmesMock.VencedoresSegundaRodada;

            var filmesDominio = new FilmeDominio();
            var vencedores = filmesDominio.ObterVencedores(_filmesMock.OitoPrimeirosOrdenados);

            vencedores.Should().NotBeNull().And.BeEquivalentTo(vencedoresMock);
        }

        [Fact(DisplayName = "Deve Obter Assíncronamente os Filmes Vencedores")]
        public async Task DeveObterVencedoresAsync()
        {
            var vencedoresMock = _filmesMock.VencedoresSegundaRodada;

            var filmesDominio = new FilmeDominio();
            var vencedores = await filmesDominio.ObterVencedoresAsync(_filmesMock.OitoPrimeirosOrdenados);

            vencedores.Should().NotBeNull().And.BeEquivalentTo(vencedoresMock);
        }

        [Theory(DisplayName = "Deve Cálcular Assíncronamente o Index do Último Filme")]
        [InlineData(0, 7)]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        public void DeveRetornarUltimoIndexAsync(int index, int ultimoIndexEsperado)
        {
            var quantidadeFilmes = _filmesMock.OitoPrimeirosOrdenados.Count();

            var filmesDominio = new FilmeDominio();
            var ultimoIndex = filmesDominio.ObterUltimoIndex(quantidadeFilmes, index);

            ultimoIndex.Should().Be(ultimoIndexEsperado);
        }
        
        [Theory(DisplayName = "Deve Obter o Filme Vencedor")]
        [InlineData(0, 7)]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        public void DeveObterVencedor(int indexPrimeiroFilmeDisputa, int indexSegundoFilmeDisputa)
        {
            var primeiroFilmeMock = _filmesMock.OitoPrimeirosOrdenados.ElementAt(indexPrimeiroFilmeDisputa);
            var segundoFilmeMock = _filmesMock.OitoPrimeirosOrdenados.ElementAt(indexSegundoFilmeDisputa);

            var filmesDominio = new FilmeDominio();
            var vencedor = filmesDominio.ObterVencedor(primeiroFilmeMock, segundoFilmeMock);

            if (indexPrimeiroFilmeDisputa < 3)
                vencedor.Should().NotBeNull().And.Be(segundoFilmeMock);
            else
                vencedor.Should().NotBeNull().And.Be(primeiroFilmeMock);
        }

        [Theory(DisplayName = "Deve Obter Assíncronamete o Filme Vencedor")]
        [InlineData(0, 7)]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        public async Task DeveObterVencedorAsync(int indexPrimeiroFilmeDisputa, int indexSegundoFilmeDisputa)
        {
            var primeiroFilmeMock = _filmesMock.OitoPrimeirosOrdenados.ElementAt(indexPrimeiroFilmeDisputa);
            var segundoFilmeMock = _filmesMock.OitoPrimeirosOrdenados.ElementAt(indexSegundoFilmeDisputa);

            var filmesDominio = new FilmeDominio();
            var vencedor = await filmesDominio.ObterVencedorAsync(primeiroFilmeMock, segundoFilmeMock);

            if (indexPrimeiroFilmeDisputa < 3)
                vencedor.Should().NotBeNull().And.Be(segundoFilmeMock);
            else
                vencedor.Should().NotBeNull().And.Be(primeiroFilmeMock);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Filmes Vencedores da Primera Rodada")]
        public void DeveFazerDisputaERetornarVencedoresPrimeraRodada()
        {
            var oitoPrimeirosFilmesMock = _filmesMock.OitoPrimeiros;

            var filmesDominio = new FilmeDominio();
            var filmesVencedores = filmesDominio.Disputar(oitoPrimeirosFilmesMock);

            filmesVencedores.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.VencedoresPrimeiraRodada);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Assíncronamente Filmes Vencedores da Primera Rodada")]
        public async Task DeveFazerDisputaERetornarVencedoresPrimeraRodadaAsync()
        {
            var oitoPrimeirosFilmesMock = _filmesMock.OitoPrimeiros;

            var filmesDominio = new FilmeDominio();
            var filmesVencedores = await filmesDominio.DisputarAsync(oitoPrimeirosFilmesMock);

            filmesVencedores.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.VencedoresPrimeiraRodada);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Filmes Vencedores da Segunda Rodada")]
        public void DeveFazerDisputaERetornarVencedoresSegundaRodada()
        {
            var vencedoresPrimeiraRodadaMock = _filmesMock.VencedoresPrimeiraRodada;

            var filmesDominio = new FilmeDominio();
            var filmesVencedores = filmesDominio.Disputar(vencedoresPrimeiraRodadaMock);

            filmesVencedores.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.VencedoresSegundaRodada);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Assíncronamente Filmes Vencedores da Segunda Rodada")]
        public async Task DeveFazerDisputaERetornarVencedoresSegundaRodadaAsync()
        {
            var vencedoresPrimeiraRodadaMock = _filmesMock.VencedoresPrimeiraRodada;

            var filmesDominio = new FilmeDominio();
            var filmesVencedores = await filmesDominio.DisputarAsync(vencedoresPrimeiraRodadaMock);

            filmesVencedores.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.VencedoresSegundaRodada);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar o Filme Vencedor")]
        public void DeveFazerDisputaERetornarVencedor()
        {
            var vencedoresSegundaRodadaMock = _filmesMock.VencedoresSegundaRodada;

            var filmesDominio = new FilmeDominio();
            var vencedor = filmesDominio.Disputar(vencedoresSegundaRodadaMock);

            vencedor.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.Vencedor);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Assíncronamente o Filme Vencedor")]
        public async Task DeveFazerDisputaERetornarVencedorAsync()
        {
            var vencedoresSegundaRodadaMock = _filmesMock.VencedoresSegundaRodada;

            var filmesDominio = new FilmeDominio();
            var vencedor = await filmesDominio.DisputarAsync(vencedoresSegundaRodadaMock);

            vencedor.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.Vencedor);
        }
    }
}
