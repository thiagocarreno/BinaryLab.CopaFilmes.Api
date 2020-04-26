using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BinaryLab.CopaFilmes.Filme.Dominio;
using BinaryLab.CopaFilmes.Filme.Dominio.Abstracoes;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Mapeamentos;
using BinaryLab.CopaFilmes.Tests.Mocks.ServicoAplicacao.DTO;
using FluentAssertions;
using Moq;
using Xunit;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.UnitTests
{
    public class FilmeServicoAplicacaoUnitTests
    {
        private Filmes FilmesServicoAplicacaoMock { get; }
        private Tests.Mocks.Dominio.Filmes FilmesDominioMock { get; }
        private Tests.Mocks.Repositorio.Entidades.Filmes FilmesRepositorioMock { get; }
        
        private IMapper _mapper { get; }

        public FilmeServicoAplicacaoUnitTests()
        {
            FilmesServicoAplicacaoMock = new Filmes();
            FilmesDominioMock = new Tests.Mocks.Dominio.Filmes();
            FilmesRepositorioMock = new Tests.Mocks.Repositorio.Entidades.Filmes();

            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FilmeMapper());
            }).CreateMapper();
        }

        [Fact(DisplayName = "Deve Obter os Filmes")]
        public void DeveObterFilmes()
        {
            var filmeRepositorioMock = new Mock<IFilmeRepositorio>();
            filmeRepositorioMock.Setup(frp => frp.Obter()).Returns(FilmesRepositorioMock.Lista);
            
            var filmeServicoAplicacao = new FilmeServicoAplicacao(filmeRepositorioMock.Object, _mapper);
            var filmes = filmeServicoAplicacao.Obter();

            filmes.Should().BeEquivalentTo(FilmesServicoAplicacaoMock.Lista);
        }

        [Fact(DisplayName = "Deve Obter Assíncronamente os Filmes")]
        public async Task DeveObterFilmesAsync()
        {
            var filmeRepositorioMock = new Mock<IFilmeRepositorio>();
            filmeRepositorioMock.Setup(frp => frp.ObterAsync()).Returns(Task.FromResult(FilmesRepositorioMock.Lista));
            
            var filmeServicoAplicacao = new FilmeServicoAplicacao(filmeRepositorioMock.Object, _mapper);
            var filmes = await filmeServicoAplicacao.ObterAsync();

            filmes.Should().BeEquivalentTo(FilmesServicoAplicacaoMock.Lista);
        }

        [Fact(DisplayName = "Deve Obter os Filmes Vencedores")]
        public void DeveObterVencedores()
        {
            var dominioMock = new Mock<IFilmeDominio>();
            dominioMock.Setup(dm => dm.ObterVencedores(It.IsAny<IEnumerable<Dominio.Entidades.Filme>>()))
                .Returns(FilmesDominioMock.VencedoresSegundaRodada);

            var filmeRepositorioMock = new Mock<IFilmeRepositorio>();
            filmeRepositorioMock.Setup(frm => frm.Obter(It.IsAny<string[]>()))
                .Returns(FilmesRepositorioMock.OitoPrimeiros);
            
            var filmeServicoAplicacao = new FilmeServicoAplicacao(filmeRepositorioMock.Object, _mapper, dominioMock.Object);
            var filmes = filmeServicoAplicacao.ObterVencedores(FilmesServicoAplicacaoMock.OitoPrimeirosIds);

            filmes.Should().BeEquivalentTo(FilmesServicoAplicacaoMock.Vencedores);
        }

        [Fact(DisplayName = "Deve Obter Assíncronamente os Filmes Vencedores")]
        public async Task DeveObterVencedoresAsync()
        {
            var dominioMock = new Mock<IFilmeDominio>();
            dominioMock.Setup(dm =>
                    dm.ObterVencedoresAsync(It.IsAny<IEnumerable<Dominio.Entidades.Filme>>(),
                        It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(FilmesDominioMock.VencedoresSegundaRodada));

            var filmeRepositorioMock = new Mock<IFilmeRepositorio>();
            filmeRepositorioMock.Setup(frm =>
                    frm.ObterAsync(It.IsAny<string[]>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(FilmesRepositorioMock.OitoPrimeiros));

            var dominio = new FilmeDominio();
            var filmeServicoAplicacao = new FilmeServicoAplicacao(filmeRepositorioMock.Object, _mapper, dominio);
            var filmes = await filmeServicoAplicacao.ObterVencedoresAsync(FilmesServicoAplicacaoMock.OitoPrimeirosIds);

            filmes.Should().BeEquivalentTo(FilmesServicoAplicacaoMock.Vencedores);
        }
    }
}
