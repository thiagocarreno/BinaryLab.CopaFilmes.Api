using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Filme.Dominio.Abstracoes;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.Dominio
{
    public class FilmeDominio : IFilmeDominio
    {
        public IEnumerable<Entidade.Filme> Ordenar(IEnumerable<Entidade.Filme> filmes) => OrdenarAsync(filmes).Result;

        public async Task<IEnumerable<Entidade.Filme>> OrdenarAsync(IEnumerable<Entidade.Filme> filmes)
        {
            if (filmes == null)
                throw new ArgumentNullException(nameof(filmes));

            return filmes.OrderBy(f => f.Nome);
        }

        public int CalcularDisputas(IEnumerable<Entidade.Filme> filmes) => CalcularDisputasAsync(filmes).Result;

        public async Task<int> CalcularDisputasAsync(IEnumerable<Entidade.Filme> filmes)
        {
            if (filmes == null)
                throw new ArgumentNullException(nameof(filmes));

            return filmes.Count() / 2;
        }

        public int ObterUltimoIndex(int quantidadeFilmes, int index) =>
            ObterUltimoIndexAsync(quantidadeFilmes, index).Result;

        public async Task<int> ObterUltimoIndexAsync(int quantidadeFilmes, int index)
        {
            if (quantidadeFilmes <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantidadeFilmes));

            return (quantidadeFilmes - index) - 1;
        }

        public Entidade.Filme ObterVencedor([NotNull] Entidade.Filme primeiroFilmeDisputa,
            [NotNull] Entidade.Filme segundoFilmeDisputa) =>
            ObterVencedorAsync(primeiroFilmeDisputa, segundoFilmeDisputa).Result;

        public async Task<Entidade.Filme> ObterVencedorAsync(Entidade.Filme primeiroFilmeDisputa, Entidade.Filme segundoFilmeDisputa)
        {
            if (primeiroFilmeDisputa == null)
                throw new ArgumentNullException(nameof(primeiroFilmeDisputa));
            
            if (segundoFilmeDisputa == null)
                throw new ArgumentNullException(nameof(segundoFilmeDisputa));

            if (primeiroFilmeDisputa.Nota == segundoFilmeDisputa.Nota ||
                primeiroFilmeDisputa.Nota > segundoFilmeDisputa.Nota)
                return primeiroFilmeDisputa;
            
            return segundoFilmeDisputa;
        }

        public IEnumerable<Entidade.Filme> Disputar(IEnumerable<Entidade.Filme> filmes) => DisputarAsync(filmes).Result;

        public async Task<IEnumerable<Entidade.Filme>> DisputarAsync(IEnumerable<Entidade.Filme> filmes)
        {
            var quantidadeDisputa = await CalcularDisputasAsync(filmes);
            var vencedores = new List<Entidade.Filme>(quantidadeDisputa);
            var filmesOrdenados = await OrdenarAsync(filmes);
            var quantidadeFilmes = filmesOrdenados.Count();

            for (int i = 0; i < quantidadeDisputa; i++)
            {
                var indexUltimoFilme = await ObterUltimoIndexAsync(quantidadeFilmes, i);
                var primeiroFilmeDisputa = filmesOrdenados.ElementAt(i);
                var segundoFilmeDisputa = filmesOrdenados.ElementAt(indexUltimoFilme);
                vencedores.Add(await ObterVencedorAsync(primeiroFilmeDisputa, segundoFilmeDisputa));
            }

            return vencedores;
        }
    }
}
