using AutoMapper;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Mappers
{
    public class FilmeMapper : Profile
    {
        public FilmeMapper()
        {
            CreateMap<Repositorio.Entidades.Filme, DTO.Filme>();
        }
    }
}
