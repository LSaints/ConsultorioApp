using AutoMapper;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Manager.Mappings
{
    public class AlteraClienteMappingProfile : Profile
    {
        public AlteraClienteMappingProfile()
        {
            CreateMap<AlteraCliente, Cliente>()
                .ForMember(c => c.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(c => c.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
        }
    }
}
