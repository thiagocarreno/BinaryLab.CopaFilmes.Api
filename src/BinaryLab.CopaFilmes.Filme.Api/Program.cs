using BinaryLab.CopaFilmes.Hospedagem.Hospedagem;
using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Filme.Api
{
    public class Program
    {
        private static async Task<int> Main(string[] args) => await ConstrutorHospedagem.CriarHospedagemWeb<Startup>(args);
    }
}
