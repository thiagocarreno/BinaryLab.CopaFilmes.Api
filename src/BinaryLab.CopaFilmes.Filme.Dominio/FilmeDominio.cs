using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Filme.Dominio.Abstracoes;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.Dominio
{
    public class FilmeDominio : IFilmeDominio
    {
        public IEnumerable<Entidades.Filme> Ordenar(IEnumerable<Entidades.Filme> filmes) => OrdenarAsync(filmes).Result;

        public async Task<IEnumerable<Entidades.Filme>> OrdenarAsync(IEnumerable<Entidades.Filme> filmes, CancellationToken cancellationToken = default)
        {
            if (filmes == null)
                throw new ArgumentNullException(nameof(filmes));

            return filmes.OrderBy(f => f.Nome);
        }

        public int CalcularDisputas(IEnumerable<Entidades.Filme> filmes) => CalcularDisputasAsync(filmes).Result;

        public async Task<int> CalcularDisputasAsync(IEnumerable<Entidades.Filme> filmes, CancellationToken cancellationToken = default)
        {
            if (filmes == null)
                throw new ArgumentNullException(nameof(filmes));

            return filmes.Count() / 2;
        }

        public int ObterUltimoIndex(int quantidadeFilmes, int index) =>
            ObterUltimoIndexAsync(quantidadeFilmes, index).Result;

        public async Task<int> ObterUltimoIndexAsync(int quantidadeFilmes, int index, CancellationToken cancellationToken = default)
        {
            if (quantidadeFilmes <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantidadeFilmes));

            return (quantidadeFilmes - index) - 1;
        }

        public IEnumerable<Entidades.Filme> ObterVencedores(IEnumerable<Entidades.Filme> filmes)
        {
            var vencedores = Disputar(filmes);
            if (vencedores.Count() > 2)
                vencedores = ObterVencedores(vencedores);

            return vencedores;
        }

        public async Task<IEnumerable<Entidades.Filme>> ObterVencedoresAsync(IEnumerable<Entidades.Filme> filmes, CancellationToken cancellationToken = default)
        {
            var vencedores = await DisputarAsync(filmes);
            if (vencedores.Count() > 2)
                vencedores = ObterVencedores(vencedores);

            return vencedores;
        }

        public Entidades.Filme ObterVencedor([NotNull] Entidades.Filme primeiroFilmeDisputa,
            [NotNull] Entidades.Filme segundoFilmeDisputa) =>
            ObterVencedorAsync(primeiroFilmeDisputa, segundoFilmeDisputa).Result;

        public async Task<Entidades.Filme> ObterVencedorAsync(Entidades.Filme primeiroFilmeDisputa, Entidades.Filme segundoFilmeDisputa, CancellationToken cancellationToken = default)
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

        public IEnumerable<Entidades.Filme> Disputar(IEnumerable<Entidades.Filme> filmes) => DisputarAsync(filmes).Result;

        public async Task<IEnumerable<Entidades.Filme>> DisputarAsync(IEnumerable<Entidades.Filme> filmes, CancellationToken cancellationToken = default)
        {
            var quantidadeDisputa = await CalcularDisputasAsync(filmes);
            var vencedores = new List<Entidades.Filme>(quantidadeDisputa);
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
