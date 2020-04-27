using System.Collections.Generic;
using System.Linq;

namespace BinaryLab.CopaFilmes.Tests.Mocks.ServicoAplicacao.DTO
{
    public class Filmes
    {
        public IEnumerable<Filme.ServicoAplicacao.DTO.Filme> Lista { get; }
        public IEnumerable<string> OitoPrimeirosIds { get; }
        public IEnumerable<Filme.ServicoAplicacao.DTO.Filme> Vencedores { get; }

        public Filmes()
        {
            var filmesDominio = new Mocks.Dominio.Filmes();
            Lista = filmesDominio.Lista.Select(f => new Filme.ServicoAplicacao.DTO.Filme()
            {
                Id = f.Id,
                Titulo = f.Titulo,
                Ano = f.Ano
            });

            OitoPrimeirosIds = filmesDominio.OitoPrimeiros.Select(f => f.Id);

            Vencedores = filmesDominio.VencedoresSegundaRodada.Select(f => new Filme.ServicoAplicacao.DTO.Filme()
            {
                Id = f.Id,
                Titulo = f.Titulo,
                Ano = f.Ano
            });
        }
    }
}
