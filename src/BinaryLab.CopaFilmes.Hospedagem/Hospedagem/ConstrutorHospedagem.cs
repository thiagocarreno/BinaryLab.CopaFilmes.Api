using BinaryLab.CopaFilmes.Hospedagem.Abstracoes.Hospedagem;
using BinaryLab.CopaFilmes.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Hospedagem.Hospedagem
{
    public class ConstrutorHospedagem : IConstrutorHospedagem
    {
        public async Task<int> CriarConstrutorHospedagemWeb<TStartup>(string[] args = default, string title = default)
            where TStartup : class
        {
            var logger = Logging.ConfiguracaoLogger.CriarLogger(VariaveisAmbiente.AspnetCoreEnvironment);
            logger.Information(MensagensLogs.IniciandoHospedagem);

            try
            {
                var consoleTitle = title;
                if (string.IsNullOrEmpty(consoleTitle))
                    consoleTitle = typeof(TStartup).Assembly.GetName().Name;

                Console.Title = consoleTitle;
                var hotBuilder = WebHost.CreateDefaultBuilder(args)
                    .ConfigureLogging(builder => builder.ClearProviders())
                    .UseStartup<TStartup>().UseLog();
                
                await hotBuilder.Build().RunAsync();
                return 0;
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, MensagensLogs.TerminadoInesperadamente);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static async Task<int> CriarHospedagemWeb<TStartup>(string[] args = default, string title = default)
            where TStartup : class => await new ConstrutorHospedagem().CriarConstrutorHospedagemWeb<TStartup>(args, title);
    }
}
