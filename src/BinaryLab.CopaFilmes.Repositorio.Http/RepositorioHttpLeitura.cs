using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;
using BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace BinaryLab.CopaFilmes.Repositorio.Http
{
    public class RepositorioHttpLeitura<TEntidade> : RepositorioHttpLeitura<TEntidade, int>, IRepositorioLeitura<TEntidade>
        where TEntidade : class, IEntidade<int>
    {

        public RepositorioHttpLeitura([NotNull] IHttpContexto httpContexto) : base(httpContexto)
        {
        }
    }

    public class RepositorioHttpLeitura<TEntidade, TChave> : IRepositorioLeitura<TEntidade, TChave>
        where TEntidade : class, IEntidade<TChave>
        where TChave : IEquatable<TChave>
    {
        protected readonly IHttpContexto _httpContexto;

        public RepositorioHttpLeitura([NotNull] IHttpContexto httpContexto)
        {
            _httpContexto = httpContexto ?? throw new ArgumentNullException(nameof(httpContexto));
        }

        public virtual IEnumerable<TEntidade> Obter() => ObterAsync().Result;

        public virtual async Task<IEnumerable<TEntidade>> ObterAsync(CancellationToken cancellationToken = default)
        {
            var resposta = await _httpContexto.ObterAsync(_httpContexto.UrlRecurso, cancellationToken);
            return await ConverterRetornoAsync<IEnumerable<TEntidade>>(resposta);
        }

        public virtual TEntidade Obter(TChave chave) => ObterAsync(chave).Result;

        public virtual async Task<TEntidade> ObterAsync(TChave chave, CancellationToken cancellationToken = default)
        {
            var url = $"{_httpContexto.UrlRecurso}/{chave}";
            var resposta = await _httpContexto.ObterAsync(url, cancellationToken);
            return await ConverterRetornoAsync<TEntidade>(resposta);
        }

        public virtual IEnumerable<TEntidade> Obter(TChave[] chaves) => ObterAsync(chaves).Result;

        public virtual async Task<IEnumerable<TEntidade>> ObterAsync(TChave[] chaves, CancellationToken cancellationToken = default)
        {
            var conteudo = await ObterAsync(cancellationToken);
            return conteudo.Where(i => chaves.Any(j => j.Equals(i.Id)));
        }

        public virtual IEnumerable<TEntidade> Find(Expression<Func<TEntidade, bool>> predicate) => FindAsync(predicate).Result;

        public virtual async Task<IEnumerable<TEntidade>> FindAsync(Expression<Func<TEntidade, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var conteudo = await ObterAsync(cancellationToken);
            return conteudo.Where(predicate.Compile());
        }

        private async Task<TRetorno> ConverterRetornoAsync<TRetorno>(HttpResponseMessage resposta)
        {
            if (!resposta.IsSuccessStatusCode)
                return default;

            var conteudoResposta= await resposta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TRetorno>(conteudoResposta);
        }
    }
}
