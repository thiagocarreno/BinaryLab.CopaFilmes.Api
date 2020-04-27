using System;
using BinaryLab.CopaFilmes.Logging.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.SystemConsole.Themes;

namespace BinaryLab.CopaFilmes.Logging
{
    public class ConfiguracaoLogger : IConfiguracaoLogger
    {
        public ILogger Configurar(string variavelAmbiente)
        {
            var ambiente = Environment.GetEnvironmentVariable(variavelAmbiente);
            var configuracao = new Serilog.LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override(FonteLog.Microsoft, LogEventLevel.Information)
                .MinimumLevel.Override(FonteLog.Sistema, LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName();

            if (ambiente == EnvironmentName.Development)
                configuracao.WriteTo.Console(theme: AnsiConsoleTheme.Code);
            else
                configuracao.WriteTo.Console(new ElasticsearchJsonFormatter());

            Log.Logger = configuracao.CreateLogger();
            return Log.Logger;
        }

        public static ILogger CriarLogger(string variavelAmbiente) =>
            new ConfiguracaoLogger().Configurar(variavelAmbiente);
    }
}
