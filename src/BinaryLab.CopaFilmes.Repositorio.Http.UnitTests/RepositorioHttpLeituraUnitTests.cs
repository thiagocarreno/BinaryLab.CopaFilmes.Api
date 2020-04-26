using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes;
using BinaryLab.CopaFilmes.Tests.Mocks.Repositorio;
using BinaryLab.CopaFilmes.Tests.Mocks.Repositorio.Entidades;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace BinaryLab.CopaFilmes.Repositorio.Http.UnitTests
{
    public class RepositorioHttpLeituraUnitTests
    {
        private readonly Filmes _filmesMock;
        private readonly RepositorioHttp _repositorioHttp;

        public RepositorioHttpLeituraUnitTests()
        {
            _filmesMock = new Filmes();
            _repositorioHttp = new RepositorioHttp();
        }

        [Fact(DisplayName = "Deve Obter Todo Conteúdo de Recurso de Api")]
        public void DeveObterTodoConteudoDeApi()
        {
            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.MensagemSucesso));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = repositorioHttp.Obter();

            retorno.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.Lista);
        }

        [Fact(DisplayName = "Deve Obter Assíncronamente Todo Conteúdo de Recurso de Api")]
        public async Task DeveObterTodoConteudoDeApiAsync()
        {
            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.MensagemSucesso));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = await repositorioHttp.ObterAsync();

            retorno.Should().NotBeNull().And.BeEquivalentTo(_filmesMock.Lista);
        }

        [Theory(DisplayName = "Deve Obter Conteúdo de Recurso de Api")]
        [InlineData("tt3606756")]
        [InlineData("tt4154756")]
        [InlineData("tt0317705")]
        [InlineData("tt5834262")]
        [InlineData("tt6499752")]
        public void DeveObterConteudoDeApi(string chave)
        {
            var retornoMock = _filmesMock.Lista.First(i => i.Id.Equals(chave));
            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.GetContent(chave)));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = repositorioHttp.Obter(chave);

            retorno.Should().NotBeNull().And.BeEquivalentTo(retornoMock);
        }

        [Theory(DisplayName = "Deve Obter Assíncronamente Conteúdo de Recurso de Api")]
        [InlineData("tt3606756")]
        [InlineData("tt4154756")]
        [InlineData("tt0317705")]
        [InlineData("tt5834262")]
        [InlineData("tt6499752")]
        public async Task DeveObterConteudoDeApiAsync(string chave)
        {
            var retornoMock = _filmesMock.Lista.First(i => i.Id.Equals(chave));
            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.GetContent(chave)));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = await repositorioHttp.ObterAsync(chave);

            retorno.Should().NotBeNull().And.BeEquivalentTo(retornoMock);
        }

        [Theory(DisplayName = "Deve Obter Conteúdo Filtrado de Recurso de Api")]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(8)]
        public void DeveObterConteudoFiltradoDeApi(int quantidadeItens)
        {
            var retornoMock = _filmesMock.Lista.Take(quantidadeItens);
            var filtro = retornoMock.Select(i => i.Id).ToArray();

            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.MensagemSucesso));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = repositorioHttp.Obter(filtro);

            retorno.Should().NotBeNull().And.BeEquivalentTo(retornoMock);
        }

        [Theory(DisplayName = "Deve Obter Assíncronamente Conteúdo Filtrado de Recurso de Api")]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(8)]
        public async Task DeveObterConteudoFiltradoDeApiAsync(int quantidadeItens)
        {
            var retornoMock = _filmesMock.Lista.Take(quantidadeItens);
            var filtro = retornoMock.Select(i => i.Id).ToArray();

            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.MensagemSucesso));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = await repositorioHttp.ObterAsync(filtro);

            retorno.Should().NotBeNull().And.BeEquivalentTo(retornoMock);
        }

        [Theory(DisplayName = "Deve Obter Conteúdo Filtrado Por Chave de Recurso de Api")]
        [InlineData("tt3606756")]
        [InlineData("tt4154756")]
        [InlineData("tt0317705")]
        [InlineData("tt5834262")]
        [InlineData("tt6499752")]
        public void DeveObterConteudoFiltradoPorChaveDeApi(string chave)
        {
            var retornoMock = _filmesMock.Lista.Where(i => i.Id.Equals(chave));

            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.MensagemSucesso));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = repositorioHttp.Find(i => i.Id.Equals(chave));

            retorno.Should().NotBeNull().And.BeEquivalentTo(retornoMock);
        }

        [Theory(DisplayName = "Deve Obter Assíncronamente Conteúdo Filtrado Por Chave de Recurso de Api")]
        [InlineData("tt3606756")]
        [InlineData("tt4154756")]
        [InlineData("tt0317705")]
        [InlineData("tt5834262")]
        [InlineData("tt6499752")]
        public async Task DeveObterConteudoFiltradoPorChaveDeApiAsync(string chave)
        {
            var retornoMock = _filmesMock.Lista.Where(i => i.Id.Equals(chave));

            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.MensagemSucesso));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = await repositorioHttp.FindAsync(i => i.Id.Equals(chave));

            retorno.Should().NotBeNull().And.BeEquivalentTo(retornoMock);
        }

        [Theory(DisplayName = "Deve Obter Conteúdo Filtrado Por Nome de Recurso de Api")]
        [InlineData("Os Incríveis 2")]
        [InlineData("Oito Mulheres e um Segredo")]
        [InlineData("Vingadores: Guerra Infinita")]
        public void DeveObterConteudoFiltradoPorNomeDeApi(string nome)
        {
            var retornoMock = _filmesMock.Lista.Where(i => i.Nome.Equals(nome));

            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.MensagemSucesso));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = repositorioHttp.Find(i => i.Nome.Equals(nome));

            retorno.Should().NotBeNull().And.BeEquivalentTo(retornoMock);
        }

        [Theory(DisplayName = "Deve Obter Assíncronamente Conteúdo Filtrado Por Nome de Recurso de Api")]
        [InlineData("Os Incríveis 2")]
        [InlineData("Oito Mulheres e um Segredo")]
        [InlineData("Vingadores: Guerra Infinita")]
        public async Task DeveObterConteudoFiltradoPorNomeDeApiAsync(string nome)
        {
            var retornoMock = _filmesMock.Lista.Where(i => i.Id.Equals(nome));

            var httpContextoMock = new Mock<IHttpContexto>();
            httpContextoMock.Setup(htm => htm.ObterAsync(It.IsAny<string>(),It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_repositorioHttp.MensagemSucesso));

            var repositorioHttp = new RepositorioHttpLeitura<Filme.Repositorio.Entidades.Filme, string>(httpContextoMock.Object);
            var retorno = await repositorioHttp.FindAsync(i => i.Id.Equals(nome));

            retorno.Should().NotBeNull().And.BeEquivalentTo(retornoMock);
        }
    }
}
