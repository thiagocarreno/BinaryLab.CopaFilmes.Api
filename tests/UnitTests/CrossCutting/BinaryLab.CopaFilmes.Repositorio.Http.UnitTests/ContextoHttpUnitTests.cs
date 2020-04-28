using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Tests.Mocks;
using FluentAssertions;
using Moq;
using Xunit;

namespace BinaryLab.CopaFilmes.Repositorio.Http.UnitTests
{
    public class ContextoHttpUnitTests
    {

        [Fact(DisplayName = "Deve Obter Assíncronamente Clinte Http")]
        public async Task DeveObterContextoHttpAsync()
        {
            var httpClientMock = new HttpClient();
            httpClientMock.BaseAddress = new Uri(AppSettings.RecursoExterno.UrlBase);

            var contextoHttp = new ContextoHttp(httpClientMock, AppSettings.RecursoExterno.Filmes);
            var contexto = await contextoHttp.ObterContextoAsync();

            contexto.Should().NotBeNull().And.BeEquivalentTo(httpClientMock);
        }
    }
}
