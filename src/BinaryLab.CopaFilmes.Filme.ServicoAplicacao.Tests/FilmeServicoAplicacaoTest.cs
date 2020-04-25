using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using FluentAssertions;
using Moq;
using Xunit;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Tests
{
    public class FilmeServicoAplicacaoTest
    {
        private Mocks.Repositorio.Entidades.Filmes FilmesRepositorioMock { get; }
        private Mocks.ServicoAplicacao.DTO.Filmes FilmesServicoAplicacaoMock { get; }

        public FilmeServicoAplicacaoTest()
        {
            FilmesRepositorioMock = new Mocks.Repositorio.Entidades.Filmes();
            FilmesServicoAplicacaoMock = new Mocks.ServicoAplicacao.DTO.Filmes();
        }

        [Fact(DisplayName = "Deve Obter os Filmes")]
        public void DeveObterFilmes()
        {
            var filmeRepositorioMock = new Mock<IFilmeRepositorio>();
            filmeRepositorioMock.Setup(frp => frp.Obter()).Returns(FilmesRepositorioMock.Lista);

            var filmeServicoAplicacao = new FilmeServicoAplicacao(filmeRepositorioMock.Object);
            var filmes = filmeServicoAplicacao.ObterFilmes();

            filmes.Should().BeEquivalentTo(FilmesServicoAplicacaoMock.Lista);
        }
    }
}
