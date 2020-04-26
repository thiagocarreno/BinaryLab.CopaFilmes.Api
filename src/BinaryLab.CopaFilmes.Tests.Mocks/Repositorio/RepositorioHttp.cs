using System.Linq;
using BinaryLab.CopaFilmes.Tests.Mocks.Repositorio.Entidades;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace BinaryLab.CopaFilmes.Tests.Mocks.Repositorio
{
    public class RepositorioHttp
    {
        public HttpResponseMessage MensagemSucesso { get; }

        private readonly Filmes _filmesMock;

        public RepositorioHttp()
        {
            _filmesMock = new Filmes();
            
            MensagemSucesso = new HttpResponseMessage(HttpStatusCode.OK);
            MensagemSucesso.Content = new StringContent(JsonConvert.SerializeObject(_filmesMock.Lista));
        }

        public HttpResponseMessage GetContent(string chave)
        {
            var httoResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httoResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(_filmesMock.Lista.First(i => i.Id.Equals(chave))));

            return httoResponseMessage;
        }
    }
}
