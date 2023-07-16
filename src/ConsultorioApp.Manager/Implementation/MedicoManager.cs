using AutoMapper;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.Manager.Interfaces.Managers;
using ConsultorioApp.Manager.Interfaces.Repositories;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Manager.Implementation
{
    public class MedicoManager : IMedicoManager
    {
        private readonly IMedicoRepository _repository;
        private readonly IMapper _mapper;
        public MedicoManager(IMedicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task DeleteMedicoAsync(int id)
        {
            _repository.DeleteMedicoAsync(id);
        }

        public Task<Medico> GetMedicoAsync(int id)
        {
            return _repository.GetMedicoAsync(id);
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await _repository.GetMedicosAsync();
        }

        public async Task<Medico> InsertMedicoAsync(NovoMedico novoMedico)
        {
            var medico = _mapper.Map<Medico>(novoMedico);
            return await _repository.InsertMedicoAsync(medico);
        }

        public async Task<Medico> UpdateMedicoAsync(AlterarMedico alterarMedico)
        {
            var medico = _mapper.Map<Medico>(alterarMedico);
            return await _repository.UpdateMedicoAsync(medico);
        }
    }
}
