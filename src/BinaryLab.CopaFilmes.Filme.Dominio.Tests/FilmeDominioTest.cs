using System.Linq;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Mocks;
using FluentAssertions;
using Xunit;

namespace BinaryLab.CopaFilmes.Filme.Dominio.Tests
{
    public class FilmeDominioTest
    {
        private Filmes FilmesMock { get; }

        public FilmeDominioTest()
        {
            FilmesMock = new Filmes();
        }

        [Fact(DisplayName = "Deve Ordenar Alfab�ticamente")]
        public void DeveOrdernarAlfabeticamente()
        {
            var oitoPrimeirosFilmesMock = FilmesMock.OitoPrimeiros;

            var filmesDominio = new FilmeDominio();
            var filmesOrdenados = filmesDominio.Ordenar(oitoPrimeirosFilmesMock);

            filmesOrdenados.Should().BeEquivalentTo(FilmesMock.OitoPrimeirosOrdenados);
        }

        [Fact(DisplayName = "Deve Ordenar Ass�ncronamente Alfab�ticamente")]
        public async Task DeveOrdernarAlfabeticamenteAsync()
        {
            var oitoPrimeirosFilmesMock = FilmesMock.OitoPrimeiros;

            var filmesDominio = new FilmeDominio();
            var filmesOrdenados = await filmesDominio.OrdenarAsync(oitoPrimeirosFilmesMock);

            filmesOrdenados.Should().BeEquivalentTo(FilmesMock.OitoPrimeirosOrdenados);
        }

        [Fact(DisplayName = "Deve C�lcular Quantidade de Disputas")]
        public void DeveCalcularDisputas()
        {
            var quantidadeDisputasMock = 4;

            var filmesDominio = new FilmeDominio();
            var quanitdadeDisputas = filmesDominio.CalcularDisputas(FilmesMock.OitoPrimeirosOrdenados);

            quanitdadeDisputas.Should().Be(quantidadeDisputasMock);
        }

        [Fact(DisplayName = "Deve C�lcular Ass�ncronamente a Quantidade de Disputas")]
        public async Task DeveCalcularDisputasAsync()
        {
            var quantidadeDisputasMock = 4;

            var filmesDominio = new FilmeDominio();
            var quanitdadeDisputas = await filmesDominio.CalcularDisputasAsync(FilmesMock.OitoPrimeirosOrdenados);

            quanitdadeDisputas.Should().Be(quantidadeDisputasMock);
        }
        
        [Theory(DisplayName = "Deve C�lcular o Index do �ltimo Filme")]
        [InlineData(0, 7)]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        public void DeveRetornarUltimoIndex(int index, int ultimoIndexEsperado)
        {
            var quantidadeFilmes = FilmesMock.OitoPrimeirosOrdenados.Count();

            var filmesDominio = new FilmeDominio();
            var ultimoIndex = filmesDominio.ObterUltimoIndex(quantidadeFilmes, index);

            ultimoIndex.Should().Be(ultimoIndexEsperado);
        }

        [Theory(DisplayName = "Deve C�lcular Ass�ncronamente o Index do �ltimo Filme")]
        [InlineData(0, 7)]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        public void DeveRetornarUltimoIndexAsync(int index, int ultimoIndexEsperado)
        {
            var quantidadeFilmes = FilmesMock.OitoPrimeirosOrdenados.Count();

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
            var primeiroFilmeMock = FilmesMock.OitoPrimeirosOrdenados.ElementAt(indexPrimeiroFilmeDisputa);
            var segundoFilmeMock = FilmesMock.OitoPrimeirosOrdenados.ElementAt(indexSegundoFilmeDisputa);

            var filmesDominio = new FilmeDominio();
            var vencedor = filmesDominio.ObterVencedor(primeiroFilmeMock, segundoFilmeMock);

            if (indexPrimeiroFilmeDisputa < 3)
                vencedor.Should().Be(segundoFilmeMock);
            else
                vencedor.Should().Be(primeiroFilmeMock);
        }

