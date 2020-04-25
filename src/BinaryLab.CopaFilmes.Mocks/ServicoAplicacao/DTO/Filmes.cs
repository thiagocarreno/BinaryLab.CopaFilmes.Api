using System.Collections.Generic;
using System.Linq;

namespace BinaryLab.CopaFilmes.Mocks.ServicoAplicacao.DTO
{
    public class Filmes
    {
        public IEnumerable<Filme.ServicoAplicacao.DTO.Filme> Lista { get; }

        public Filmes()
        {
            var filmesDominio = new Mocks.Dominio.Filmes();
            Lista = filmesDominio.Lista.Select(f => new Filme.ServicoAplicacao.DTO.Filme()
            {
                Id = f.Id,
                Nome = f.Nome,
                Ano = f.Ano
            });
        }
    }
}
