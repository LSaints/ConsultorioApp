using AutoMapper;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Manager.Mappings
{
    public class NovoClienteMappingProfile : Profile
    {
        public NovoClienteMappingProfile()
        {
            CreateMap<NovoCliente, Cliente>()
                .ForMember(d => d.Criacao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

            CreateMap<NovoEndereco, Endereco>();
        }
    }
}
