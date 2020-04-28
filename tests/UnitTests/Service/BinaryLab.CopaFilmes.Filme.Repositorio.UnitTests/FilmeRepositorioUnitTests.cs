using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes;
using BinaryLab.CopaFilmes.Tests.Mocks.Repositorio.Entidades;
using FluentAssertions;
using Moq;
using Xunit;

namespace BinaryLab.CopaFilmes.Filme.Repositorio.UnitTests
{
    public class FilmeRepositorioUnitTests
    {
        public Filmes _filmesRepositorioMock { get; set; }
        public Tests.Mocks.ServicoAplicacao.DTO.Filmes _filmesSevicoAplicacaoMock { get; set; }

        public FilmeRepositorioUnitTests()
        {
            _filmesRepositorioMock = new Filmes();
            _filmesSevicoAplicacaoMock = new Tests.Mocks.ServicoAplicacao.DTO.Filmes();
        }

        [Fact(DisplayName = "Deve Obter Filmes")]
        public void DeveObterFilmes()
        {
            var httpContextoMock = new Mock<IHttpContexto>();
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.Obter()).Returns(_filmesRepositorioMock.Lista);

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpContextoMock.Object);
            var filmes = filmeRepositorio.Obter();

            filmes.Should().NotBeNull().And.BeEquivalentTo(_filmesRepositorioMock.Lista);
        }

        [Fact(DisplayName = "Deve Obter Filmes Assíncronamente")]
        public async Task DeveObterFilmesAsync()
        {
            var httpContextoMock = new Mock<IHttpContexto>();
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.ObterAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_filmesRepositorioMock.Lista));

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpContextoMock.Object);
            var filmes = await filmeRepositorio.ObterAsync();

            filmes.Should().NotBeNull().And.BeEquivalentTo(_filmesRepositorioMock.Lista);
        }

        [Fact(DisplayName = "Deve Obter Filmes por Ids")]
        public void DeveObterFilmesPorIds()
        {
            var httpContextoMock = new Mock<IHttpContexto>();
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.Obter(It.IsAny<string[]>())).Returns(_filmesRepositorioMock.OitoPrimeiros);

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpContextoMock.Object);
            var filmes = filmeRepositorio.Obter(_filmesSevicoAplicacaoMock.OitoPrimeirosIds.ToArray());

            filmes.Should().NotBeNull().And.BeEquivalentTo(_filmesRepositorioMock.OitoPrimeiros);
        }

        [Fact(DisplayName = "Deve Obter Filmes por Ids Assíncronamente")]
        public async Task DeveObterFilmesPorIdsAsync()
        {
            var httpContextoMock = new Mock<IHttpContexto>();
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.ObterAsync(It.IsAny<string[]>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_filmesRepositorioMock.OitoPrimeiros));

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpContextoMock.Object);
            var filmes = await filmeRepositorio.ObterAsync(_filmesSevicoAplicacaoMock.OitoPrimeirosIds.ToArray(), CancellationToken.None);

            filmes.Should().NotBeNull().And.BeEquivalentTo(_filmesRepositorioMock.OitoPrimeiros);
        }

        [Theory(DisplayName = "Deve Obter Filmes por Chave")]
        [InlineData("tt3606756")]
        [InlineData("tt3501632")]
        [InlineData("tt1825683")]
        public void DeveObterFilmesPorChave(string chave)
        {
            var filmeMock = _filmesRepositorioMock.Lista.FirstOrDefault(i => i.Id.Equals(chave));

            var httpContextoMock = new Mock<IHttpContexto>();
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.Obter()).Returns(_filmesRepositorioMock.Lista);

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpContextoMock.Object);
            var filme = filmeRepositorio.Obter(chave);

            filme.Should().NotBeNull().And.BeEquivalentTo(filmeMock);
        }

        [Theory(DisplayName = "Deve Obter Assíncronamente Filmes por Chave")]
        [InlineData("tt3606756")]
        [InlineData("tt3501632")]
        [InlineData("tt1825683")]
        public async Task DeveObterFilmesPorChaveAsync(string chave)
        {
            var filmeMock = _filmesRepositorioMock.Lista.FirstOrDefault(i => i.Id.Equals(chave));

            var httpContextoMock = new Mock<IHttpContexto>();
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.ObterAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_filmesRepositorioMock.Lista));

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpContextoMock.Object);
            var filme = await filmeRepositorio.ObterAsync(chave);

            filme.Should().NotBeNull().And.BeEquivalentTo(filmeMock);
        }
    }
}
