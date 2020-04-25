using System.Collections.Generic;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Abstracoes
{
    public interface IFilmeServicoAplicacao
    {
        IEnumerable<DTO.Filme> ObterFilmes();
        Dominio.Entidades.Filme ObterVencedor([NotNull] IEnumerable<int> idsFilmesDisputa);
    }
}