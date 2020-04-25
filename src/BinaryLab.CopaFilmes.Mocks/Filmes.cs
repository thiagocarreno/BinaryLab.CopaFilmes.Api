using System.Collections.Generic;
using System.Linq;
using BinaryLab.CopaFilmes.Repositorio.Entidades;

namespace BinaryLab.CopaFilmes.Mocks
{
    public class Filmes
    {
        public IEnumerable<Filme.Dominio.Entidade.Filme> Lista { get; }
        public IEnumerable<Filme.Dominio.Entidade.Filme> OitoPrimeiros { get; }
        public IEnumerable<Filme.Dominio.Entidade.Filme> OitoPrimeirosOrdenados { get; }
        public IEnumerable<Filme.Dominio.Entidade.Filme> VencedoresPrimeiraRodada { get; }
        public IEnumerable<Filme.Dominio.Entidade.Filme> VencedoresSegundaRodada { get; }
        public Filme.Dominio.Entidade.Filme Vencedor { get; set; }

        public Filmes()
        {
            Lista = new List<Filme.Dominio.Entidade.Filme>
            {
                Filme.Dominio.Entidade.Filme.Create("tt3606756", "Os Incríveis 2", 2018, 8.5M),
                Filme.Dominio.Entidade.Filme.Create("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.3M),
                Filme.Dominio.Entidade.Filme.Create("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3M),
                Filme.Dominio.Entidade.Filme.Create("tt7784604", "Hereditário", 2018, 7.8M),
                Filme.Dominio.Entidade.Filme.Create("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8M),
                Filme.Dominio.Entidade.Filme.Create("tt5463162", "Deadpool 2", 2018, 8.1M),
                Filme.Dominio.Entidade.Filme.Create("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2M),
                Filme.Dominio.Entidade.Filme.Create("tt3501632", "Thor: Ragnarok", 2017, 7.9M),
                Filme.Dominio.Entidade.Filme.Create("tt2854926", "Te Peguei!", 2018, 7.1M),
                Filme.Dominio.Entidade.Filme.Create("tt0317705", "Os Incríveis", 2004, 8),
                Filme.Dominio.Entidade.Filme.Create("tt3799232", "A Barraca do Beijo", 2018, 6.4M),
                Filme.Dominio.Entidade.Filme.Create("tt1365519", "Tomb Raider: A Origem", 2018, 6.5M),
                Filme.Dominio.Entidade.Filme.Create("tt1825683", "Pantera Negra", 2018, 7.5M),
                Filme.Dominio.Entidade.Filme.Create("tt5834262", "Hotel Artemis", 2018, 6.3M),
                Filme.Dominio.Entidade.Filme.Create("tt7690670", "Superfly", 2018, 5.1M),
                Filme.Dominio.Entidade.Filme.Create("tt6499752", "Upgrade", 2018, 7.8M)
            };

            OitoPrimeiros = Lista.Take(8);
            OitoPrimeirosOrdenados = OitoPrimeiros.OrderBy(f => f.Nome);

            VencedoresPrimeiraRodada = new List<Filme.Dominio.Entidade.Filme>
            {
                OitoPrimeiros.ElementAt(4), OitoPrimeiros.ElementAt(7),
                OitoPrimeiros.ElementAt(0), OitoPrimeiros.ElementAt(1)
            };

            VencedoresSegundaRodada = new List<Filme.Dominio.Entidade.Filme>
            {
                OitoPrimeiros.ElementAt(4), OitoPrimeiros.ElementAt(0)
            };

            Vencedor = OitoPrimeiros.ElementAt(4);
        }
    }
}