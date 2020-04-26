using System.Collections.Generic;
using System.Linq;

namespace BinaryLab.CopaFilmes.Tests.Mocks.Repositorio.Entidades
{
    public class Filmes
    {
        public IEnumerable<Filme.Repositorio.Entidades.Filme> Lista { get; }
        public IEnumerable<Filme.Repositorio.Entidades.Filme> OitoPrimeiros { get; }

        public Filmes()
        {
            var filmesDominioMock = new Dominio.Filmes();
            Lista = filmesDominioMock.Lista.Select(f =>
                Filme.Repositorio.Entidades.Filme.Create(f.Id, f.Nome, f.Ano, f.Nota));

            OitoPrimeiros = filmesDominioMock.OitoPrimeiros.Select(f =>
                Filme.Repositorio.Entidades.Filme.Create(f.Id, f.Nome, f.Ano, f.Nota));
        }
    }
}
