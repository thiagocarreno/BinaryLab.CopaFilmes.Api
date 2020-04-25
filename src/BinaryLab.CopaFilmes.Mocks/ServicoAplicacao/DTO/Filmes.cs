using System.Collections.Generic;

namespace BinaryLab.CopaFilmes.Mocks.ServicoAplicacao.DTO
{
    public class Filmes
    {
        public IEnumerable<Filme.ServicoAplicacao.DTO.Filme> Lista { get; }

        public Filmes()
        {
            Lista = new List<Filme.ServicoAplicacao.DTO.Filme>(16);
        }
    }
}
