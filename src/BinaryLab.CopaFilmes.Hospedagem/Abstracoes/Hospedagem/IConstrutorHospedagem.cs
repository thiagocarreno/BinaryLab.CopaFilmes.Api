using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Hospedagem.Abstracoes.Hospedagem
{
    public interface IConstrutorHospedagem
    {
        Task<int> CriarConstrutorHospedagemWeb<TStartup>(string[] args = default, string title = default)
            where TStartup : class;
    }
}
