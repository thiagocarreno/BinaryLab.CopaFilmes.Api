using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Tests.Mocks.Repositorio.Entidades;
using FluentAssertions;
using Microsoft.Extensions.Http;
using Moq;
using Xunit;

namespace BinaryLab.CopaFilmes.Filme.Repositorio.UnitTests
{
    public class FilmeRepositorioUnitTests
    {
        public Filmes FilmesRepositorioMock { get; set; }
        public Tests.Mocks.ServicoAplicacao.DTO.Filmes FilmesSevicoAplicacaoMock { get; set; }

        public FilmeRepositorioUnitTests()
        {
            FilmesRepositorioMock = new Filmes();
            FilmesSevicoAplicacaoMock = new Tests.Mocks.ServicoAplicacao.DTO.Filmes();
        }

        [Fact(DisplayName = "Deve Obter Filmes")]
        public void DeveObterFilmes()
        {
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var uriRecursoMock = new Uri(Tests.Mocks.AppSettings.UriRecurso);
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.Obter()).Returns(FilmesRepositorioMock.Lista);

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpClientFactoryMock.Object, uriRecursoMock);
            var filmes = filmeRepositorio.Obter();

            filmes.Should().BeEquivalentTo(FilmesRepositorioMock.Lista);
        }

        [Fact(DisplayName = "Deve Obter Filmes Assíncronamente")]
        public async Task DeveObterFilmesAsync()
        {
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var uriRecursoMock = new Uri(Tests.Mocks.AppSettings.UriRecurso);
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.ObterAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(FilmesRepositorioMock.Lista));

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpClientFactoryMock.Object, uriRecursoMock);
            var filmes = await filmeRepositorio.ObterAsync();

            filmes.Should().BeEquivalentTo(FilmesRepositorioMock.Lista);
        }

        [Fact(DisplayName = "Deve Obter Filmes por Ids")]
        public void DeveObterFilmesPorIds()
        {
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var uriRecursoMock = new Uri(Tests.Mocks.AppSettings.UriRecurso);
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.Obter(It.IsAny<string[]>())).Returns(FilmesRepositorioMock.OitoPrimeiros);

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpClientFactoryMock.Object, uriRecursoMock);
            var filmes = filmeRepositorio.Obter(FilmesSevicoAplicacaoMock.OitoPrimeirosIds.ToArray());

            filmes.Should().BeEquivalentTo(FilmesRepositorioMock.OitoPrimeiros);
        }

        [Fact(DisplayName = "Deve Obter Filmes por Ids Assíncronamente")]
        public async Task DeveObterFilmesPorIdsAsync()
        {
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var uriRecursoMock = new Uri(Tests.Mocks.AppSettings.UriRecurso);
            var repositorioLeituraMock = new Mock<IRepositorioLeitura<Filme.Repositorio.Entidades.Filme, string>>();
            repositorioLeituraMock.Setup(r => r.ObterAsync(It.IsAny<string[]>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(FilmesRepositorioMock.OitoPrimeiros));

            var filmeRepositorio = new FilmeRepositorio(repositorioLeituraMock.Object, httpClientFactoryMock.Object, uriRecursoMock);
            var filmes = await filmeRepositorio.ObterAsync(FilmesSevicoAplicacaoMock.OitoPrimeirosIds.ToArray(), CancellationToken.None);

            filmes.Should().BeEquivalentTo(FilmesRepositorioMock.OitoPrimeiros);
        }
    }
}