        [Theory(DisplayName = "Deve Obter Ass�ncronamete o Filme Vencedor")]
        [InlineData(0, 7)]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        public async Task DeveObterVencedorAsync(int indexPrimeiroFilmeDisputa, int indexSegundoFilmeDisputa)
        {
            var primeiroFilmeMock = FilmesMock.OitoPrimeirosOrdenados.ElementAt(indexPrimeiroFilmeDisputa);
            var segundoFilmeMock = FilmesMock.OitoPrimeirosOrdenados.ElementAt(indexSegundoFilmeDisputa);

            var filmesDominio = new FilmeDominio();
            var vencedor = await filmesDominio.ObterVencedorAsync(primeiroFilmeMock, segundoFilmeMock);

            if (indexPrimeiroFilmeDisputa < 3)
                vencedor.Should().Be(segundoFilmeMock);
            else
                vencedor.Should().Be(primeiroFilmeMock);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Filmes Vencedores da Primera Rodada")]
        public void DeveFazerDisputaERetornarVencedoresPrimeraRodada()
        {
            var oitoPrimeirosFilmesMock = FilmesMock.OitoPrimeiros;

            var filmesDominio = new FilmeDominio();
            var filmesVencedores = filmesDominio.Disputar(oitoPrimeirosFilmesMock);

            filmesVencedores.Should().BeEquivalentTo(FilmesMock.VencedoresPrimeiraRodada);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Ass�ncronamente Filmes Vencedores da Primera Rodada")]
        public async Task DeveFazerDisputaERetornarVencedoresPrimeraRodadaAsync()
        {
            var oitoPrimeirosFilmesMock = FilmesMock.OitoPrimeiros;

            var filmesDominio = new FilmeDominio();
            var filmesVencedores = await filmesDominio.DisputarAsync(oitoPrimeirosFilmesMock);

            filmesVencedores.Should().BeEquivalentTo(FilmesMock.VencedoresPrimeiraRodada);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Filmes Vencedores da Segunda Rodada")]
        public void DeveFazerDisputaERetornarVencedoresSegundaRodada()
        {
            var vencedoresPrimeiraRodadaMock = FilmesMock.VencedoresPrimeiraRodada;

            var filmesDominio = new FilmeDominio();
            var filmesVencedores = filmesDominio.Disputar(vencedoresPrimeiraRodadaMock);

            filmesVencedores.Should().BeEquivalentTo(FilmesMock.VencedoresSegundaRodada);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Ass�ncronamente Filmes Vencedores da Segunda Rodada")]
        public async Task DeveFazerDisputaERetornarVencedoresSegundaRodadaAsync()
        {
            var vencedoresPrimeiraRodadaMock = FilmesMock.VencedoresPrimeiraRodada;

            var filmesDominio = new FilmeDominio();
            var filmesVencedores = await filmesDominio.DisputarAsync(vencedoresPrimeiraRodadaMock);

            filmesVencedores.Should().BeEquivalentTo(FilmesMock.VencedoresSegundaRodada);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar o Filme Vencedor")]
        public void DeveFazerDisputaERetornarVencedor()
        {
            var vencedoresSegundaRodadaMock = FilmesMock.VencedoresSegundaRodada;

            var filmesDominio = new FilmeDominio();
            var vencedor = filmesDominio.Disputar(vencedoresSegundaRodadaMock);

            vencedor.Should().BeEquivalentTo(FilmesMock.Vencedor);
        }

        [Fact(DisplayName = "Deve Fazer Disputa e Retornar Ass�ncronamente o Filme Vencedor")]
        public async Task DeveFazerDisputaERetornarVencedorAsync()
        {
            var vencedoresSegundaRodadaMock = FilmesMock.VencedoresSegundaRodada;

            var filmesDominio = new FilmeDominio();
            var vencedor = await filmesDominio.DisputarAsync(vencedoresSegundaRodadaMock);

            vencedor.Should().BeEquivalentTo(FilmesMock.Vencedor);
        }
    }
}
