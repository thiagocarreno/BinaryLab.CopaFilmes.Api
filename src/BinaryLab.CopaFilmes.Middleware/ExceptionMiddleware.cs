using System;
using System.Net;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace BinaryLab.CopaFilmes.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate Next;
        static readonly ILogger Log = Serilog.Log.ForContext<ExceptionMiddleware>();

        public ExceptionMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = TiposConteudo.Json;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                Log.Error(ex.Message, ex);

                await context
                    .Response
                    .WriteAsync(JsonConvert
                        .SerializeObject(ex,
                            new JsonSerializerSettings {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }));
            }
        }
    }
}
