using AutoMapper;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Mapeamentos
{
    public class FilmeMapper : Profile
    {
        public FilmeMapper()
        {
            CreateMap<Repositorio.Entidades.Filme, DTO.Filme>();
            CreateMap<Repositorio.Entidades.Filme, Dominio.Entidades.Filme>();
            CreateMap<Dominio.Entidades.Filme, DTO.Filme>();
        }
    }
}
