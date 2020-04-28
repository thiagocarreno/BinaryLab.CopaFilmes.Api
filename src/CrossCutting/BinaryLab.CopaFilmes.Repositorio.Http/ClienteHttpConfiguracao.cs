using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryLab.CopaFilmes.Repositorio.Http
{
    public class ClienteHttpConfiguracao
    {
        public string NomeCliente { get; set; }
        public string UrlBase { get; set; }
        public string Filmes { get; set; }
        public int Retentativas { get; set; }
        public double IntervaloRetentativas { get; set; }
        public int EventosAntesQuebraCircuitBreaker { get; set; }
        public double IntervaloCircuitBreaker { get; set; }
        public double TempoCicloVida { get; set; }
    }
}
