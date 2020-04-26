using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;

namespace BinaryLab.CopaFilmes.Repositorio.Http
{
    public class RepositorioHttpLeitura<TEntidade> : RepositorioHttpLeitura<TEntidade, int>, IRepositorioLeitura<TEntidade>
        where TEntidade : class, IEntidade<int>
    {

        public RepositorioHttpLeitura(IHttpClientFactory httpClientFactory, Uri uriRecurso) : base(httpClientFactory,
            uriRecurso)
        {
        }
    }

    public class RepositorioHttpLeitura<TEntidade, TChave> : IRepositorioLeitura<TEntidade, TChave>
        where TEntidade : class, IEntidade<TChave>
        where TChave : IEquatable<TChave>
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly Uri _uriRecurso;

        public RepositorioHttpLeitura(IHttpClientFactory httpClientFactory, Uri uriRecurso)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _uriRecurso = uriRecurso ?? throw new ArgumentNullException(nameof(uriRecurso));
        }

        public IEnumerable<TEntidade> Obter()
        {
            _httpClientFactory.CreateClient()
        }

        public async Task<IEnumerable<TEntidade>> ObterAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TEntidade Obter(TChave chave)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntidade> ObterAsync(TChave chave, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<TEntidade> Obter(TChave[] chaves)
        {
            throw new NotSupportedException();
        }

        public async Task<IEnumerable<TEntidade>> ObterAsync(TChave[] chaves, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<TEntidade> Find(Expression<Func<TEntidade, bool>> predicate)
        {
            throw new NotSupportedException();
        }

        public async Task<IEnumerable<TEntidade>> FindAsync(Expression<Func<TEntidade, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}
