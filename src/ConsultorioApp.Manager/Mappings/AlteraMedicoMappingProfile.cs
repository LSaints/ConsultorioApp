using AutoMapper;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Manager.Mappings
{
    public class AlteraMedicoMappingProfile : Profile
    {
        public AlteraMedicoMappingProfile()
        {
            CreateMap<AlteraCliente, Medico>();
        }
    }
}
