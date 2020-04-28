using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace BinaryLab.CopaFilmes.Logging
{
    public static class Extensoes
    {
        public static IWebHostBuilder UseLog(this IWebHostBuilder hostBuilder) => 
            hostBuilder.UseSerilog();
    }
}
