using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Mappers;
using FluentAssertions;
using Moq;
using Xunit;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Tests
{
    public class FilmeServicoAplicacaoTest
    {
        private Mocks.Repositorio.Entidades.Filmes FilmesRepositorioMock { get; }
        private Mocks.ServicoAplicacao.DTO.Filmes FilmesServicoAplicacaoMock { get; }
        private IMapper _mapper { get; }

        public FilmeServicoAplicacaoTest()
        {
            FilmesRepositorioMock = new Mocks.Repositorio.Entidades.Filmes();
            FilmesServicoAplicacaoMock = new Mocks.ServicoAplicacao.DTO.Filmes();

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
            var filmes = filmeServicoAplicacao.ObterFilmes();

            filmes.Should().BeEquivalentTo(FilmesServicoAplicacaoMock.Lista);
        }

        [Fact(DisplayName = "Deve Obter Assíncronamente os Filmes")]
        public void DeveObterFilmesAsync()
        {
            var filmeRepositorioMock = new Mock<IFilmeRepositorio>();
            filmeRepositorioMock.Setup(frp => frp.Obter()).Returns(FilmesRepositorioMock.Lista);
            
            var filmeServicoAplicacao = new FilmeServicoAplicacao(filmeRepositorioMock.Object, _mapper);
            var filmes = filmeServicoAplicacao.ObterFilmes();

            filmes.Should().BeEquivalentTo(FilmesServicoAplicacaoMock.Lista);
        }
    }
}
